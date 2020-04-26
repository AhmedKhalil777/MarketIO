using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketIO.MVC.Migrations
{
    public partial class AddInStockCategoryIdBrandIdProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_Brand_Id",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryCat_Id",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Brand_Id",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryCat_Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Brand_Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryCat_Id",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "InStock",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Brand_Id", "Brand_Logo", "Brand_Name" },
                values: new object[,]
                {
                    { 1, null, "Hp" },
                    { 2, null, "Toshiba" },
                    { 3, null, "Apple" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Cat_Id", "Cat_Image", "Cat_Name" },
                values: new object[,]
                {
                    { 1, null, "Laptops" },
                    { 2, null, "TVS" },
                    { 3, null, "Phones" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Product_Id", "BrandId", "CategoryId", "Description", "Evaluation", "Image", "InStock", "IsProductOfTheWeek", "P_Name", "Price", "Quantity" },
                values: new object[] { 1, 1, 1, "Awesome Laptop!", 0, "HP.PNG", true, true, "HP ProBook", 152.95m, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Brand_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Cat_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_BrandId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Brand_Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Brand_Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Cat_Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Cat_Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Brand_Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Cat_Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InStock",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Brand_Id",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryCat_Id",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Brand_Id",
                table: "Products",
                column: "Brand_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryCat_Id",
                table: "Products",
                column: "CategoryCat_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_Brand_Id",
                table: "Products",
                column: "Brand_Id",
                principalTable: "Brands",
                principalColumn: "Brand_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryCat_Id",
                table: "Products",
                column: "CategoryCat_Id",
                principalTable: "Categories",
                principalColumn: "Cat_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
