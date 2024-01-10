using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Devify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class databasev102 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SqlRoleid",
                table: "tb_users",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tb_roles",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    des = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_transactions",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    method = table.Column<string>(type: "text", nullable: false),
                    time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    amount = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_transactions", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_users_SqlRoleid",
                table: "tb_users",
                column: "SqlRoleid");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_users_tb_roles_SqlRoleid",
                table: "tb_users",
                column: "SqlRoleid",
                principalTable: "tb_roles",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_users_tb_roles_SqlRoleid",
                table: "tb_users");

            migrationBuilder.DropTable(
                name: "tb_roles");

            migrationBuilder.DropTable(
                name: "tb_transactions");

            migrationBuilder.DropIndex(
                name: "IX_tb_users_SqlRoleid",
                table: "tb_users");

            migrationBuilder.DropColumn(
                name: "SqlRoleid",
                table: "tb_users");
        }
    }
}
