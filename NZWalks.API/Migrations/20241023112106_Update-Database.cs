using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("87ee271a-3225-4693-36f4-08dcf2b0197c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d164ca1d-deb7-4a77-86c5-fb9a7148c835"));

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("49382892-b872-4f16-8b31-8f8a8f409cb5"), "STL", "Southland", null },
                    { new Guid("5611634b-5000-4e7b-89df-26eaf6bb9eb3"), "NSN", "Nelson", null },
                    { new Guid("856e83a2-467f-4f87-b151-0b4bae97c3db"), "BOP", "Bay Of Plenty", null },
                    { new Guid("adc2a3f2-8b25-43d0-ac25-6a9c752ec7e5"), "WGN", "Wellington", null },
                    { new Guid("b509ff86-1133-4f64-b3db-eff41651d55f"), "HKL", "Huckland", null },
                    { new Guid("ef5cefa8-c72c-4bc5-8d7c-3c9ee0015589"), "NTL", "Northland", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("49382892-b872-4f16-8b31-8f8a8f409cb5"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5611634b-5000-4e7b-89df-26eaf6bb9eb3"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("856e83a2-467f-4f87-b151-0b4bae97c3db"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("adc2a3f2-8b25-43d0-ac25-6a9c752ec7e5"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b509ff86-1133-4f64-b3db-eff41651d55f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("ef5cefa8-c72c-4bc5-8d7c-3c9ee0015589"));

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("87ee271a-3225-4693-36f4-08dcf2b0197c"), "IND", "India", "India-Image.jpg" },
                    { new Guid("d164ca1d-deb7-4a77-86c5-fb9a7148c835"), "AKL", "Auckland Region", "some-image-url.jpg" }
                });
        }
    }
}
