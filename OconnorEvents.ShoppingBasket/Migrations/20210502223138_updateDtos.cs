using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OconnorEvents.ShoppingBasket.Migrations
{
    public partial class updateDtos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Artist",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "VenueCity",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VenueCountry",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VenueName",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2022, 3, 2, 23, 31, 37, 490, DateTimeKind.Local).AddTicks(7685));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2022, 2, 2, 23, 31, 37, 490, DateTimeKind.Local).AddTicks(7378));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2021, 9, 2, 23, 31, 37, 490, DateTimeKind.Local).AddTicks(7660));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2022, 1, 2, 23, 31, 37, 490, DateTimeKind.Local).AddTicks(7717));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2021, 9, 2, 23, 31, 37, 490, DateTimeKind.Local).AddTicks(7629));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2021, 11, 2, 23, 31, 37, 486, DateTimeKind.Local).AddTicks(3700));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Artist",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "VenueCity",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "VenueCountry",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "VenueName",
                table: "Events");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2022, 2, 18, 9, 47, 47, 736, DateTimeKind.Local).AddTicks(3315));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2022, 1, 18, 9, 47, 47, 736, DateTimeKind.Local).AddTicks(3097));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2021, 8, 18, 9, 47, 47, 736, DateTimeKind.Local).AddTicks(3297));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2021, 12, 18, 9, 47, 47, 736, DateTimeKind.Local).AddTicks(3339));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2021, 8, 18, 9, 47, 47, 736, DateTimeKind.Local).AddTicks(3215));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2021, 10, 18, 9, 47, 47, 732, DateTimeKind.Local).AddTicks(9692));
        }
    }
}
