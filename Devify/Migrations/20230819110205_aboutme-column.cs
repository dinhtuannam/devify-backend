using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devify.Migrations
{
    /// <inheritdoc />
    public partial class aboutmecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutMe",
                table: "Creators",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Step",
                table: "Chapters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Chapters",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Chapters",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Categories",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutMe",
                table: "Creators");

            migrationBuilder.AlterColumn<int>(
                name: "Step",
                table: "Chapters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Chapters",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Chapters",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2e0d9b-74dd-4928-8c24-1a3156d9fc41",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd43fd8f-54c7-4216-8f5d-1973159c7f50", "AQAAAAIAAYagAAAAEKtRSz0q6kW5p+nUyzMoEXOQ09YUVKue40kmIWA2XJCymcLtKsLY/GL1w+owOTuNKA==", "28ca1fb0-1278-4df8-8e34-0089f703ed4b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f9f0d9e-67af-4a8d-9aa6-5f2270fc9fbb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8920d9d4-0e22-4f19-b52d-f62094f59548", "AQAAAAIAAYagAAAAEI9EIhqr7LBQEPwPiZD6AIxeVKtSicj/Fgg6lTjfAsb6g2wAbXWwu5R3cfeILvUcBQ==", "42cc92ee-84b5-4585-b1c3-34c2ddfc5d50" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "51274390-9171-49dd-a3e7-6e23fbf327fb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f211c8f2-8d8b-40f5-9e35-5e7ac604f2f1", "AQAAAAIAAYagAAAAECGpQdxA8DaNMBiyMt743EuE3EOlSjB9Vz8vQA1IwdmLej3Rw8ZFVPTcYq1DBx6M0w==", "5ce119a6-cece-4ff6-b7f0-0d930e059c62" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e6e4976-631d-46fb-91ea-11e70fb7087a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f7de113-3ecd-4a5f-b468-661da55942d3", "AQAAAAIAAYagAAAAEBQ9jBqrO8HfMWd25IezX600aJV6Y/fWxGnEWMMIhwgwhsG3Kbk635z4KZBZjT2BoA==", "9ebd06f4-1610-41a7-80ec-49037ba8b372" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b4a17e1-4a1a-44e3-9a95-c2b59b7a7a4c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e022434-40cd-4d35-bd5d-8bd80b93712c", "AQAAAAIAAYagAAAAEM8cWmgEdDgDHQWdcLrk4qeJDB3CD+F/WbK3nY3MY97ay2tSZ6VRBRbzdqW0jLAfNw==", "79010bef-25fc-41fe-85bb-181ee405c3ce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b2eb0a3-7d3c-4671-8d16-30c69d20a7c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be4b676c-e557-4cd0-ae05-4003fc81c697", "AQAAAAIAAYagAAAAEGgFiuuhBjvSz6OqFiP68nNWc7Ne0+z3NwqwYnQIh+wqvQ11+0mSuC8NNc9mxXhjIQ==", "6e07d949-2c44-43c1-9c1b-d11096aac18e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d9e03227-9b87-40b5-9c7b-3a8578b6c04c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e67c1959-a465-463b-a273-98ed8bc5ae7a", "AQAAAAIAAYagAAAAEIIGOWmpIGlomcAmWv4XHqKwhYcjurbwA7bcIzm+8oAXdpmvGwgoFOt8MIr1eo7I3w==", "00ca905c-ec35-4191-ae4c-e26321ab6ffe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0ed2b3d-2c72-4a84-bd60-1ff9a78ee084",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d34809b1-eb72-49d5-a296-fa52d4b1c237", "AQAAAAIAAYagAAAAEJvVXq301Om/zalAsJsko9ommND80RDlHHKhndLwwwu2GKKShmCDwhz9f1GTaHi1zg==", "975367c2-375e-41b9-8464-5b41aab5862b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fae84a33-6b34-4027-a8a3-04fa62211b92", "AQAAAAIAAYagAAAAEEvEMAYnczTVzrylTrN2LTH0EuBdRg0DH4goDgxkYA4BHMLbkaWNLEVP7X7p57R7PA==", "74a4575f-ab7d-49c5-8017-ecbfcd0c1b49" });
        }
    }
}
