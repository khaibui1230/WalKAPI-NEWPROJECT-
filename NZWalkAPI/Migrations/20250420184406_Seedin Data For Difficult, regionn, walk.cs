using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalkAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedinDataForDifficultregionnwalk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("12881f7c-b772-46a3-a84e-142dc16104c7"), "Hard" },
                    { new Guid("364e2e8e-8027-4beb-9775-405545997ef0"), "Easy" },
                    { new Guid("a7110a23-5740-48a1-b018-89e8d47fc5f5"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("c0f3a2b1-4d8e-4b5f-9c7d-5a2e6f3b8c1e"), "NTH", "Northland", "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/Northland_region_map.png/800px-Northland_region_map.png" },
                    { new Guid("d1f3a2b1-4d8e-4b5f-9c7d-5a2e6f3b8c1e"), "AKL", "Auckland", "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/Auckland_region_map.png/800px-Auckland_region_map.png" },
                    { new Guid("e2f3a2b1-4d8e-4b5f-9c7d-5a2e6f3b8c1e"), "WAI", "Waikato", "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/Waikato_region_map.png/800px-Waikato_region_map.png" }
                });

            migrationBuilder.InsertData(
                table: "Walks",
                columns: new[] { "Id", "Description", "DifficultyId", "LengthInKm", "Name", "RegionId", "WalkImageUrl" },
                values: new object[,]
                {
                    { new Guid("aa0d1b17-5f27-4bde-81d1-905e0e7f23b0"), "A walk around the iconic Sky Tower in Auckland.", new Guid("12881f7c-b772-46a3-a84e-142dc16104c7"), 5.0, "Sky Tower Walk", new Guid("d1f3a2b1-4d8e-4b5f-9c7d-5a2e6f3b8c1e"), "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/Sky_Tower_Walk.png/800px-Sky_Tower_Walk.png" },
                    { new Guid("bbf9e091-1e43-48ab-b83f-5094e8b222c3"), "A walk to the stunning Huka Falls in Taupo.", new Guid("a7110a23-5740-48a1-b018-89e8d47fc5f5"), 8.0, "Huka Falls Walk", new Guid("e2f3a2b1-4d8e-4b5f-9c7d-5a2e6f3b8c1e"), "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/Huka_Falls_Walk.png/800px-Huka_Falls_Walk.png" },
                    { new Guid("f3f3a2b1-4d8e-4b5f-9c7d-5a2e6f3b8c1e"), "A scenic walk to the northernmost point of New Zealand.", new Guid("364e2e8e-8027-4beb-9775-405545997ef0"), 10.5, "Cape Reinga Walk", new Guid("c0f3a2b1-4d8e-4b5f-9c7d-5a2e6f3b8c1e"), "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/Cape_Reinga_Walk.png/800px-Cape_Reinga_Walk.png" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("aa0d1b17-5f27-4bde-81d1-905e0e7f23b0"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("bbf9e091-1e43-48ab-b83f-5094e8b222c3"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("f3f3a2b1-4d8e-4b5f-9c7d-5a2e6f3b8c1e"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("12881f7c-b772-46a3-a84e-142dc16104c7"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("364e2e8e-8027-4beb-9775-405545997ef0"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("a7110a23-5740-48a1-b018-89e8d47fc5f5"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c0f3a2b1-4d8e-4b5f-9c7d-5a2e6f3b8c1e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d1f3a2b1-4d8e-4b5f-9c7d-5a2e6f3b8c1e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e2f3a2b1-4d8e-4b5f-9c7d-5a2e6f3b8c1e"));
        }
    }
}
