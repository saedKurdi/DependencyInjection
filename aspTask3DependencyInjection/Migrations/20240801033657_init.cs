using Microsoft.EntityFrameworkCore.Migrations;

namespace aspTask3DependencyInjection.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FastFoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ccal = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FastFoods_Id", x => x.Id);
                    table.CheckConstraint("CK_FastFoods_Name", "LEN(Name) BETWEEN 3 AND 15");
                    table.CheckConstraint("CK_FastFoods_Price", "Price BETWEEN 1 AND 50");
                    table.CheckConstraint("CK_FastFoods_Discount", "Discount BETWEEN 0 AND 100");
                });

            migrationBuilder.InsertData(
                table: "FastFoods",
                columns: new[] { "Id", "Ccal", "Description", "Discount", "ImagePath", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 300.0, "Delicious beef burger", 5, "images/burger.jpg", "Burger", 12 },
                    { 2, 400.0, "Cheesy pizza", 20, "images/pizza.jpeg", "Pizza", 30 },
                    { 3, 100.0, "Crispy Fries", 4, "images/fries.jpeg", "Fries", 4 },
                    { 4, 200.0, "Turkish Pizza", 6, "images/lahmacun.jpeg", "Lahmacun", 4 }
                });

            migrationBuilder.InsertData(
                table: "FastFoods",
                columns: new[] { "Id", "Ccal", "Description", "ImagePath", "Name", "Price" },
                values: new object[] { 5, 300.0, "Turkish Donerrr", "images/doner.jpeg", "Doner", 3 });

            migrationBuilder.CreateIndex(
                name: "UK_FastFoods_Name",
                table: "FastFoods",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FastFoods");
        }
    }
}
