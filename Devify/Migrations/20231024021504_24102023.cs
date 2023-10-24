using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devify.Migrations
{
    /// <inheritdoc />
    public partial class _24102023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Video",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Creators",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                values: new object[] { "d2ff0855-2988-45d8-885a-cb2dc9b8b5d0", "AQAAAAIAAYagAAAAENZv56h33AVhndOvH95SISTt8FpO13IYkzKGp/toka4B+x2Spj+bHMPXlE42aA+w8Q==", "4dae6c66-c105-46a3-967e-bdf1dc34a8dc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f9f0d9e-67af-4a8d-9aa6-5f2270fc9fbb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e830c6c-0287-412f-b58c-001a0a62f42c", "AQAAAAIAAYagAAAAEJjwax+aZHF+o9q3DugayodzRleweiqYKmAlqh2dfksuyZd0H+p/m9InnQKVXHvVfw==", "f4dd9a13-76eb-4634-adc8-652c74f08ea9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "51274390-9171-49dd-a3e7-6e23fbf327fb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0669c87-74de-4a99-8ddc-a2456aa59ac1", "AQAAAAIAAYagAAAAEMxTpx5CZdNhZZR0xrJ1aPgRkL9IzsHOXeBI75tyQHhwwozyPtzG7JNasodUJcqzxg==", "10a57b28-7d55-4449-bbcc-5bd49d8eabdb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e6e4976-631d-46fb-91ea-11e70fb7087a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05eae9d6-3e89-49e7-bc52-161827666f97", "AQAAAAIAAYagAAAAEMpBuhxXPM8EnrSg07XeD782/RLtTm7l0Gje3sGSxtZHUkJQQT1qy5Zo0E6bmIVZzA==", "56295ac2-636d-4b6d-b406-863e2549ccf5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b4a17e1-4a1a-44e3-9a95-c2b59b7a7a4c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39d10025-b9e5-4fef-98fa-273adea56f79", "AQAAAAIAAYagAAAAEAZrtRJneOKVmZJ+/d3+gLHEVnrh/EtCTEIfQiHG2k87gqlAv0LtEg/cxFUKYtjFlw==", "96f7c687-6fb6-47eb-a8e4-8c06affac188" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b2eb0a3-7d3c-4671-8d16-30c69d20a7c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a0bf3fa-7172-4722-a2ea-15730a63d0d5", "AQAAAAIAAYagAAAAEGlwhaw9oe3Q6XLvz11cyt+UjaE+YRzzmdmEQO+0k8vLv3PCPeZQTK/cj6g/nD0HGA==", "c91dc6ac-eda4-4ae9-876a-b62ceead4857" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d9e03227-9b87-40b5-9c7b-3a8578b6c04c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "215fd385-7faa-4304-a5c8-23cc828e350b", "AQAAAAIAAYagAAAAEJ7fipmCwB65TKdhaWNdW4LHRkumqreDw+jTtWq3gN2i9NHoLmgKM8T3rdlkUjXLog==", "ab06a85e-2217-4e89-8699-dc3bcee7b152" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0ed2b3d-2c72-4a84-bd60-1ff9a78ee084",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9f1372e-2e31-4d82-9c5f-2457e9879513", "AQAAAAIAAYagAAAAEEeSzQ+1uZ3TsGEfBBjmxO5cYOuR2YHgigoEfeQYwVrC3k8Xq3Xe7lFMBaLLtVOzhQ==", "d51f7846-eab0-4ef5-a101-40821c80404f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b794aa62-49da-4045-9c43-2b048da2ba24", "AQAAAAIAAYagAAAAEMc7mKj2GuhMdUUrGahZkca/SbuaYIUjA75qvOcnOeYc49kx9j/Ovba9Ojgx6XVj+Q==", "6335ba2b-51f6-4a34-9e34-c65f1df71f4a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Video",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Creators",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                values: new object[] { "aa396d15-c739-42e3-af31-cb9b3033e6ac", "AQAAAAIAAYagAAAAEJkqrp9PR7wIl5cTWGvoLbJgCwhZgMt/6WXFvcLsCWseaM7+z4gCaaNqvJjiZtzjjQ==", "4511a6d5-4377-45a2-95b3-eaf045855abf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f9f0d9e-67af-4a8d-9aa6-5f2270fc9fbb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4fcba4c-4b0a-403f-871f-05c4c4fff820", "AQAAAAIAAYagAAAAEOrsYicgJtx+7P1DUQGqBfutZ5pUZ1cSfhkB1/B1JCmYBuwwA8AbzgGYgyaxsgwDzQ==", "afe279f8-3c52-4e05-9d28-70b17e87e1c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "51274390-9171-49dd-a3e7-6e23fbf327fb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7edf2ff-0534-43e3-8203-b26092ee8d0f", "AQAAAAIAAYagAAAAEPfA6nX2XhiSFfh1d8vFTKpb4aov2XYUx096TWs3O8LBbQVb+3yt0Zh7kysc/rod3A==", "67415481-1174-4d1e-bfee-d2cc247a64c9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e6e4976-631d-46fb-91ea-11e70fb7087a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "030eff35-9f80-471c-aa8d-368e6d919c89", "AQAAAAIAAYagAAAAEC6IY+/wkHKPmLj9iJNfArWga61wVX1AmhtrFK7uk4wBSPgJdafN7g8lIIZjFFfAcw==", "22607e14-9ebe-4e28-9c91-863589bb14f0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b4a17e1-4a1a-44e3-9a95-c2b59b7a7a4c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b381d2f0-364e-4bb0-88c1-985763e5a0d9", "AQAAAAIAAYagAAAAEE9XbB1sqjrRL2CBDDBjaVLWrjobzxvRgljUg0FM/HzKtaYhpzHx5G17cF2yyoJXKQ==", "3e581020-28e0-464d-9b90-a027049d3c8c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b2eb0a3-7d3c-4671-8d16-30c69d20a7c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6be2328f-0449-42ce-aaf5-779b6ed92bd0", "AQAAAAIAAYagAAAAEH93eakubi3Iq9dO6z807y4BqsZCmPCe0u9RJBXBrkZ8O/hjpamXW/Rf+Y4TOsuX9w==", "12c7ee2c-0590-491d-bd18-8625fc64447b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d9e03227-9b87-40b5-9c7b-3a8578b6c04c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6b11d50-5c62-4b68-ac1f-1e19fd41c456", "AQAAAAIAAYagAAAAEPhCHmGtY7vonm3rFIwBydkP+MXwkIJu/zbtbT0FXzb7Uf+TavpO5el0n2ifBffoYw==", "3853da3b-bbb3-4714-90c2-ed3995770f04" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0ed2b3d-2c72-4a84-bd60-1ff9a78ee084",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d7d2033-830d-4ef7-b15e-3cabc3019cb5", "AQAAAAIAAYagAAAAEIkvxvGIi1oaFnhRDhBsRe6I4/ffWC//kpmAB/M9Mz6y32xppqcflvlmt1Fj8b6iog==", "175b1d3f-42e6-45cf-a21f-d728342a006b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f668b55e-db4e-460b-b138-01004f4751bd", "AQAAAAIAAYagAAAAEPdWGyuNKkK1Nkplb3js+frJ+VU2g4wKnBsWRMlmERfkJVSzuJjbvIAYNqHi386faA==", "7ab92b7c-77dd-4c4b-8ff1-80a1cce6c3d5" });
        }
    }
}
