using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devify.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Step",
                table: "Lessons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Step",
                table: "Chapters",
                type: "int",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Step",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Step",
                table: "Chapters");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2e0d9b-74dd-4928-8c24-1a3156d9fc41",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57b0ef55-28b7-422b-847e-f4a5b98fdf63", "AQAAAAIAAYagAAAAELp206utszoUhGx/rocc98Uf7xPs1ePUmYKbyel1TklnK0pnbBAE4dsjngOJvlDFeA==", "39cebaee-2b38-4f20-998f-ef565c1adea3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f9f0d9e-67af-4a8d-9aa6-5f2270fc9fbb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7b8a0d3-249f-4b09-9c1e-49bd91f33ef2", "AQAAAAIAAYagAAAAEOeIRGziXV/4PR/sytU+sEqC21LoiYRIH/TaPCGa7ITW4Bm8HBf4TtGIwORGj02vWg==", "82c08705-8e20-4eb7-a86b-66a3d4d61b17" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "51274390-9171-49dd-a3e7-6e23fbf327fb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "270200ff-e046-4800-956a-6b209efb48e5", "AQAAAAIAAYagAAAAEH8tHevHji2RJzJhIWSKusafOVC6ogaO7yx1jQjuWNGEiQQLTcafLRHmWoIN3J7JNw==", "7cf5ef62-5858-44d7-a06c-db619cb67c94" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e6e4976-631d-46fb-91ea-11e70fb7087a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1733fe1d-dccf-4f0c-ae69-324a6727f58e", "AQAAAAIAAYagAAAAEPSnVZxKcV2/OKFgaYVkjt+OLxxWd9qfkN1WUw3G4H4xrXiXvBRzlxGddequvQhqvQ==", "a4a32583-0490-4c54-95c5-f5b7c4ead7f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b4a17e1-4a1a-44e3-9a95-c2b59b7a7a4c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b40119e2-e977-4e63-a495-f305daccb44f", "AQAAAAIAAYagAAAAEGZvI5UBMDFFf0ZHqynV0a/HUA4lySIFwTXm1u93/8tyzUGJBSUbz7otJLiUu48Hmg==", "8c212966-dacd-474b-a818-7954a22f95b1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b2eb0a3-7d3c-4671-8d16-30c69d20a7c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5aa375d5-8834-4413-8fe9-ad0906c0feec", "AQAAAAIAAYagAAAAECAMx1tGgbrvAQUzOj0ysnUV2oVMJRYB3K+50+YQNQ/6pgF430CXQb1OG3UzQPHHeA==", "f27c433d-cf77-4bf3-9fed-d24cfe048cd7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d9e03227-9b87-40b5-9c7b-3a8578b6c04c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7e113f6-9771-4945-8ea6-e2caf18c4b60", "AQAAAAIAAYagAAAAEE/nANuOcpGv5OtnIBcsbiTFZkAbhgNmc1JnN3JJs0R8woZDzKNQsAaG6OFhSWUi2A==", "763ea372-ffa9-49a7-82c4-b09ae2ba5e31" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0ed2b3d-2c72-4a84-bd60-1ff9a78ee084",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b9aecea-8ae0-4c1d-8713-c3c1b1eae140", "AQAAAAIAAYagAAAAELQb+Z4dnoNcptkncgxE+RdYoQkrLrH/A+wVUOK14ei7qRENqc4KjTprjMH2FPzhQw==", "8a219f35-7fec-467b-82c2-8b6aa3267735" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f97c809c-70e9-47de-901b-b14f59971722", "AQAAAAIAAYagAAAAEMzFeycmUiwOFO/k7qiayJJIZiMSWhGYUVcbpKxhc7MLocdc6zjTd0GkeylIJDHZ1A==", "e10e800b-786d-4cd2-8bbc-df8eb616f8d7" });
        }
    }
}
