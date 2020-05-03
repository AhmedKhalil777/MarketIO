using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketIO.MVC.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Product_Id", "BrandId", "CategoryId", "Description", "Evaluation", "Image", "InStock", "IsProductOfTheWeek", "P_Name", "Price", "Quantity" },
                values: new object[] { 2, 1, 1, "Awesome Laptop!", 0, "Mac.JPG", true, true, "Mac Book", 252.95m, 6 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Product_Id", "BrandId", "CategoryId", "Description", "Evaluation", "Image", "InStock", "IsProductOfTheWeek", "P_Name", "Price", "Quantity" },
                values: new object[] { 3, 3, 3, "Awesome Phone!", 0, "Phone.JPG", true, true, "IPhone11 Pro", 175.95m, 3 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Product_Id", "BrandId", "CategoryId", "Description", "Evaluation", "Image", "InStock", "IsProductOfTheWeek", "P_Name", "Price", "Quantity" },
                values: new object[] { 4, 3, 2, "Awesome TV!", 0, "TV.JPG", true, true, "Mac Tv", 202.95m, 6 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_Id",
                keyValue: 4);
        }
    }
}
