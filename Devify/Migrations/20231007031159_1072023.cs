using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devify.Migrations
{
    /// <inheritdoc />
    public partial class _1072023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_AspNetUsers_AccountId",
                table: "RefreshTokens");

            migrationBuilder.AlterColumn<string>(
                name: "AccountId",
                table: "RefreshTokens",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2e0d9b-74dd-4928-8c24-1a3156d9fc41",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2e03f9a-b734-4df8-8769-034958db8e82", "AQAAAAIAAYagAAAAEDbP8FJ1a2Qv5hB4RgXukAI1+VdhtG7WfpWp8izdmluhN2x/i/pyJYqWUuz9uxk79A==", "ed3586c4-9659-4b43-8291-bb01d2e1142b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f9f0d9e-67af-4a8d-9aa6-5f2270fc9fbb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a8491fc-b280-4e12-92d6-e8ea27181e32", "AQAAAAIAAYagAAAAEMXOa9ZQXnmXuQWa2c1MD5hU5cbr75YrIllND16kzGgODraurgbXKMd8+uXHulX28Q==", "748b0493-e353-4f64-ab04-191862a0c3ac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "51274390-9171-49dd-a3e7-6e23fbf327fb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26dcc454-208f-46fd-b602-53e865aff1e1", "AQAAAAIAAYagAAAAEKziBNfWwI8pPXGWCtGoRb41qRoHg6Z4+aRjoLR6z3JlkElPs13XkeR67IDfXCa0VQ==", "4e3aa393-2f3f-4f31-b2b9-cc8b54e83927" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e6e4976-631d-46fb-91ea-11e70fb7087a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb6fcd47-9e77-46af-becf-235b688bac6e", "AQAAAAIAAYagAAAAEEUSEX6NWYLlP1hx+vaVUHEGvBWS1kugzLnI6Sdc2C5tt18nxPGPB14+jJMRzqHf7g==", "862b54c1-c19c-422c-9b79-e68dbd9c8292" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b4a17e1-4a1a-44e3-9a95-c2b59b7a7a4c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6bbf4f8e-1d8c-4699-8b82-a9652e587630", "AQAAAAIAAYagAAAAEJAYzFFOafD+2yUA7q0ccziRKQGHl7ylTSwpNmeVwanwGHsRMF4iXsm/DxprftwGhg==", "a9506f2c-bf9e-49b9-b00e-457fd50d8e4a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b2eb0a3-7d3c-4671-8d16-30c69d20a7c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "721d327b-2d58-4eb7-ad5d-f09d4c385593", "AQAAAAIAAYagAAAAEIUh1oglwCoRPeAJCWMv/6x1GJdJA+gYXv4xtOwdbwxCTf/uMgSb4aYoUFrph7y4aQ==", "4ad13aed-1c32-4b57-b6c7-38e74c088a0e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d9e03227-9b87-40b5-9c7b-3a8578b6c04c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73e4e58b-9da2-45c3-9bd3-5bd2cdbadb2d", "AQAAAAIAAYagAAAAEBpwdRGx8wdaYXoDTc9IGg+iX+nS8x5yWdk0SmUIy8xcLHRSWAaxyvZd2oOi15X2Sw==", "512282a0-fd88-4c7b-b806-9abc8d78e4f6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0ed2b3d-2c72-4a84-bd60-1ff9a78ee084",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9cd6004-18d1-4866-b362-d4f5a0b43e2d", "AQAAAAIAAYagAAAAEPDRpsXvmRWSCWBXUg8zxM1+1Z0uMVjEJVJGk+6lUIMH7u4/wXZo2HstTxgqp3otqA==", "b09a0b2d-721f-470b-a36e-d3dedea95f38" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cacfd63-257e-425a-b5b5-6d0b3479682a", "AQAAAAIAAYagAAAAEBvcYdxMbNvW6GrbB06qvsmPwac9Pgaizc75yBZkQYgARY5VGg0+KLUXHqFVzXsN4A==", "38e49da7-0f26-442d-8ef8-f0dbef05d403" });

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_AspNetUsers_AccountId",
                table: "RefreshTokens",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_AspNetUsers_AccountId",
                table: "RefreshTokens");

            migrationBuilder.AlterColumn<string>(
                name: "AccountId",
                table: "RefreshTokens",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2e0d9b-74dd-4928-8c24-1a3156d9fc41",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "862bdd7d-9dc4-4c47-9db1-874f1008a0b8", "AQAAAAIAAYagAAAAEKRvFuMVvd9DlvoTtFgBVKPeqA96CR9cDWZqsCQyBUmAvLkguFDdLqg1NQGd1Wllog==", "5635ed8b-631b-413d-b597-7be84c83b5b5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f9f0d9e-67af-4a8d-9aa6-5f2270fc9fbb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c424cd5d-5d1b-4345-85fc-0e88c146a696", "AQAAAAIAAYagAAAAEANkF4em45fwqkg0A+Zl6SsnYnIirJ7oA6eoiLu8YNvbyhp0U/YlzjUKOVFVyUzntQ==", "76302c85-860e-47ca-8e7b-842a0a06ef2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "51274390-9171-49dd-a3e7-6e23fbf327fb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b683040e-ced0-42e6-b09b-711ea55b9e8d", "AQAAAAIAAYagAAAAEL1bLm4A0HkIKGbRNVk5+YrU7X4dGbcNyNhEIc8sTrRbqvU7YyvH0sxVZMcicgeXDQ==", "53e6415b-f7b9-460d-987b-56d4ea2f4c84" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e6e4976-631d-46fb-91ea-11e70fb7087a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f1d965b-53d1-451b-94d1-b6b2a4b44613", "AQAAAAIAAYagAAAAENiYPq5hTaBYekpJdV8NlhsyaFS6kEWAcMNd8ckIXz8HDTjwdcF2641fZ652xT28ZA==", "7efd3941-a3de-4fcd-a51f-b60ed5192796" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b4a17e1-4a1a-44e3-9a95-c2b59b7a7a4c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5fed7386-9ab4-4e81-b813-3486fd5483a1", "AQAAAAIAAYagAAAAEFXCt/FWqoD6dhZroYuit3IP+IQ4YSjRb7uc96MZ2iWfhcfYwGljsySyC8nYmViNDQ==", "e4b4216a-b188-4587-a8cf-1296eb4df876" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b2eb0a3-7d3c-4671-8d16-30c69d20a7c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0eb91f98-8e67-473c-8439-a7a8c711b2c6", "AQAAAAIAAYagAAAAENoH1IfGKUFyFaH69Zl61yG6uWaESmXJbuZEy3X87Zmzd9nJjOcEoRwDikkKsSao3A==", "8dba842f-59fd-4471-ad4b-4482b0ff6346" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d9e03227-9b87-40b5-9c7b-3a8578b6c04c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae212ef5-4439-41b4-904f-2499e174564f", "AQAAAAIAAYagAAAAEBbtBFgfVQGiaYSbcdtgZkSciQlUXWUq6u33xdpPyI/Tpfl8nz9BvZ4riXqDV3NhGA==", "23d2c130-8c8a-4292-b158-7521c27e9595" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0ed2b3d-2c72-4a84-bd60-1ff9a78ee084",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f9b548c-8106-46c6-a5c2-03bb8dd3b01e", "AQAAAAIAAYagAAAAEAwZIxOBtwLAwSXzKn1aVJxT3rSO/4TXxOA3JsUVE/Pm/4ZkuwWh5ksBUQMjbneI7Q==", "181e160b-311e-4576-a1ec-9805c261994b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51328979-f484-4dda-b757-1374c68ac4b4", "AQAAAAIAAYagAAAAEFLuJfF4lWyPzqYqkRcRARLwqTgoSvf6PubJU7IcJlu2hzm0qg+xS/djpsVCRJLtVg==", "0ed1f883-10e4-44fc-8099-beac331ccda3" });

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_AspNetUsers_AccountId",
                table: "RefreshTokens",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
