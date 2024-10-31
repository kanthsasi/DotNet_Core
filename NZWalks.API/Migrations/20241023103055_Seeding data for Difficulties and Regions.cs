using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("b2fb70a3-e378-4f10-9878-131d231f9a39"), "Easy" },
                    { new Guid("b4e08474-bfe6-4de0-ba61-6e9d4196490a"), "Hard" },
                    { new Guid("c0c25a30-94a0-4816-b1c2-e63fdbbc285d"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("87ee271a-3225-4693-36f4-08dcf2b0197c"), "IND", "India", "India-Image.jpg" },
                    { new Guid("d164ca1d-deb7-4a77-86c5-fb9a7148c835"), "AKL", "Auckland Region", "some-image-url.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("b2fb70a3-e378-4f10-9878-131d231f9a39"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("b4e08474-bfe6-4de0-ba61-6e9d4196490a"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("c0c25a30-94a0-4816-b1c2-e63fdbbc285d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("87ee271a-3225-4693-36f4-08dcf2b0197c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d164ca1d-deb7-4a77-86c5-fb9a7148c835"));
        }
    }
}
