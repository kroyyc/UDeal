using Microsoft.EntityFrameworkCore.Migrations;

namespace UDeal.Data.Migrations
{
    public partial class AddPostCampusRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CampusId",
                table: "Posts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CampusId",
                table: "Posts",
                column: "CampusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Campuses_CampusId",
                table: "Posts",
                column: "CampusId",
                principalTable: "Campuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Campuses_CampusId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CampusId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CampusId",
                table: "Posts");
        }
    }
}
