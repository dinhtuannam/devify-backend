using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Devify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class databasev100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_categories",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    des = table.Column<string>(type: "text", nullable: false),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_languages",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    des = table.Column<string>(type: "text", nullable: false),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_languages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_levels",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    des = table.Column<string>(type: "text", nullable: false),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_levels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    displayName = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    image = table.Column<string>(type: "text", nullable: false),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false),
                    about = table.Column<string>(type: "text", nullable: false),
                    social = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    userid = table.Column<long>(type: "bigint", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.id);
                    table.ForeignKey(
                        name: "FK_Notifications_tb_users_userid",
                        column: x => x.userid,
                        principalTable: "tb_users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tb_courses",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    purchases = table.Column<long>(type: "bigint", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    des = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<string>(type: "text", nullable: false),
                    image = table.Column<string>(type: "text", nullable: false),
                    isactivated = table.Column<bool>(type: "boolean", nullable: false),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false),
                    userid = table.Column<long>(type: "bigint", nullable: true),
                    categoryid = table.Column<long>(type: "bigint", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_courses", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_courses_tb_categories_categoryid",
                        column: x => x.categoryid,
                        principalTable: "tb_categories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_tb_courses_tb_users_userid",
                        column: x => x.userid,
                        principalTable: "tb_users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tb_orders",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    des = table.Column<string>(type: "text", nullable: false),
                    total = table.Column<double>(type: "double precision", nullable: false),
                    userid = table.Column<long>(type: "bigint", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_orders_tb_users_userid",
                        column: x => x.userid,
                        principalTable: "tb_users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tb_token",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    accessToken = table.Column<string>(type: "text", nullable: false),
                    refreshToken = table.Column<string>(type: "text", nullable: false),
                    createTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    expiredTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    isExpired = table.Column<bool>(type: "boolean", nullable: false),
                    userid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_token", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_token_tb_users_userid",
                        column: x => x.userid,
                        principalTable: "tb_users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "SqlCourseSqlLanguage",
                columns: table => new
                {
                    coursesid = table.Column<long>(type: "bigint", nullable: false),
                    languagesid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SqlCourseSqlLanguage", x => new { x.coursesid, x.languagesid });
                    table.ForeignKey(
                        name: "FK_SqlCourseSqlLanguage_tb_courses_coursesid",
                        column: x => x.coursesid,
                        principalTable: "tb_courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SqlCourseSqlLanguage_tb_languages_languagesid",
                        column: x => x.languagesid,
                        principalTable: "tb_languages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SqlCourseSqlLevel",
                columns: table => new
                {
                    coursesid = table.Column<long>(type: "bigint", nullable: false),
                    levelsid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SqlCourseSqlLevel", x => new { x.coursesid, x.levelsid });
                    table.ForeignKey(
                        name: "FK_SqlCourseSqlLevel_tb_courses_coursesid",
                        column: x => x.coursesid,
                        principalTable: "tb_courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SqlCourseSqlLevel_tb_levels_levelsid",
                        column: x => x.levelsid,
                        principalTable: "tb_levels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_chapters",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    des = table.Column<string>(type: "text", nullable: false),
                    step = table.Column<int>(type: "integer", nullable: false),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false),
                    isactivated = table.Column<bool>(type: "boolean", nullable: false),
                    courseid = table.Column<long>(type: "bigint", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_chapters", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_chapters_tb_courses_courseid",
                        column: x => x.courseid,
                        principalTable: "tb_courses",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tb_detail_orders",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    orderid = table.Column<long>(type: "bigint", nullable: true),
                    courseid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_detail_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_detail_orders_tb_courses_courseid",
                        column: x => x.courseid,
                        principalTable: "tb_courses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_tb_detail_orders_tb_orders_orderid",
                        column: x => x.orderid,
                        principalTable: "tb_orders",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tb_lessons",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    des = table.Column<string>(type: "text", nullable: false),
                    step = table.Column<int>(type: "integer", nullable: false),
                    image = table.Column<string>(type: "text", nullable: false),
                    video = table.Column<string>(type: "text", nullable: false),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false),
                    isactivated = table.Column<bool>(type: "boolean", nullable: false),
                    Chapterid = table.Column<long>(type: "bigint", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_lessons", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_lessons_tb_chapters_Chapterid",
                        column: x => x.Chapterid,
                        principalTable: "tb_chapters",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tb_comments",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    content = table.Column<string>(type: "text", nullable: false),
                    parent = table.Column<long>(type: "bigint", nullable: false),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false),
                    lessonid = table.Column<long>(type: "bigint", nullable: true),
                    userid = table.Column<long>(type: "bigint", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_comments_tb_lessons_lessonid",
                        column: x => x.lessonid,
                        principalTable: "tb_lessons",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_tb_comments_tb_users_userid",
                        column: x => x.userid,
                        principalTable: "tb_users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_userid",
                table: "Notifications",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_SqlCourseSqlLanguage_languagesid",
                table: "SqlCourseSqlLanguage",
                column: "languagesid");

            migrationBuilder.CreateIndex(
                name: "IX_SqlCourseSqlLevel_levelsid",
                table: "SqlCourseSqlLevel",
                column: "levelsid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_chapters_courseid",
                table: "tb_chapters",
                column: "courseid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_comments_lessonid",
                table: "tb_comments",
                column: "lessonid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_comments_userid",
                table: "tb_comments",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_courses_categoryid",
                table: "tb_courses",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_courses_userid",
                table: "tb_courses",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_detail_orders_courseid",
                table: "tb_detail_orders",
                column: "courseid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_detail_orders_orderid",
                table: "tb_detail_orders",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_lessons_Chapterid",
                table: "tb_lessons",
                column: "Chapterid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_orders_userid",
                table: "tb_orders",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_token_userid",
                table: "tb_token",
                column: "userid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "SqlCourseSqlLanguage");

            migrationBuilder.DropTable(
                name: "SqlCourseSqlLevel");

            migrationBuilder.DropTable(
                name: "tb_comments");

            migrationBuilder.DropTable(
                name: "tb_detail_orders");

            migrationBuilder.DropTable(
                name: "tb_token");

            migrationBuilder.DropTable(
                name: "tb_languages");

            migrationBuilder.DropTable(
                name: "tb_levels");

            migrationBuilder.DropTable(
                name: "tb_lessons");

            migrationBuilder.DropTable(
                name: "tb_orders");

            migrationBuilder.DropTable(
                name: "tb_chapters");

            migrationBuilder.DropTable(
                name: "tb_courses");

            migrationBuilder.DropTable(
                name: "tb_categories");

            migrationBuilder.DropTable(
                name: "tb_users");
        }
    }
}
