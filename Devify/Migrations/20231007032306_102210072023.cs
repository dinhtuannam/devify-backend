using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devify.Migrations
{
    /// <inheritdoc />
    public partial class _102210072023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Courses_CourseId",
                table: "Chapters");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Lessons_LessonId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Categories_CategoryId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseLevels_CourseLevelId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Creators_CreatorId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Chapters_ChapterId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_UserId",
                table: "Notifications");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Notifications",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "ChapterId",
                table: "Lessons",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CourseLevelId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "LessonId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "Chapters",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_Courses_CourseId",
                table: "Chapters",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Lessons_LessonId",
                table: "Comments",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Categories_CategoryId",
                table: "Courses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseLevels_CourseLevelId",
                table: "Courses",
                column: "CourseLevelId",
                principalTable: "CourseLevels",
                principalColumn: "CourseLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Creators_CreatorId",
                table: "Courses",
                column: "CreatorId",
                principalTable: "Creators",
                principalColumn: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Chapters_ChapterId",
                table: "Lessons",
                column: "ChapterId",
                principalTable: "Chapters",
                principalColumn: "ChapterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Courses_CourseId",
                table: "Chapters");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Lessons_LessonId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Categories_CategoryId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseLevels_CourseLevelId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Creators_CreatorId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Chapters_ChapterId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_UserId",
                table: "Notifications");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Notifications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ChapterId",
                table: "Lessons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CourseLevelId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LessonId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "Chapters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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
                name: "FK_Chapters_Courses_CourseId",
                table: "Chapters",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Lessons_LessonId",
                table: "Comments",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "LessonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Categories_CategoryId",
                table: "Courses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseLevels_CourseLevelId",
                table: "Courses",
                column: "CourseLevelId",
                principalTable: "CourseLevels",
                principalColumn: "CourseLevelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Creators_CreatorId",
                table: "Courses",
                column: "CreatorId",
                principalTable: "Creators",
                principalColumn: "CreatorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Chapters_ChapterId",
                table: "Lessons",
                column: "ChapterId",
                principalTable: "Chapters",
                principalColumn: "ChapterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
