using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devify.Migrations
{
    /// <inheritdoc />
    public partial class addcreator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Creators",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Creators",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40053425-a60c-47b4-a3a5-38327dbe4d41", "AQAAAAIAAYagAAAAEJvDZPyj9b6xnhrLrELkwUpeXhYd0Q+cEfuVKCI5E8O6q5ZmUe+/wj5kxqfQYUnsZw==", "8ff7a342-c3a0-4f21-91a9-c12b894137d5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Creators");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Creators",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "546027fa-948c-46a2-864a-8b475c89cc06", "AQAAAAIAAYagAAAAEOFkfO3nFFveweBaayIwE8j18XKVjTWV22JeCuEd6YaYnlfJ6EPnVFzvpKj5cr+utA==", "90802fa2-fd94-406d-bf06-2bbe4d255c67" });
        }
    }
}
