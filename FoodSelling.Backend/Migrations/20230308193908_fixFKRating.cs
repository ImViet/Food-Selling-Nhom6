using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodSelling.Backend.Migrations
{
    public partial class fixFKRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_AspNetUsers_UserName",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_UserName",
                table: "Ratings");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Ratings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Ratings",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserName",
                table: "Ratings",
                column: "UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_AspNetUsers_UserName",
                table: "Ratings",
                column: "UserName",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
