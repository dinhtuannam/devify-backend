using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Devify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class database_v106 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_carts",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    amount = table.Column<double>(type: "double precision", nullable: false),
                    discount_price = table.Column<double>(type: "double precision", nullable: false),
                    total = table.Column<double>(type: "double precision", nullable: false),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    discountid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_carts", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_carts_tb_discounts_discountid",
                        column: x => x.discountid,
                        principalTable: "tb_discounts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_tb_carts_tb_users_userId",
                        column: x => x.userId,
                        principalTable: "tb_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SqlCartSqlCourse",
                columns: table => new
                {
                    cartsid = table.Column<long>(type: "bigint", nullable: false),
                    coursesid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SqlCartSqlCourse", x => new { x.cartsid, x.coursesid });
                    table.ForeignKey(
                        name: "FK_SqlCartSqlCourse_tb_carts_cartsid",
                        column: x => x.cartsid,
                        principalTable: "tb_carts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SqlCartSqlCourse_tb_courses_coursesid",
                        column: x => x.coursesid,
                        principalTable: "tb_courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SqlCartSqlCourse_coursesid",
                table: "SqlCartSqlCourse",
                column: "coursesid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_carts_discountid",
                table: "tb_carts",
                column: "discountid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_carts_userId",
                table: "tb_carts",
                column: "userId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SqlCartSqlCourse");

            migrationBuilder.DropTable(
                name: "tb_carts");
        }
    }
}
