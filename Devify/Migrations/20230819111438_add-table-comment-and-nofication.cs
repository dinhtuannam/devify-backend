using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devify.Migrations
{
    /// <inheritdoc />
    public partial class addtablecommentandnofication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    LessonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nofications",
                columns: table => new
                {
                    NoficationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                name: "IX_Comments_LessonId",
                table: "Comments",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Nofications_UserId",
                table: "Nofications",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Nofications");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2e0d9b-74dd-4928-8c24-1a3156d9fc41",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2dbdf347-a0b8-40af-96f9-0566c649f3de", "AQAAAAIAAYagAAAAEPlJIcs9pqhKRLpQKmfnr+gExBYGmQXAzERcFWYGl5q9/YZhqKQre2MuurP3Tqdyug==", "eb516707-313c-42f1-9082-4e447ce5cd3f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f9f0d9e-67af-4a8d-9aa6-5f2270fc9fbb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "202fef7e-722d-48ac-a691-53bd6e436713", "AQAAAAIAAYagAAAAEDqLxL4qpy9fkSZNdY7rsuFaXCGJll073fu3pV3llDFCzL0gESrh+TkfQ/EceEdRoQ==", "729d3183-fc05-4ad9-87f6-6b8eb41e4399" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "51274390-9171-49dd-a3e7-6e23fbf327fb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "884b0024-63d0-4eea-a38b-23260a3f1891", "AQAAAAIAAYagAAAAEKJY3O8GItNOd9kx2INgEVrgpjUyL3/nOJlyimrh1RrCfaxEgh4bhgeVJe4ek2nF6g==", "32fce0f4-9233-42df-ab86-8f79f9229c81" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e6e4976-631d-46fb-91ea-11e70fb7087a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7333ea69-66be-48fd-b1b5-48852611ede9", "AQAAAAIAAYagAAAAELqNe+pIJB+CkVWGZEGJCsrhbpJsv4otbmWKVVzLaRjmo1FjHq9NkH6SQdnB48mf7g==", "31b3bee7-b206-4099-b4fd-1e31e98303a2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b4a17e1-4a1a-44e3-9a95-c2b59b7a7a4c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bda771c9-0d23-42b4-a344-5a871f5aad29", "AQAAAAIAAYagAAAAEJoEFtQbWmUgcKhSbbUfco9mkoFUlbnqUD6WWyfl173+bghpa6K2ci+ut6HbFO7Ogg==", "71a594c8-0710-4500-be4f-5de0c4ba3517" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b2eb0a3-7d3c-4671-8d16-30c69d20a7c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e7e9963-3ced-44ed-9ff9-69d73ba5ba1f", "AQAAAAIAAYagAAAAENuSo7nOJEJOWbQVQFpsG1nc/lR0Es3FP3GGmW+dzM0KG0u3MdcRJRcBmkL5X9ptrg==", "5c5e4daa-bb20-4758-b51f-ab5dc906539f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d9e03227-9b87-40b5-9c7b-3a8578b6c04c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf081cd1-3cec-4a27-a2f5-5fb41c342828", "AQAAAAIAAYagAAAAEH2N3BMXSO7Xg0F3M/y6icKSuFiU2YPidCAApI5bBEhztEVdbsCXdqca2mRXUGqRFg==", "a2a5d453-3708-4948-a5e8-15624f23d408" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0ed2b3d-2c72-4a84-bd60-1ff9a78ee084",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "156ac624-56da-4829-9cf9-44d515e80ddf", "AQAAAAIAAYagAAAAEKoJZpQkzyg2CJVKWTcE2LUFSW72kI2kyO225Dxg8sMvXJlX1s+7kAVg65GyhcoUoA==", "47e04ae9-aa0f-4833-b335-8aabc0aece7e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ad75bc4-4bae-40b3-a19a-8ce85099b736", "AQAAAAIAAYagAAAAEJ2RBRyPpVD+HnA2jmVyLOVwJ5ohgWjCaPvCvrc406R8zZXxVs46uA35aVOFbPeA1w==", "f0f16b74-80fa-43a8-be9f-95db012a0899" });
        }
    }
}
