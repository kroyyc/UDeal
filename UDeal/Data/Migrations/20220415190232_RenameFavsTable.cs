using Microsoft.EntityFrameworkCore.Migrations;

namespace UDeal.Data.Migrations
{
    public partial class RenameFavsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favs_Posts_PostId",
                table: "Favs");

            migrationBuilder.DropForeignKey(
                name: "FK_Favs_Users_UserId",
                table: "Favs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favs",
                table: "Favs");

            migrationBuilder.RenameTable(
                name: "Favs",
                newName: "UserFavourites");

            migrationBuilder.RenameIndex(
                name: "IX_Favs_PostId",
                table: "UserFavourites",
                newName: "IX_UserFavourites_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavourites",
                table: "UserFavourites",
                columns: new[] { "UserId", "PostId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavourites_Posts_PostId",
                table: "UserFavourites",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavourites_Users_UserId",
                table: "UserFavourites",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFavourites_Posts_PostId",
                table: "UserFavourites");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavourites_Users_UserId",
                table: "UserFavourites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavourites",
                table: "UserFavourites");

            migrationBuilder.RenameTable(
                name: "UserFavourites",
                newName: "Favs");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavourites_PostId",
                table: "Favs",
                newName: "IX_Favs_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favs",
                table: "Favs",
                columns: new[] { "UserId", "PostId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Favs_Posts_PostId",
                table: "Favs",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favs_Users_UserId",
                table: "Favs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
