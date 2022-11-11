namespace PlaneswalkersPantry.Models;

public static class ExtensionMethods
{
    public static string ToDisplayString(this CardRarity rarity)
    {
        return rarity switch
        {
            CardRarity.Common => "Common",
            CardRarity.Uncommon => "Uncommon",
            CardRarity.Rare => "Rare",
            CardRarity.MythicRare => "Mythic Rare",
            _ => throw new ArgumentException("Invalid CardRarity value")
        };
    }
}