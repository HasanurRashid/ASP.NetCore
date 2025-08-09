using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FirstDemo.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSeedDataForCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("780e9152-d791-4931-bf62-6990d315f1ff"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("7f03a47e-367c-417f-8f3c-1ce96c815751"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("85d6f1cc-7553-43e4-93e4-567288e702db"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("8a1d494d-3d8a-493e-b38c-2b8117f55533"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("8ac21667-0211-43a7-9adf-f2c7cc68132a"));

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Fees", "Title" },
                values: new object[,]
                {
                    { new Guid("169a4106-3052-4a16-bcf7-321330d82507"), "Test", 2000L, "C#" },
                    { new Guid("55ae7105-4608-4036-94a9-c6fff940c4e1"), "Test 2", 3000L, "Asp.net" },
                    { new Guid("700ec20c-4f86-4502-b088-894b64177302"), "Test 3", 3000L, "PHP" },
                    { new Guid("bbae6df5-ce80-4d42-bc90-b3c30a0957c0"), "Test 4", 3000L, "Entity Framework" },
                    { new Guid("e50ce560-fc0f-4774-a15e-f91b7bb8863e"), "Test 5", 3000L, "Ado.Net" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("169a4106-3052-4a16-bcf7-321330d82507"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("55ae7105-4608-4036-94a9-c6fff940c4e1"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("700ec20c-4f86-4502-b088-894b64177302"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("bbae6df5-ce80-4d42-bc90-b3c30a0957c0"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("e50ce560-fc0f-4774-a15e-f91b7bb8863e"));

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Fees", "Title" },
                values: new object[,]
                {
                    { new Guid("780e9152-d791-4931-bf62-6990d315f1ff"), "Test 2", 3000L, "Asp.net" },
                    { new Guid("7f03a47e-367c-417f-8f3c-1ce96c815751"), "Test 5", 3000L, "Ado.Net" },
                    { new Guid("85d6f1cc-7553-43e4-93e4-567288e702db"), "Test", 2000L, "C#" },
                    { new Guid("8a1d494d-3d8a-493e-b38c-2b8117f55533"), "Test 3", 3000L, "PHP" },
                    { new Guid("8ac21667-0211-43a7-9adf-f2c7cc68132a"), "Test 4", 3000L, "Entity Framework" }
                });
        }
    }
}
