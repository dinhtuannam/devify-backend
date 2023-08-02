using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devify.Migrations
{
    /// <inheritdoc />
    public partial class sada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Button",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Sliders");

            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Button",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2e0d9b-74dd-4928-8c24-1a3156d9fc41",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "833838bd-2763-4dcf-ba36-181909ff2c3e", "AQAAAAIAAYagAAAAEOW6t6BTZcyjMBwGUkRYCKwSVwU82WO5YSUcrqfpjZBpGe+QdWJdF7lLjIVFnUlmMg==", "8f2bff58-d586-4499-9952-300697dbc14f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f9f0d9e-67af-4a8d-9aa6-5f2270fc9fbb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71fd7009-0fc0-41c6-a559-ebff64342f93", "AQAAAAIAAYagAAAAEFN5GQbu/N5CAGu45y909qdk1/Z001ToEgqV2aeDViXuxtelddAwdvuFodJovtJIBw==", "d634ca8a-4bcd-411b-9f29-f50f898e5def" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "51274390-9171-49dd-a3e7-6e23fbf327fb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16d49690-3c41-46b2-9f03-66d1990e8d59", "AQAAAAIAAYagAAAAEBwIAz2i8QG68Mj0Oee1DFUArg3WPG6fe7OoF7/3NQ7CC7ntgiIXstthnBJQuGgJYQ==", "d2c828f0-70de-4a48-90cb-766c6551f700" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e6e4976-631d-46fb-91ea-11e70fb7087a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89e40456-346e-419d-85f8-c0506730fbbd", "AQAAAAIAAYagAAAAEA+MzS2ok23WcpaOEM8poyScpN2C3KoNlIS9y7VfYlbGbPcYxjEFVUIaxQMQDSdZTg==", "d169ae54-5281-4a17-9e5e-5704c62948a3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b4a17e1-4a1a-44e3-9a95-c2b59b7a7a4c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a34ce5d8-4a84-4ea6-ae79-a4b9aa509384", "AQAAAAIAAYagAAAAEIpd91hd+NmGznSWCvGTls41LlVcbPOROmsqpPOqAf3xYBJttCuJXb/7a5Aw8UkcZQ==", "6aa7ecbd-0c66-4d0e-a051-16a2ea26248e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b2eb0a3-7d3c-4671-8d16-30c69d20a7c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2137099-edad-4fea-8ca5-b3a9cd8a897b", "AQAAAAIAAYagAAAAEJripiFTzmLGx3rAguLbidlXRSqCaNcOlZ1xY6iRfmBFeyEJXdLdgP8Tjdu9Qk5MJw==", "6e428edb-242f-441f-a11a-566faee565f4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d9e03227-9b87-40b5-9c7b-3a8578b6c04c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b4bffab-fc81-419f-8e1e-29bc22d6cb2d", "AQAAAAIAAYagAAAAECkkkZKnQW1CCS+mJHLrgSArb56nfhhh1ds42Sg8Sa+Qbqut3F0ulEYNlEEadzOLxw==", "3431e37f-4c41-4638-99f3-41015f77ed29" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0ed2b3d-2c72-4a84-bd60-1ff9a78ee084",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "447b321b-654a-44d1-aecb-a4252c107b28", "AQAAAAIAAYagAAAAENWWWTxc8i1MGdaXSDqNbGBU4acEDxN6QzZuHDNfOaZfTcC6JlnABPOPnZloncuTuw==", "3ff3567d-119d-4088-9157-0146fc6cb20e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e117d0a-7faa-4471-98c2-d7daf659d08e", "AQAAAAIAAYagAAAAEMD1QL+P0GjvaNZZlCOEK8Oyy+88donwWL54kZhaoYajQUnh9X1EYUXPmjMZxK/pUg==", "8c663411-d343-4599-9ff6-d75a96b999a3" });
        }
    }
}
