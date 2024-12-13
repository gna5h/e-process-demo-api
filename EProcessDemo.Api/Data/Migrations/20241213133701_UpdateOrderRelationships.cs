using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EProcessDemo.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_KitchenId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_KitchenId",
                table: "Orders",
                column: "KitchenId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_KitchenId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_KitchenId",
                table: "Orders",
                column: "KitchenId");
        }
    }
}
