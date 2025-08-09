using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FirstDemo.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class StudentCreateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cgpa = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Fees", "Title" },
                values: new object[,]
                {
                    { new Guid("169a4106-3052-4a16-bcf7-321330d82507"), "Test 4", 3000L, "Entity Framework" },
                    { new Guid("55ae7105-4608-4036-94a9-c6fff940c4e1"), "Test", 2000L, "C#" },
                    { new Guid("700ec20c-4f86-4502-b088-894b64177302"), "Test 3", 3000L, "PHP" },
                    { new Guid("bbae6df5-ce80-4d42-bc90-b3c30a0957c0"), "Test 5", 3000L, "Ado.Net" },
                    { new Guid("e50ce560-fc0f-4774-a15e-f91b7bb8863e"), "Test 2", 3000L, "Asp.net" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

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
                    { new Guid("49893c56-a7e4-4cdb-805f-354e8da557e0"), "Test 5", 3000L, "Ado.Net" },
                    { new Guid("58d1ecd1-3cdd-4ddd-9df4-8a7db33418b8"), "Test 3", 3000L, "PHP" },
                    { new Guid("80c43714-6d7d-4b51-b6cf-847a8bdb6351"), "Test 2", 3000L, "Asp.net" },
                    { new Guid("d08fa251-8477-43e8-98c6-e4a3f8d754b9"), "Test 4", 3000L, "Entity Framework" },
                    { new Guid("e356c4fd-bd64-4991-93e9-3d9947d7cf4f"), "Test", 2000L, "C#" }
                });
        }
    }
}
