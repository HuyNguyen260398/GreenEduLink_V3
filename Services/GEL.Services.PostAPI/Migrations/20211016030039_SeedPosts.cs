using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GEL.Services.PostAPI.Migrations
{
    public partial class SeedPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Thumbnail",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "CategoryId", "Comments", "Content", "CreatedAt", "Description", "PublishedAt", "Slug", "SubCategoryId", "Thumbnail", "Title", "UpdatedAt", "Views" },
                values: new object[] { 1, 1, 1, "Content 1", new DateTime(2021, 10, 16, 10, 0, 39, 606, DateTimeKind.Local).AddTicks(403), "Desc 1", new DateTime(2021, 10, 16, 10, 0, 39, 606, DateTimeKind.Local).AddTicks(413), "Slug 1", 1, "", "Post 1", new DateTime(2021, 10, 16, 10, 0, 39, 606, DateTimeKind.Local).AddTicks(414), 1 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "CategoryId", "Comments", "Content", "CreatedAt", "Description", "PublishedAt", "Slug", "SubCategoryId", "Thumbnail", "Title", "UpdatedAt", "Views" },
                values: new object[] { 2, 2, 2, "Content 2", new DateTime(2021, 10, 16, 10, 0, 39, 606, DateTimeKind.Local).AddTicks(438), "Desc 2", new DateTime(2021, 10, 16, 10, 0, 39, 606, DateTimeKind.Local).AddTicks(438), "Slug 2", 2, "", "Post 2", new DateTime(2021, 10, 16, 10, 0, 39, 606, DateTimeKind.Local).AddTicks(439), 2 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "CategoryId", "Comments", "Content", "CreatedAt", "Description", "PublishedAt", "Slug", "SubCategoryId", "Thumbnail", "Title", "UpdatedAt", "Views" },
                values: new object[] { 3, 3, 3, "Content 3", new DateTime(2021, 10, 16, 10, 0, 39, 606, DateTimeKind.Local).AddTicks(447), "Desc 3", new DateTime(2021, 10, 16, 10, 0, 39, 606, DateTimeKind.Local).AddTicks(447), "Slug 3", 3, "", "Post 3", new DateTime(2021, 10, 16, 10, 0, 39, 606, DateTimeKind.Local).AddTicks(448), 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Thumbnail",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
