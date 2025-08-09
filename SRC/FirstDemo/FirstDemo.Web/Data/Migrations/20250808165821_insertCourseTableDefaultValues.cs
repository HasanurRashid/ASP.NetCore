using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FirstDemo.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class insertCourseTableDefaultValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Fees", "Title" },
                values: new object[,]
                {
                    { new Guid("49893c56-a7e4-4cdb-805f-354e8da557e0"), "Test 5", 3000L, "Ado.Net" },
                    { new Guid("58d1ecd1-3cdd-4ddd-9df4-8a7db33418b8"), "Test 3", 3000L, "PHP" },
                    { new Guid("80c43714-6d7d-4b51-b6cf-847a8bdb6351"), "Test 2", 3000L, "Asp.net" },
                    { new Guid("d08fa251-8477-43e8-98c6-e4a3f8d754b9"), "Test 4", 3000L, "Entity Framework" },
                    { new Guid("e356c4fd-bd64-4991-93e9-3d9947d7cf4f"), "Test", 2000L, "C#" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("49893c56-a7e4-4cdb-805f-354e8da557e0"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("58d1ecd1-3cdd-4ddd-9df4-8a7db33418b8"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("80c43714-6d7d-4b51-b6cf-847a8bdb6351"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("d08fa251-8477-43e8-98c6-e4a3f8d754b9"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("e356c4fd-bd64-4991-93e9-3d9947d7cf4f"));
        }
    }
}
