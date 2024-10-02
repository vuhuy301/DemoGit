using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BilliardShop.Migrations
{
    public partial class AddSaleColumnToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "sale",
                table: "Products",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sale",
                table: "Products");
        }
    }
}
