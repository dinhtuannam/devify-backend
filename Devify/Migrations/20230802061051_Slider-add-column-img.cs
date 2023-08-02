using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devify.Migrations
{
    /// <inheritdoc />
    public partial class Slideraddcolumnimg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2e0d9b-74dd-4928-8c24-1a3156d9fc41",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9cbd1a2a-6687-4196-8240-a0ac718491a3", "AQAAAAIAAYagAAAAEGVXDYPJYSC0Wo+2bn47Z5wdTt+w39nAf6ox8G3hQlqjwQ+pllJpZ78eZ9hnTsdOOg==", "40cd258e-29fd-48aa-962d-e3a2df50e0bf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f9f0d9e-67af-4a8d-9aa6-5f2270fc9fbb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "913901d8-05d7-4a63-be9c-192bd7447d4d", "AQAAAAIAAYagAAAAEEzDrfvlH/mXl3S+WdWgtKCVr2byaTDtAtNgtlzfrkV0deubQonUJHM8vvxAEC1/ag==", "fd0001a3-52bd-4729-8a58-51995f2872b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "51274390-9171-49dd-a3e7-6e23fbf327fb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1170ab7e-76d0-4f9b-9e79-539713f76e89", "AQAAAAIAAYagAAAAEDjAM+mkR5RrVrh7JfgT+vRTOw18Jur/SEmDS1TkmaFjRDID+Et5yJQAHg3wtfViiA==", "3a7b7ca3-3696-4278-a080-0bd8a64b2a4a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e6e4976-631d-46fb-91ea-11e70fb7087a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7cfcf749-f945-46c8-a9c1-cacc5b4310dd", "AQAAAAIAAYagAAAAEMpja90Iih5E8CXfZFbH+xiXaNYy1lbpjsMCAwaod42h+Ka3k8s9Yyw5zxifRhrG5w==", "fde837e7-2af8-493c-b17e-a03ef86c53ac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b4a17e1-4a1a-44e3-9a95-c2b59b7a7a4c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e384ecd0-b7a4-4bea-8e6e-f5516b6584c0", "AQAAAAIAAYagAAAAEDUOWFvpe41MGxH8qIaznRMRxr9rX9OF34pJFiYcYSCxF13TsBuBdC5zh7X3yiZTsA==", "aabfb318-f19c-4513-964f-5e0884f2e1cf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b2eb0a3-7d3c-4671-8d16-30c69d20a7c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eab52f23-ef07-48fe-977d-d2077020662a", "AQAAAAIAAYagAAAAEMozDcM/KKaLfK0+3PNb5nymYTZkFIforR7ZAInDkPV09+QmStJeacHfJ37Ciw9TFg==", "5c3b2fed-e90c-4e8c-9892-e1de18f863a9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d9e03227-9b87-40b5-9c7b-3a8578b6c04c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bda4a152-0ce8-4c68-ac5e-e4d1fd423700", "AQAAAAIAAYagAAAAEGl4cwzT385XVzmQvBXHJW2OuAMz+GIUkFKG6HRAHefBaPKx6H6zk1jaP4n/mV64Tw==", "ededf500-9947-403e-9d33-ffa04dae28f2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0ed2b3d-2c72-4a84-bd60-1ff9a78ee084",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2351912e-9564-4426-b4d6-f758c90c7b35", "AQAAAAIAAYagAAAAEA/lcgrdgor0iLvYJxbfvAz1e+LUStZcvfVOGJaJVdP6GXzHGzplbdbHJqPW0lPsMQ==", "64d6f4bc-098d-457c-b74c-970dd87734bd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f215b71b-e434-402e-be6f-ff6605e66ee3", "AQAAAAIAAYagAAAAEEAursQ3a3QCXl3M6cu3NOeAKn/uqy8m8oprBk7jneauMJ3LwMh2B4XWvR7OSa0z+Q==", "8b2049e8-c2d7-42af-8e50-d1b928e297ca" });
        }
    }
}
