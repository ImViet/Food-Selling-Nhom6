using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodSelling.Backend.Migrations
{
    public partial class RenameIdentityCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IndetityCard",
                table: "AspNetUsers",
                newName: "IdetityCard");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdetityCard",
                table: "AspNetUsers",
                newName: "IndetityCard");
        }
    }
}
