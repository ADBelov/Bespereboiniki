using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bespereboiniki.Datalayer.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("b29f65e7-43b9-4a14-9ab2-ddca2312f2e3"), "admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("57eb14fb-cfb9-43b6-869d-28bb06e57540"), "manager" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Login", "Password", "RoleId", "Surname" },
                values: new object[] { new Guid("869ab7ac-227d-4f45-b6b7-30455bd86a83"), "Админ", "Фсея Руси", "admin", "admin", new Guid("b29f65e7-43b9-4a14-9ab2-ddca2312f2e3"), "Админович" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Login", "Password", "RoleId", "Surname" },
                values: new object[] { new Guid("1af8d4a8-0577-4f7b-a917-2083cf3590d7"), "Менеджер", "Фсея Бесперебойники.рф", "manager", "manager", new Guid("57eb14fb-cfb9-43b6-869d-28bb06e57540"), "Менеджерович" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1af8d4a8-0577-4f7b-a917-2083cf3590d7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("869ab7ac-227d-4f45-b6b7-30455bd86a83"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("57eb14fb-cfb9-43b6-869d-28bb06e57540"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b29f65e7-43b9-4a14-9ab2-ddca2312f2e3"));
        }
    }
}
