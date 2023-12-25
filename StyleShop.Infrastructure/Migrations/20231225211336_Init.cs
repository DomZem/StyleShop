using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StyleShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderAddress_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderAddress_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderAddress_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderAddress_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductQuantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_OrderStatuses_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Processing" },
                    { 3, "Shipped" },
                    { 4, "Delivered" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Fashion" },
                    { 3, "Entertainment" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Price", "ProductCategoryId", "Quantity" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 25, 21, 13, 35, 945, DateTimeKind.Utc).AddTicks(8039), "The iPhone 13, introduced in 2021, is part of Apple's flagship smartphone series. It features a sleek design with a Ceramic Shield front cover, a Textured Matte Glass back, and an aerospace-grade aluminum frame.", "Iphone 13", 3100m, 1, 100 },
                    { 2, new DateTime(2023, 12, 25, 21, 13, 35, 945, DateTimeKind.Utc).AddTicks(8042), "Elevate your athletic wardrobe with the Nike Dri-FIT Performance Crewneck Sweatshirt, a perfect blend of style and functionality.", "Nike sports sweatshirt", 119.99m, 2, 100 },
                    { 3, new DateTime(2023, 12, 25, 21, 13, 35, 945, DateTimeKind.Utc).AddTicks(8045), "Dive into the epic realm of Westeros with 'A Clash of Kingdoms,' the latest installment in the gripping 'Game of Thrones' series by George R.R. Martin.", "Game of Thrones - A Clash of Kingdoms", 49.99m, 3, 100 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OrderStatusId", "OrderedAt", "ProductId", "ProductQuantity", "OrderAddress_City", "OrderAddress_Country", "OrderAddress_PostalCode", "OrderAddress_Street" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 25, 21, 13, 35, 945, DateTimeKind.Utc).AddTicks(8078), 1, 1, "Another City", "UK", "54321", "789 Pine Lane" },
                    { 2, 2, new DateTime(2023, 12, 25, 21, 13, 35, 945, DateTimeKind.Utc).AddTicks(8079), 2, 2, "Anytown", "USA", "12345", "123 Main Street" },
                    { 3, 4, new DateTime(2023, 12, 25, 21, 13, 35, 945, DateTimeKind.Utc).AddTicks(8080), 3, 3, "Sometown", "Canada", "67890", "456 Oak Avenue" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStatuses_Name",
                table: "OrderStatuses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
