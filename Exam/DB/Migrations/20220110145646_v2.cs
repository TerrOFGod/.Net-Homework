using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Monsters",
                columns: new[] { "Id", "AC", "AttackModifier", "AttackPerRound", "Damage", "DamageModifier", "HP", "Name" },
                values: new object[,]
                {
                    { 5, 11, 7, 1, "2d8", 5, 45, "Rhinoceros" },
                    { 6, 12, 3, 4, "1d4", 2, 40, "Mage" },
                    { 7, 12, 0, 1, "1d1", 0, 2, "Cat" },
                    { 8, 12, 3, 1, "1d8", 1, 32, "Ice Frog" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
