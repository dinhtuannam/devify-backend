using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devify.Migrations
{
    /// <inheritdoc />
    public partial class updatenotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nofications");

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.CreateTable(
                name: "Nofications",
                columns: table => new
                {
                    NoficationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nofications", x => x.NoficationId);
                    table.ForeignKey(
                        name: "FK_Nofications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2e0d9b-74dd-4928-8c24-1a3156d9fc41",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f560a1f-b328-4590-bb58-2c9a2011cba2", "AQAAAAIAAYagAAAAEFgbxxOgCUVg//QKdRk8tNAkvVoNic8TuimIvCe8LlN//c8pw1epsd10XeshxVCpLg==", "3c6b2dfe-0936-426f-b5fe-8b9a45f6d96d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f9f0d9e-67af-4a8d-9aa6-5f2270fc9fbb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9136c6d3-9496-444f-828b-fdfc9769f4d5", "AQAAAAIAAYagAAAAEBafF6vePta2QWmDaYSfHBrxaM47mQUV0yBqtmqj+0mYNk5NHS/serGVYzgQcQBBpw==", "8d13b907-ddb8-437f-b2dd-72ec5051e8bc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "51274390-9171-49dd-a3e7-6e23fbf327fb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0baa95d3-8f56-454c-a5b0-a142ef76df54", "AQAAAAIAAYagAAAAEIkniRt1BDq1aaGdirr5HGbhOM3KumAdZkFyjBAgbPCitkSx+k3X4qGrC83nsG48UQ==", "aac9092e-8963-4def-bc51-1b2fa0404fab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e6e4976-631d-46fb-91ea-11e70fb7087a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da82b2f0-1a5c-4cc8-b1bd-0d8f08394447", "AQAAAAIAAYagAAAAEO/hJgVW6yCGD2HN5wlQasB8KR86kEL0w1XT1pjtQ2SKnLXtRDwmUViatO44GaoydQ==", "cd389c67-86a8-44b2-8b9f-d7cea4729c4e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b4a17e1-4a1a-44e3-9a95-c2b59b7a7a4c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8216ae7b-e1da-4ffc-9852-68c5ffaaff48", "AQAAAAIAAYagAAAAEALZZmaP2Rs0Z9JOQLh7VWWikGdpoa+lXXDimIS0y/sOEB0tJqIpaoCcEo4d1k2COQ==", "dca5fcb4-8508-47bc-9328-aa44522ab409" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b2eb0a3-7d3c-4671-8d16-30c69d20a7c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "caee33f5-7fe9-4dce-8862-a7c951f5e2c2", "AQAAAAIAAYagAAAAEGO+z+YsKcH3P/mYhcsba/mzL5yR8zJqSSKIpKum93lExwEC2WFFl4Mty98jI38oqA==", "299b0f55-819e-4d6a-ba85-7b8ddb5fe653" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d9e03227-9b87-40b5-9c7b-3a8578b6c04c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a8b5f74-d4bf-4178-b541-6f6f7ec75841", "AQAAAAIAAYagAAAAEEvepv/4pXdnYD4eNd3EInY4ILT/0IE+o8KA7Rj8UmsxwTmD505GYWBWgXHnxHnZCw==", "f6814084-5eea-46c8-97b9-25e68a6db201" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0ed2b3d-2c72-4a84-bd60-1ff9a78ee084",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "046e264d-3876-450e-8495-4c9208dd2090", "AQAAAAIAAYagAAAAEMM9Fz9HxsI2gWpcR1yuJnItmIVp485sOk3GJ4GZBDLya0P9cf0TofV22X/4H/EJ4g==", "00cb5cd3-e603-446f-9971-6f8ab8956bc2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cff7ca89-d41f-497d-aec4-cecbc3a85380", "AQAAAAIAAYagAAAAENGtZcdNZDI47c6OEVh2XODIW37Bo/dI8h3NBvbThCfBxPA5ykAlEpS2rQFbEJ9Fzw==", "25eccf72-6e6b-4233-8f32-a8267d16b779" });

            migrationBuilder.CreateIndex(
                name: "IX_Nofications_UserId",
                table: "Nofications",
                column: "UserId");
        }
    }
}
