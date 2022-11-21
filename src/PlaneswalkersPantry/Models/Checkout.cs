using MySqlConnector;

namespace PlaneswalkersPantry.Models;

public class Checkout
{
    public enum CheckoutStatus : int
    {
        Basket = 0,
        Current = 1,
        Returned = 2
    }

    private static int GetRandomCheckoutNumber()
    {
        Random random = new Random();
        byte[] data = new byte[4];
        random.NextBytes(data);

        return BitConverter.ToInt32(data);
    }

    public static IEnumerable<Checkout> GetCurrentCheckouts(string userName)
    {
        using MySqlConnection conn = Database.CreateConnection();

        List<Checkout> retval = new List<Checkout>();
        using (MySqlCommand command = new MySqlCommand("SELECT * FROM CHECKOUT WHERE (USER_NAME = @name AND STATUS = 1)", conn))
        {
            command.Parameters.Add(new MySqlParameter("name", userName));
            MySqlDataReader results = command.ExecuteReader();

            bool hasRows = results.Read();
            while (hasRows)
            {
                Checkout checkout = FromSqlRow(results);
                checkout.Status = CheckoutStatus.Current;
                retval.Add(checkout);

                hasRows = results.Read();
            }

            results.Close();
        }

        conn.Close();
        return retval;
    }

    public static Checkout? GetBasket(string userName, bool createIfNeeded)
    {
        using MySqlConnection conn = Database.CreateConnection();

        Checkout? LoadCheckout()
        {
            Checkout? basket = null;
            using (MySqlCommand command = new MySqlCommand("SELECT * FROM CHECKOUT WHERE (STATUS = 0 AND USER_NAME = @user)", conn))
            {
                command.Parameters.Add(new MySqlParameter("user", userName));

                MySqlDataReader results = command.ExecuteReader();
                bool hasRows = results.Read();
                if (hasRows)
                {
                    basket = FromSqlRow(results);
                    hasRows = results.Read();
                    if (hasRows) throw new InvalidOperationException($"More than one basket for user {userName} was found");
                }

                results.Close();
            }

            return basket;
        }

        Checkout? basket = LoadCheckout();
        if (basket == null && createIfNeeded)
        {
            using (MySqlCommand command =
                   new MySqlCommand("INSERT INTO CHECKOUT (CHECKOUT_NUMBER, DUE_DATE, USER_NAME, STATUS) VALUES (@checkout_number, @due_date, @user_name, 0)", conn))
            {
                command.Parameters.Add(new MySqlParameter("checkout_number", GetRandomCheckoutNumber()));
                command.Parameters.Add(new MySqlParameter("due_date", DateTime.Now));
                command.Parameters.Add(new MySqlParameter("user_name", userName));

                command.ExecuteNonQuery();
            }

            basket = LoadCheckout();
        }

        conn.Close();

        if (basket != null)
        {
            basket.Status = CheckoutStatus.Basket;
        }

        return basket;
    }

    public static Checkout? Find(int checkoutNumber)
    {
        using MySqlConnection conn = Database.CreateConnection();

        Checkout? retval = null;
        using (MySqlCommand command = new MySqlCommand("SELECT * FROM CHECKOUT WHERE (CHECKOUT_NUMBER = @num)", conn))
        {
            command.Parameters.Add(new MySqlParameter("num", checkoutNumber));

            using MySqlDataReader results = command.ExecuteReader();
            bool hasRows = results.Read();

            if (hasRows)
            {
                retval = FromSqlRow(results);

                hasRows = results.Read();
                if (hasRows)
                    throw new InvalidOperationException("More than one checkout was found");
            }
        }

        conn.Close();
        return retval;
    }

    public static Checkout FromSqlRow(MySqlDataReader results)
    {
        Checkout value = new Checkout();
        value.CheckoutNumber = results.GetInt32("CHECKOUT_NUMBER");
        value.DueDate = results.GetDateTime("DUE_DATE");
        value.UserName = results.GetString("USER_NAME");
        value.Status = (CheckoutStatus)results.GetInt32("STATUS");
        return value;
    }

    public Checkout()
    {
        _cardsInCheckoutLoader = new Lazy<IEnumerable<(Card, uint count)>>(LoadCardsInCheckout);
    }

    public int CheckoutNumber { get; set; }
    public DateTime? DueDate { get; set; }
    public string? UserName { get; set; }
    public CheckoutStatus Status { get; set; } = CheckoutStatus.Current;

    public IEnumerable<(Card, uint count)> CardsInCheckout => _cardsInCheckoutLoader.Value;

    private readonly Lazy<IEnumerable<(Card, uint count)>> _cardsInCheckoutLoader;

    private IEnumerable<(Card, uint count)> LoadCardsInCheckout()
    {
        using MySqlConnection conn = Database.CreateConnection();

        List<(int, uint)> values = new List<(int, uint)>();
        using (MySqlCommand command =
               new MySqlCommand("SELECT * FROM CARD_IN_CHECKOUT WHERE (CHECKOUT_NUMBER = @num)", conn))
        {
            command.Parameters.Add(new MySqlParameter("num", CheckoutNumber));
            var results = command.ExecuteReader();

            bool hasRows = results.Read();
            while (hasRows)
            {
                int cardId = results.GetInt32("CARD_NUMBER");
                uint count = results.GetUInt32("COUNT");
                values.Add((cardId, count));

                hasRows = results.Read();
            }

            results.Close();
        }

        List<(Card, uint)> retval = new List<(Card, uint)>();
        foreach ((int cardId, uint count) in values)
        {
            Card? card = Card.Find(cardId);
            if (card == null) throw new InvalidOperationException($"Could not look up card with number {cardId}");
            retval.Add((card, count));
        }

        return retval;
    }

    public void ConfirmCheckout()
    {
        if (Status != CheckoutStatus.Basket)
            throw new InvalidOperationException("This function only works on a user's basket");

        DateTime dueDate = DateTime.Now.AddDays(14);
        DueDate = new DateTime(dueDate.Year, dueDate.Month, dueDate.Day, 23, 59, 59);
        Status = CheckoutStatus.Current;

        using MySqlConnection conn = Database.CreateConnection();
        using (MySqlCommand command =
               new MySqlCommand("UPDATE CHECKOUT SET DUE_DATE = @date, STATUS = @status WHERE (CHECKOUT_NUMBER = @id)",
                   conn))
        {
            command.Parameters.Add(new MySqlParameter("date", DueDate.Value));
            command.Parameters.Add(new MySqlParameter("status", (int)Status));
            command.Parameters.Add(new MySqlParameter("id", CheckoutNumber));

            command.ExecuteNonQuery();
        }

        conn.Close();
    }

    public void ReturnCheckout()
    {
        if (Status != CheckoutStatus.Current)
            throw new InvalidOperationException("This function only works on a current checkout");

        Status = CheckoutStatus.Returned;

        using MySqlConnection conn = Database.CreateConnection();
        using (MySqlCommand command =
               new MySqlCommand("UPDATE CHECKOUT SET STATUS = @status WHERE (CHECKOUT_NUMBER = @id)",
                   conn))
        {
            command.Parameters.Add(new MySqlParameter("status", (int)Status));
            command.Parameters.Add(new MySqlParameter("id", CheckoutNumber));

            command.ExecuteNonQuery();
        }

        conn.Close();
    }

    public void AddCard(Card card, uint count)
    {
        using MySqlConnection conn = Database.CreateConnection();

        int existingCount;
        using (MySqlCommand command = new MySqlCommand("SELECT * FROM CARD_IN_CHECKOUT WHERE (CHECKOUT_NUMBER = @checkout AND CARD_NUMBER = @card)", conn))
        {
            command.Parameters.Add(new MySqlParameter("checkout", CheckoutNumber));
            command.Parameters.Add(new MySqlParameter("card", card.CardNumber));

            MySqlDataReader results = command.ExecuteReader();
            bool hasRows = results.Read();

            if (hasRows)
            {
                existingCount = (int)results.GetUInt32("COUNT");
            }
            else
            {
                existingCount = -1;
            }

            results.Close();
        }

        bool done = false;
        if (existingCount != -1)
        {
            using (MySqlCommand command =
                   new MySqlCommand(
                       "UPDATE CARD_IN_CHECKOUT SET COUNT = @value WHERE (CHECKOUT_NUMBER = @checkout AND CARD_NUMBER = @card)",
                       conn))
            {
                uint newCount = (uint)existingCount + count;
                command.Parameters.Add(new MySqlParameter("value", newCount));
                command.Parameters.Add(new MySqlParameter("checkout", CheckoutNumber));
                command.Parameters.Add(new MySqlParameter("card", card.CardNumber));

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected != 0) done = true;
            }
        }

        if (done)
        {
            conn.Close();
            return;
        }

        using (MySqlCommand command =
               new MySqlCommand(
                   "INSERT INTO CARD_IN_CHECKOUT (CHECKOUT_NUMBER, CARD_NUMBER, COUNT) VALUES (@checkout, @card, @count)",
                   conn))
        {
            command.Parameters.Add(new MySqlParameter("checkout", CheckoutNumber));
            command.Parameters.Add(new MySqlParameter("card", card.CardNumber));
            command.Parameters.Add(new MySqlParameter("count", count));

            command.ExecuteNonQuery();
        }

        conn.Close();
    }

    public bool RemoveCard(Card card)
    {
        // This method returns true if any cards were deleted from the database.

        int rowsAffected;

        using MySqlConnection conn = Database.CreateConnection();
        using (MySqlCommand command =
               new MySqlCommand(
                   "DELETE FROM CARD_IN_CHECKOUT WHERE (CHECKOUT_NUMBER = @checkout AND CARD_NUMBER = @card)", conn))
        {
            command.Parameters.Add(new MySqlParameter("checkout", CheckoutNumber));
            command.Parameters.Add(new MySqlParameter("card", card.CardNumber));

            rowsAffected = command.ExecuteNonQuery();
        }

        conn.Close();
        return rowsAffected > 0;
    }
}