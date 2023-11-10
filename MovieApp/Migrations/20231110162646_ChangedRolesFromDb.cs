﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangedRolesFromDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61e40310-ad86-4a24-99d4-c87bd147b01a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5082ec3-3d8a-4b08-84d1-247cd4fa1c46");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "49ccd0c2-aa16-4f7c-852c-7a69140454dd", null, "Admin", "ADMIN" },
                    { "ed5fbf99-374f-45cb-8ba6-451c43cbfb0f", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49ccd0c2-aa16-4f7c-852c-7a69140454dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed5fbf99-374f-45cb-8ba6-451c43cbfb0f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "61e40310-ad86-4a24-99d4-c87bd147b01a", null, "Administrator", "ADMINISTRATOR" },
                    { "e5082ec3-3d8a-4b08-84d1-247cd4fa1c46", null, "Manager", "MANAGER" }
                });
        }
    }
}
