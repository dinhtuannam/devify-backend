using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class database_v107 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "amount",
                table: "tb_carts");

            migrationBuilder.DropColumn(
                name: "discount_price",
                table: "tb_carts");

            migrationBuilder.DropColumn(
                name: "total",
                table: "tb_carts");

            migrationBuilder.RenameColumn(
                name: "minimun",
                table: "tb_discounts",
                newName: "minimum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "minimum",
                table: "tb_discounts",
                newName: "minimun");

            migrationBuilder.AddColumn<double>(
                name: "amount",
                table: "tb_carts",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "discount_price",
                table: "tb_carts",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "total",
                table: "tb_carts",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
