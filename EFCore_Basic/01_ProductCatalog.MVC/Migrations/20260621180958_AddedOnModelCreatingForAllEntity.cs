using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _01_ProductCatalog.MVC.Migrations
{
    /// <inheritdoc />
    public partial class AddedOnModelCreatingForAllEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Shop_Categories_Product_Category_Name",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Shops_Shop_Sellers_Shop_Owner_Id",
                table: "Shops");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Shop_Categories_Product_Category_Name",
                table: "Products",
                column: "Product_Category_Name",
                principalTable: "Shop_Categories",
                principalColumn: "Category_Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_Shop_Sellers_Shop_Owner_Id",
                table: "Shops",
                column: "Shop_Owner_Id",
                principalTable: "Shop_Sellers",
                principalColumn: "Shop_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Shop_Categories_Product_Category_Name",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Shops_Shop_Sellers_Shop_Owner_Id",
                table: "Shops");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Shop_Categories_Product_Category_Name",
                table: "Products",
                column: "Product_Category_Name",
                principalTable: "Shop_Categories",
                principalColumn: "Category_Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_Shop_Sellers_Shop_Owner_Id",
                table: "Shops",
                column: "Shop_Owner_Id",
                principalTable: "Shop_Sellers",
                principalColumn: "Shop_Id");
        }
    }
}
