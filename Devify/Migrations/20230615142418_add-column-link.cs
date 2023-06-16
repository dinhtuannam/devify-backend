using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devify.Migrations
{
    /// <inheritdoc />
    public partial class addcolumnlink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_AccountId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_AccountId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Courses");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "Courses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Creators",
                columns: table => new
                {
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creators", x => x.CreatorId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "546027fa-948c-46a2-864a-8b475c89cc06", "AQAAAAIAAYagAAAAEOFkfO3nFFveweBaayIwE8j18XKVjTWV22JeCuEd6YaYnlfJ6EPnVFzvpKj5cr+utA==", "90802fa2-fd94-406d-bf06-2bbe4d255c67" });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CreatorId",
                table: "Courses",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Creators_CreatorId",
                table: "Courses",
                column: "CreatorId",
                principalTable: "Creators",
                principalColumn: "CreatorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Creators_CreatorId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "Creators");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CreatorId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c8bb1dd-d1ee-44f5-8173-1bff4569f6be", "AQAAAAIAAYagAAAAEEocZeJ3fbeoJIbJYKB1xWWIr1e9gbi3TprMhD9s53yQs06SRFNAugawYcxT3qS4hQ==", "7c9b3372-90a2-44cf-9b4b-21328b452c41" });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AccountId",
                table: "Courses",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_AccountId",
                table: "Courses",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
