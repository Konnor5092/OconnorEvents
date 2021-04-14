using Microsoft.EntityFrameworkCore.Migrations;

namespace OconnorEvents.ShoppingBasket.Migrations
{
    public partial class IEntityUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Events",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BasketId",
                table: "Baskets",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BasketLineId",
                table: "BasketLines",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Events",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Baskets",
                newName: "BasketId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BasketLines",
                newName: "BasketLineId");
        }
    }
}
