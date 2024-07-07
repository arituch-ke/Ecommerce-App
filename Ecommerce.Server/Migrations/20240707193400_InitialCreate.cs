using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DiscountedPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false),
                    RatingCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Vendor = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SKUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    InStock = table.Column<bool>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SKUs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SKUs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "CreatedAt", "Description", "DiscountedPrice", "ImageUrl", "Name", "OriginalPrice", "Rating", "RatingCount", "UpdatedAt", "Vendor" },
                values: new object[,]
                {
                    { 1, "Electronics", new DateTime(2024, 7, 8, 2, 34, 0, 29, DateTimeKind.Local).AddTicks(4079), "High-quality portable speaker", 39.00m, "https://cdn5.425degree.com/media/amasty/webp/wysiwyg/2020/07/Air_by_MPOW_X51J/BnO_A1_Gen2/Beosound_a1_black_hero_jpg.webp", "Beoplay A1", 57.00m, 5, 10, new DateTime(2024, 7, 8, 2, 34, 0, 29, DateTimeKind.Local).AddTicks(4088), "Bang & Olufsen" },
                    { 2, "Furniture", new DateTime(2024, 7, 8, 2, 34, 0, 29, DateTimeKind.Local).AddTicks(4091), "Comfortable and stylish chair", 40.00m, "https://artisan-production.ams3.cdn.digitaloceanspaces.com/neva_chair_inspiration_8_6dd1b35090.png", "Artisan Chair", 48.00m, 4, 8, new DateTime(2024, 7, 8, 2, 34, 0, 29, DateTimeKind.Local).AddTicks(4091), "Artisan" },
                    { 3, "Furniture", new DateTime(2024, 7, 8, 2, 34, 0, 29, DateTimeKind.Local).AddTicks(4093), "Elegant and relaxing hanging chair", 89.00m, "https://sika-design.com/cdn/shop/products/Hanging_Egg_stand_4957_1200x.jpg?v=1648003559", "Hanging Egg Chair", 99.00m, 5, 12, new DateTime(2024, 7, 8, 2, 34, 0, 29, DateTimeKind.Local).AddTicks(4094), "Egg Chairs" },
                    { 4, "Lighting", new DateTime(2024, 7, 8, 2, 34, 0, 29, DateTimeKind.Local).AddTicks(4096), "Modern pendant lamp with sleek design", 140.00m, "https://www.macomaitaly.com/33163-large_default/hubert-pendant-lamp-audo-.jpg", "Hubert Pendant Lamp", 149.00m, 4, 6, new DateTime(2024, 7, 8, 2, 34, 0, 29, DateTimeKind.Local).AddTicks(4096), "Lighting" },
                    { 5, "Toys", new DateTime(2024, 7, 8, 2, 34, 0, 29, DateTimeKind.Local).AddTicks(4098), "Classic rocking horse for children", 135.00m, "https://www.designboom.com/wp-content/dbsub/401760/2017-08-17/img_1_1502954593_09c46de59d5651a30e2240ed15335b13.jpg", "Iconic Rocking Horse", 150.00m, 5, 5, new DateTime(2024, 7, 8, 2, 34, 0, 29, DateTimeKind.Local).AddTicks(4099), "Toys" },
                    { 6, "Furniture", new DateTime(2024, 7, 8, 2, 34, 0, 29, DateTimeKind.Local).AddTicks(4101), "Stackable and versatile chair", 250.00m, "https://www.eustischair.com/wp-content/uploads/2019/04/Ivy-League-Stackable-M.jpg", "League Stack Chair", 290.00m, 4, 9, new DateTime(2024, 7, 8, 2, 34, 0, 29, DateTimeKind.Local).AddTicks(4102), "League" },
                    { 7, "Home Essentials", new DateTime(2024, 7, 8, 2, 34, 0, 29, DateTimeKind.Local).AddTicks(4104), "Durable and stylish laundry baskets", 40.00m, "https://www.ikea.com/th/en/images/products/tolkning-laundry-basket-handmade-willow__1098731_pe865503_s5.jpg?f=s", "Laundry Baskets", 45.00m, 4, 7, new DateTime(2024, 7, 8, 2, 34, 0, 29, DateTimeKind.Local).AddTicks(4105), "Home Essentials" },
                    { 8, "Lighting", new DateTime(2024, 7, 8, 2, 34, 0, 29, DateTimeKind.Local).AddTicks(4132), "Unique table lamp with mug design", 79.00m, "https://www.midj.com/images/uploads/products/_xl/mug-table-midj.jpg", "Mug Table Lamp", 89.00m, 5, 11, new DateTime(2024, 7, 8, 2, 34, 0, 29, DateTimeKind.Local).AddTicks(4133), "Lighting" }
                });

            migrationBuilder.InsertData(
                table: "SKUs",
                columns: new[] { "Id", "Code", "InStock", "ProductId" },
                values: new object[,]
                {
                    { 1, "B&O-A1-001", true, 1 },
                    { 2, "B&O-A1-002", false, 1 },
                    { 3, "ART-CHAIR-001", true, 2 },
                    { 4, "EGG-CHAIR-001", true, 3 },
                    { 5, "EGG-CHAIR-002", true, 3 },
                    { 6, "HUB-LAMP-001", false, 4 },
                    { 7, "TOY-HORSE-001", true, 5 },
                    { 8, "LEA-CHAIR-001", true, 6 },
                    { 9, "HOME-BASKET-001", true, 7 },
                    { 10, "LAMP-MUG-001", true, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SKUs_ProductId",
                table: "SKUs",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SKUs");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
