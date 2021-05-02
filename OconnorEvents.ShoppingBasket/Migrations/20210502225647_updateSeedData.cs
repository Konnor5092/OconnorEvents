using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OconnorEvents.ShoppingBasket.Migrations
{
    public partial class updateSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                columns: new[] { "Artist", "Date", "Description", "ImageUrl", "Price", "VenueCity", "VenueCountry", "VenueName" },
                values: new object[] { "Many", new DateTime(2022, 3, 2, 7, 0, 0, 0, DateTimeKind.Unspecified), "The best tech conference in the world", "https://neilmorrisseypluralsight.blob.core.windows.net/imgs/conf.jpg", 400, "Vancouver", "Canada", "Commodore Ballroom" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                columns: new[] { "Artist", "Date", "Description", "ImageUrl", "Price", "VenueCity", "VenueCountry", "VenueName" },
                values: new object[] { "Michael Johnson", new DateTime(2022, 2, 2, 7, 0, 0, 0, DateTimeKind.Unspecified), "Michael Johnson doesn't need an introduction. His 25 concert across the globe last year were seen by thousands. Can we add you to the list?", "https://neilmorrisseypluralsight.blob.core.windows.net/imgs/michael.jpg", 85, "Toronto", "Canada", "Massey Hall" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                columns: new[] { "Artist", "Date", "Description", "ImageUrl", "Price", "VenueCity", "VenueCountry", "VenueName" },
                values: new object[] { "Manuel Santinonisi", new DateTime(2021, 9, 2, 7, 0, 0, 0, DateTimeKind.Unspecified), "Get on the hype of Spanish Guitar concerts with Manuel.", "https://neilmorrisseypluralsight.blob.core.windows.net/imgs/guitar.jpg", 25, "Montreal", "Canada", "L'Olympia" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                columns: new[] { "Artist", "Date", "Description", "ImageUrl", "Price", "VenueCity", "VenueCountry", "VenueName" },
                values: new object[] { "Nick Sailor", new DateTime(2022, 1, 2, 7, 0, 0, 0, DateTimeKind.Unspecified), "The critics are over the moon and so will you after you've watched this sing and dance extravaganza written by Nick Sailor, the man from 'My dad and sister'.", "https://neilmorrisseypluralsight.blob.core.windows.net/imgs/musical.jpg", 135, "Vancouver", "Canada", "Commodore Ballroom" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                columns: new[] { "Artist", "Date", "Description", "ImageUrl", "Price", "VenueCity", "VenueCountry", "VenueName" },
                values: new object[] { "DJ 'The Mike'", new DateTime(2021, 9, 2, 7, 0, 0, 0, DateTimeKind.Unspecified), "DJs from all over the world will compete in this epic battle for eternal fame.", "https://neilmorrisseypluralsight.blob.core.windows.net/imgs/dj.jpg", 85, "Montreal", "Canada", "L'Olympia" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                columns: new[] { "Artist", "Date", "Description", "ImageUrl", "Price", "VenueCity", "VenueCountry", "VenueName" },
                values: new object[] { "John Egbert", new DateTime(2021, 11, 2, 7, 0, 0, 0, DateTimeKind.Unspecified), "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.", "https://neilmorrisseypluralsight.blob.core.windows.net/imgs/banjo.jpg", 65, "Toronto", "Canada", "Massey Hall" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                columns: new[] { "Artist", "Date", "Description", "ImageUrl", "Price", "VenueCity", "VenueCountry", "VenueName" },
                values: new object[] { null, new DateTime(2022, 3, 2, 23, 31, 37, 490, DateTimeKind.Local).AddTicks(7685), null, null, 0, null, null, null });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                columns: new[] { "Artist", "Date", "Description", "ImageUrl", "Price", "VenueCity", "VenueCountry", "VenueName" },
                values: new object[] { null, new DateTime(2022, 2, 2, 23, 31, 37, 490, DateTimeKind.Local).AddTicks(7378), null, null, 0, null, null, null });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                columns: new[] { "Artist", "Date", "Description", "ImageUrl", "Price", "VenueCity", "VenueCountry", "VenueName" },
                values: new object[] { null, new DateTime(2021, 9, 2, 23, 31, 37, 490, DateTimeKind.Local).AddTicks(7660), null, null, 0, null, null, null });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                columns: new[] { "Artist", "Date", "Description", "ImageUrl", "Price", "VenueCity", "VenueCountry", "VenueName" },
                values: new object[] { null, new DateTime(2022, 1, 2, 23, 31, 37, 490, DateTimeKind.Local).AddTicks(7717), null, null, 0, null, null, null });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                columns: new[] { "Artist", "Date", "Description", "ImageUrl", "Price", "VenueCity", "VenueCountry", "VenueName" },
                values: new object[] { null, new DateTime(2021, 9, 2, 23, 31, 37, 490, DateTimeKind.Local).AddTicks(7629), null, null, 0, null, null, null });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                columns: new[] { "Artist", "Date", "Description", "ImageUrl", "Price", "VenueCity", "VenueCountry", "VenueName" },
                values: new object[] { null, new DateTime(2021, 11, 2, 23, 31, 37, 486, DateTimeKind.Local).AddTicks(3700), null, null, 0, null, null, null });
        }
    }
}
