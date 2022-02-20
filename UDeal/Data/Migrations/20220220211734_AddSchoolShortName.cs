using Microsoft.EntityFrameworkCore.Migrations;

namespace UDeal.Data.Migrations
{
    public partial class AddSchoolShortName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "Schools",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "Schools");
        }
    }
}
