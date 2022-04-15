using Microsoft.EntityFrameworkCore.Migrations;

namespace UDeal.Data.Migrations
{
    public partial class MakePostCampusNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Campuses_CampusId",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "CampusId",
                table: "Posts",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

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

            migrationBuilder.AlterColumn<int>(
                name: "CampusId",
                table: "Posts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Campuses_CampusId",
                table: "Posts",
                column: "CampusId",
                principalTable: "Campuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
