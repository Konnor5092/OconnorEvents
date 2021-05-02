using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OconnorEvents.EventCatalog.Migrations
{
    public partial class updateSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VenueId",
                table: "Events",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Venue",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venue", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Venue",
                columns: new[] { "Id", "City", "Country", "Name" },
                values: new object[] { new Guid("bcd82a4c-881e-44fc-ba94-c857ab1ab071"), "Toronto", "Canada", "Massey Hall" });

            migrationBuilder.InsertData(
                table: "Venue",
                columns: new[] { "Id", "City", "Country", "Name" },
                values: new object[] { new Guid("45929e17-9f3c-4dd4-8043-126c34733dc5"), "Montreal", "Canada", "L'Olympia" });

            migrationBuilder.InsertData(
                table: "Venue",
                columns: new[] { "Id", "City", "Country", "Name" },
                values: new object[] { new Guid("2d8f80ca-616f-4928-bd09-a1849fec5a9a"), "Vancouver", "Canada", "Commodore Ballroom" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                columns: new[] { "Date", "ImageUrl", "VenueId" },
                values: new object[] { new DateTime(2022, 3, 2, 7, 0, 0, 0, DateTimeKind.Unspecified), "https://neilmorrisseypluralsight.blob.core.windows.net/imgs/conf.jpg", new Guid("2d8f80ca-616f-4928-bd09-a1849fec5a9a") });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                columns: new[] { "Date", "ImageUrl", "VenueId" },
                values: new object[] { new DateTime(2022, 2, 2, 7, 0, 0, 0, DateTimeKind.Unspecified), "https://neilmorrisseypluralsight.blob.core.windows.net/imgs/michael.jpg", new Guid("bcd82a4c-881e-44fc-ba94-c857ab1ab071") });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                columns: new[] { "Date", "ImageUrl", "VenueId" },
                values: new object[] { new DateTime(2021, 9, 2, 7, 0, 0, 0, DateTimeKind.Unspecified), "https://neilmorrisseypluralsight.blob.core.windows.net/imgs/guitar.jpg", new Guid("45929e17-9f3c-4dd4-8043-126c34733dc5") });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                columns: new[] { "Date", "ImageUrl", "VenueId" },
                values: new object[] { new DateTime(2022, 1, 2, 7, 0, 0, 0, DateTimeKind.Unspecified), "https://neilmorrisseypluralsight.blob.core.windows.net/imgs/musical.jpg", new Guid("2d8f80ca-616f-4928-bd09-a1849fec5a9a") });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                columns: new[] { "Date", "ImageUrl", "VenueId" },
                values: new object[] { new DateTime(2021, 9, 2, 7, 0, 0, 0, DateTimeKind.Unspecified), "https://neilmorrisseypluralsight.blob.core.windows.net/imgs/dj.jpg", new Guid("45929e17-9f3c-4dd4-8043-126c34733dc5") });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                columns: new[] { "Date", "ImageUrl", "VenueId" },
                values: new object[] { new DateTime(2021, 11, 2, 7, 0, 0, 0, DateTimeKind.Unspecified), "https://neilmorrisseypluralsight.blob.core.windows.net/imgs/banjo.jpg", new Guid("bcd82a4c-881e-44fc-ba94-c857ab1ab071") });

            migrationBuilder.CreateIndex(
                name: "IX_Events_VenueId",
                table: "Events",
                column: "VenueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Venue_VenueId",
                table: "Events",
                column: "VenueId",
                principalTable: "Venue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Venue_VenueId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "Venue");

            migrationBuilder.DropIndex(
                name: "IX_Events_VenueId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "VenueId",
                table: "Events");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                columns: new[] { "Date", "ImageUrl" },
                values: new object[] { new DateTime(2022, 2, 10, 22, 59, 50, 954, DateTimeKind.Local).AddTicks(9951), "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/conf.jpg" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                columns: new[] { "Date", "ImageUrl" },
                values: new object[] { new DateTime(2022, 1, 10, 22, 59, 50, 954, DateTimeKind.Local).AddTicks(9860), "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/michael.jpg" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                columns: new[] { "Date", "ImageUrl" },
                values: new object[] { new DateTime(2021, 8, 10, 22, 59, 50, 954, DateTimeKind.Local).AddTicks(9933), "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/guitar.jpg" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                columns: new[] { "Date", "ImageUrl" },
                values: new object[] { new DateTime(2021, 12, 10, 22, 59, 50, 954, DateTimeKind.Local).AddTicks(9974), "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/musical.jpg" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                columns: new[] { "Date", "ImageUrl" },
                values: new object[] { new DateTime(2021, 8, 10, 22, 59, 50, 954, DateTimeKind.Local).AddTicks(9913), "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/dj.jpg" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                columns: new[] { "Date", "ImageUrl" },
                values: new object[] { new DateTime(2021, 10, 10, 22, 59, 50, 952, DateTimeKind.Local).AddTicks(7739), "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg" });
        }
    }
}
