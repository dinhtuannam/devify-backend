using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devify.Migrations
{
    /// <inheritdoc />
    public partial class addcolumnimg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c8bb1dd-d1ee-44f5-8173-1bff4569f6be", "AQAAAAIAAYagAAAAEEocZeJ3fbeoJIbJYKB1xWWIr1e9gbi3TprMhD9s53yQs06SRFNAugawYcxT3qS4hQ==", "7c9b3372-90a2-44cf-9b4b-21328b452c41" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Courses");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c27c2526-88c2-43fc-b8ab-8d8cc9a288a1", "AQAAAAIAAYagAAAAEAzHqATcWBNdz4bQ36JU6Q7QCWOotJ6HuBp5+pMLphfqVe+ixkDvB982kg5K/QnbsA==", "0dd1815f-0e98-4815-b2e1-542a6bafca5b" });
        }
    }
}
