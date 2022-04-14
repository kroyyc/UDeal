using Microsoft.EntityFrameworkCore.Migrations;

namespace UDeal.Data.Migrations
{
    public partial class AddPostCourseRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Posts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CourseId",
                table: "Posts",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Courses_CourseId",
                table: "Posts",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Courses_CourseId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CourseId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Posts");
        }
    }
}
