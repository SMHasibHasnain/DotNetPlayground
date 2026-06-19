using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _01_ProductCatalog.MVC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product_Keywords",
                columns: table => new
                {
                    Keyword_Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Keywords", x => x.Keyword_Name);
                });

            migrationBuilder.CreateTable(
                name: "Shop_Sellers",
                columns: table => new
                {
                    Shop_Id = table.Column<string>(type: "TEXT", nullable: false),
                    Seller_Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Date_Of_Birth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Seller_Bio = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Profile_Creation_Time = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop_Sellers", x => x.Shop_Id);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Shop_Id = table.Column<string>(type: "TEXT", nullable: false),
                    Shop_Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Shop_Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Creation_Time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Shop_Owner_Id = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Shop_Id);
                    table.ForeignKey(
                        name: "FK_Shops_Shop_Sellers_Shop_Owner_Id",
                        column: x => x.Shop_Owner_Id,
                        principalTable: "Shop_Sellers",
                        principalColumn: "Shop_Id");
                });

            migrationBuilder.CreateTable(
                name: "Shop_Categories",
                columns: table => new
                {
                    Category_Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Category_Creation_Time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Category_Shop_Id = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop_Categories", x => x.Category_Name);
                    table.ForeignKey(
                        name: "FK_Shop_Categories_Shops_Category_Shop_Id",
                        column: x => x.Category_Shop_Id,
                        principalTable: "Shops",
                        principalColumn: "Shop_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Product_Id = table.Column<string>(type: "TEXT", nullable: false),
                    Product_Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Product_Profile_Picture = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    Product_Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Product_Available_Stock = table.Column<int>(type: "INTEGER", nullable: false),
                    Product_Posted_Time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Product_Shop_Id = table.Column<string>(type: "TEXT", nullable: false),
                    Product_Category_Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Product_Id);
                    table.ForeignKey(
                        name: "FK_Products_Shop_Categories_Product_Category_Name",
                        column: x => x.Product_Category_Name,
                        principalTable: "Shop_Categories",
                        principalColumn: "Category_Name");
                    table.ForeignKey(
                        name: "FK_Products_Shops_Product_Shop_Id",
                        column: x => x.Product_Shop_Id,
                        principalTable: "Shops",
                        principalColumn: "Shop_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KeywordProduct",
                columns: table => new
                {
                    KeywordsName = table.Column<string>(type: "TEXT", nullable: false),
                    ProductsId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeywordProduct", x => new { x.KeywordsName, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_KeywordProduct_Product_Keywords_KeywordsName",
                        column: x => x.KeywordsName,
                        principalTable: "Product_Keywords",
                        principalColumn: "Keyword_Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeywordProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Product_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KeywordProduct_ProductsId",
                table: "KeywordProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Product_Category_Name",
                table: "Products",
                column: "Product_Category_Name");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Product_Shop_Id",
                table: "Products",
                column: "Product_Shop_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_Categories_Category_Shop_Id",
                table: "Shop_Categories",
                column: "Category_Shop_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_Shop_Owner_Id",
                table: "Shops",
                column: "Shop_Owner_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeywordProduct");

            migrationBuilder.DropTable(
                name: "Product_Keywords");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Shop_Categories");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "Shop_Sellers");
        }
    }
}
