using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodSelling.Backend.Migrations
{
    public partial class RenameIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdetityCard",
                table: "AspNetUsers",
                newName: "IdentityCard");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdentityCard",
                table: "AspNetUsers",
                newName: "IdetityCard");
        }
    }
}
