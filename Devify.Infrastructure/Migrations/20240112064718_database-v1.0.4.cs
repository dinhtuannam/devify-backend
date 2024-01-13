using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class databasev104 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isactivated",
                table: "tb_users",
                newName: "isbanned");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isbanned",
                table: "tb_users",
                newName: "isactivated");
        }
    }
}
