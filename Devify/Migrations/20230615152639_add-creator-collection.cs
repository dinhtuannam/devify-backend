using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devify.Migrations
{
    /// <inheritdoc />
    public partial class addcreatorcollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3283c96d-f1ba-44ab-95be-b568c7efe804", "AQAAAAIAAYagAAAAEIApG8TgX+NuminzcETUV6ZA/PZyxwTiziPAL+vL/1Rf1XKqTjUAc0uvX4E76+BrJQ==", "26b3d522-4553-472e-9f4c-df4109226aca" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40053425-a60c-47b4-a3a5-38327dbe4d41", "AQAAAAIAAYagAAAAEJvDZPyj9b6xnhrLrELkwUpeXhYd0Q+cEfuVKCI5E8O6q5ZmUe+/wj5kxqfQYUnsZw==", "8ff7a342-c3a0-4f21-91a9-c12b894137d5" });
        }
    }
}
