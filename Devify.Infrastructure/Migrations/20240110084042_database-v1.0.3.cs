using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Devify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class databasev103 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_tb_users_userid",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_lessons_tb_chapters_Chapterid",
                table: "tb_lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_users_tb_roles_SqlRoleid",
                table: "tb_users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "tb_levels");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "tb_levels");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "tb_languages");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "tb_languages");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "tb_categories");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "tb_categories");

            migrationBuilder.RenameTable(
                name: "Notifications",
                newName: "tb_notifications");

            migrationBuilder.RenameColumn(
                name: "SqlRoleid",
                table: "tb_users",
                newName: "roleid");

            migrationBuilder.RenameIndex(
                name: "IX_tb_users_SqlRoleid",
                table: "tb_users",
                newName: "IX_tb_users_roleid");

            migrationBuilder.RenameColumn(
                name: "Chapterid",
                table: "tb_lessons",
                newName: "chapterid");

            migrationBuilder.RenameIndex(
                name: "IX_tb_lessons_Chapterid",
                table: "tb_lessons",
                newName: "IX_tb_lessons_chapterid");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_userid",
                table: "tb_notifications",
                newName: "IX_tb_notifications_userid");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "tb_users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "tb_users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isactivated",
                table: "tb_users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "discountid",
                table: "tb_orders",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "price",
                table: "tb_orders",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "sale",
                table: "tb_orders",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "issale",
                table: "tb_courses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "salePrice",
                table: "tb_courses",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_notifications",
                table: "tb_notifications",
                column: "id");

            migrationBuilder.CreateTable(
                name: "tb_discounts",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    des = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<double>(type: "double precision", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    minimun = table.Column<double>(type: "double precision", nullable: false),
                    isDelete = table.Column<bool>(type: "boolean", nullable: false),
                    expiredTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_discounts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_ratings",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    point = table.Column<int>(type: "integer", nullable: false),
                    isDelete = table.Column<bool>(type: "boolean", nullable: false),
                    userid = table.Column<long>(type: "bigint", nullable: true),
                    courseid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ratings", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_ratings_tb_courses_courseid",
                        column: x => x.courseid,
                        principalTable: "tb_courses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_tb_ratings_tb_users_userid",
                        column: x => x.userid,
                        principalTable: "tb_users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_orders_discountid",
                table: "tb_orders",
                column: "discountid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ratings_courseid",
                table: "tb_ratings",
                column: "courseid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ratings_userid",
                table: "tb_ratings",
                column: "userid");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_lessons_tb_chapters_chapterid",
                table: "tb_lessons",
                column: "chapterid",
                principalTable: "tb_chapters",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_notifications_tb_users_userid",
                table: "tb_notifications",
                column: "userid",
                principalTable: "tb_users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_orders_tb_discounts_discountid",
                table: "tb_orders",
                column: "discountid",
                principalTable: "tb_discounts",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_users_tb_roles_roleid",
                table: "tb_users",
                column: "roleid",
                principalTable: "tb_roles",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_lessons_tb_chapters_chapterid",
                table: "tb_lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_notifications_tb_users_userid",
                table: "tb_notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_orders_tb_discounts_discountid",
                table: "tb_orders");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_users_tb_roles_roleid",
                table: "tb_users");

            migrationBuilder.DropTable(
                name: "tb_discounts");

            migrationBuilder.DropTable(
                name: "tb_ratings");

            migrationBuilder.DropIndex(
                name: "IX_tb_orders_discountid",
                table: "tb_orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_notifications",
                table: "tb_notifications");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "tb_users");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "tb_users");

            migrationBuilder.DropColumn(
                name: "isactivated",
                table: "tb_users");

            migrationBuilder.DropColumn(
                name: "discountid",
                table: "tb_orders");

            migrationBuilder.DropColumn(
                name: "price",
                table: "tb_orders");

            migrationBuilder.DropColumn(
                name: "sale",
                table: "tb_orders");

            migrationBuilder.DropColumn(
                name: "issale",
                table: "tb_courses");

            migrationBuilder.DropColumn(
                name: "salePrice",
                table: "tb_courses");

            migrationBuilder.RenameTable(
                name: "tb_notifications",
                newName: "Notifications");

            migrationBuilder.RenameColumn(
                name: "roleid",
                table: "tb_users",
                newName: "SqlRoleid");

            migrationBuilder.RenameIndex(
                name: "IX_tb_users_roleid",
                table: "tb_users",
                newName: "IX_tb_users_SqlRoleid");

            migrationBuilder.RenameColumn(
                name: "chapterid",
                table: "tb_lessons",
                newName: "Chapterid");

            migrationBuilder.RenameIndex(
                name: "IX_tb_lessons_chapterid",
                table: "tb_lessons",
                newName: "IX_tb_lessons_Chapterid");

            migrationBuilder.RenameIndex(
                name: "IX_tb_notifications_userid",
                table: "Notifications",
                newName: "IX_Notifications_userid");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "tb_levels",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "tb_levels",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "tb_languages",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "tb_languages",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "tb_categories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "tb_categories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_tb_users_userid",
                table: "Notifications",
                column: "userid",
                principalTable: "tb_users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_lessons_tb_chapters_Chapterid",
                table: "tb_lessons",
                column: "Chapterid",
                principalTable: "tb_chapters",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_users_tb_roles_SqlRoleid",
                table: "tb_users",
                column: "SqlRoleid",
                principalTable: "tb_roles",
                principalColumn: "id");
        }
    }
}
