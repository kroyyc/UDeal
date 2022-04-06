using Microsoft.EntityFrameworkCore.Migrations;

namespace UDeal.Data.Migrations
{
    public partial class InitialSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Textbooks" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Electronics" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Furniture" });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Domain", "Name", "ShortName" },
                values: new object[] { 1, "ucalgary.ca", "University of Calgary", "UofC" });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Domain", "Name", "ShortName" },
                values: new object[] { 2, "ualberta.ca", "University of Alberta", "UofA" });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Domain", "Name", "ShortName" },
                values: new object[] { 3, "edu.sait.ca", "Southern Alberta Insitute of Technology", "SAIT" });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Domain", "Name", "ShortName" },
                values: new object[] { 4, "nait.ca", "Northern Alberta Insitute of Technology", "NAIT" });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Domain", "Name", "ShortName" },
                values: new object[] { 5, "student.ubc.ca", "University of British Columbia", "UBC" });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Domain", "Name", "ShortName" },
                values: new object[] { 6, "mtroyal.ca", "Mount Royal University", "MRU" });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Domain", "Name", "ShortName" },
                values: new object[] { 7, "mail.usask.ca", "University of Saskatchewan", "USask" });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Domain", "Name", "ShortName" },
                values: new object[] { 8, "uvic.ca", "University of Victoria", "UVic" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
