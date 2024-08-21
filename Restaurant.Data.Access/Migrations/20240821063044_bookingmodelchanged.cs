using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Data.Access.Migrations
{
    /// <inheritdoc />
    public partial class bookingmodelchanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Menu_MenuId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_MenuId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Bookings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_MenuId",
                table: "Bookings",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Menu_MenuId",
                table: "Bookings",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
