using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _01_ProductCatalog.MVC.Migrations
{
    /// <inheritdoc />
    public partial class SeedSampleSellers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Shop_Sellers",
                columns: new[] { "Shop_Id", "Seller_Bio", "Date_Of_Birth", "Seller_Name", "Profile_Creation_Time" },
                values: new object[,]
                {
                    { "019ede29-6976-7f78-9a60-60a851dc132d", "It's a simple bio!", new DateTime(2002, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hasib Hasnain", new DateTime(2026, 6, 19, 4, 35, 16, 471, DateTimeKind.Utc).AddTicks(5021) },
                    { "019ede29-6977-7506-9e28-5467d58a5890", "Honest and Elegent Seller!", new DateTime(2000, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rahim Iqbal", new DateTime(2026, 6, 19, 4, 35, 16, 471, DateTimeKind.Utc).AddTicks(7576) },
                    { "019ede29-6977-7c31-8c79-b2b0b197832b", "Selling My Used Bat Balls!", new DateTime(1997, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tamim Iqbal", new DateTime(2026, 6, 19, 4, 35, 16, 471, DateTimeKind.Utc).AddTicks(7606) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shop_Sellers",
                keyColumn: "Shop_Id",
                keyValue: "019ede29-6976-7f78-9a60-60a851dc132d");

            migrationBuilder.DeleteData(
                table: "Shop_Sellers",
                keyColumn: "Shop_Id",
                keyValue: "019ede29-6977-7506-9e28-5467d58a5890");

            migrationBuilder.DeleteData(
                table: "Shop_Sellers",
                keyColumn: "Shop_Id",
                keyValue: "019ede29-6977-7c31-8c79-b2b0b197832b");
        }
    }
}
