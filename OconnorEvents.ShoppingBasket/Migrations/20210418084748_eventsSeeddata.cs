using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OconnorEvents.ShoppingBasket.Migrations
{
    public partial class eventsSeeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Name" },
                values: new object[,]
                {
                    { new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"), new DateTime(2021, 10, 18, 9, 47, 47, 732, DateTimeKind.Local).AddTicks(9692), "John Egbert Live" },
                    { new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"), new DateTime(2022, 1, 18, 9, 47, 47, 736, DateTimeKind.Local).AddTicks(3097), "The State of Affairs: Michael Live!" },
                    { new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"), new DateTime(2021, 8, 18, 9, 47, 47, 736, DateTimeKind.Local).AddTicks(3215), "Clash of the DJs" },
                    { new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"), new DateTime(2021, 8, 18, 9, 47, 47, 736, DateTimeKind.Local).AddTicks(3297), "Spanish guitar hits with Manuel" },
                    { new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"), new DateTime(2022, 2, 18, 9, 47, 47, 736, DateTimeKind.Local).AddTicks(3315), "Techorama 2021" },
                    { new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"), new DateTime(2021, 12, 18, 9, 47, 47, 736, DateTimeKind.Local).AddTicks(3339), "To the Moon and Back" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"));
        }
    }
}
