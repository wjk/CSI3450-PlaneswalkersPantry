using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlaneswalkersPantry.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(name: "CARD_SET",
                columns: table => new
                {
                    Code = table.Column<string>(name: "SET_CODE", type: "varchar(3)", nullable: false),
                    Name = table.Column<string>(name: "NAME", type: "varchar(100)", nullable: false),
                    ReleaseYear = table.Column<int>(name: "RELEASE_YEAR", type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARD_SET", x => x.Code);
                }
            );

            migrationBuilder.CreateTable(name: "CARD",
                columns: table => new
                {
                    Id = table.Column<int>(name: "CARD_NUMBER", type: "int", nullable: false),
                    Title = table.Column<string>(name: "TITLE", type: "varchar(100)", nullable: false),
                    ManaCost = table.Column<string>(name: "MANA_COST", type:"varchar(50)", nullable: false),
                    RulesText = table.Column<string>(name: "RULES_TEXT", type: "varchar(1000)", nullable: true),
                    FlavorText = table.Column<string>(name: "FLAVOR_TEXT", type: "varchar(1000)", nullable: true),
                    SetCode = table.Column<string>(name: "SET_CODE", type: "varchar(3)", nullable: false),
                    Rarity = table.Column<string>(name: "RARITY", type: "varchar(1)", nullable: false),
                    Power = table.Column<string>(name: "POWER", type: "varchar(10)", nullable: true),
                    Toughness = table.Column<string>(name: "TOUGHNESS", type: "varchar(10)", nullable: true),
                    TypeLine = table.Column<string>(name: "TYPE_LINE", type: "varchar(100)", nullable: false),
                    NumberOwned = table.Column<uint>(name: "NUMBER_OWNED", type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARD", x => x.Id);
                    table.ForeignKey("FK_CARD_CARD_SET", x => x.Id,
                        "CARD_SET", "SET_CODE",
                        onDelete: ReferentialAction.NoAction, onUpdate: ReferentialAction.NoAction);
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("CARD");
            migrationBuilder.DropTable("CARD_SET");
        }
    }
}
