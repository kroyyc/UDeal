using Microsoft.EntityFrameworkCore.Migrations;

namespace UDeal.Data.Migrations
{
    public partial class SeedCampuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Campuses",
                columns: new[] { "Id", "City", "Name", "SchoolId" },
                values: new object[] { 1, "Calgary", "Main", 1 });

            migrationBuilder.InsertData(
                table: "Campuses",
                columns: new[] { "Id", "City", "Name", "SchoolId" },
                values: new object[] { 2, "Calgary", "Spyhill", 1 });

            migrationBuilder.InsertData(
                table: "Campuses",
                columns: new[] { "Id", "City", "Name", "SchoolId" },
                values: new object[] { 3, "Calgary", "Downtown", 1 });

            migrationBuilder.InsertData(
                table: "Campuses",
                columns: new[] { "Id", "City", "Name", "SchoolId" },
                values: new object[] { 4, "Doha", "Quatar", 1 });

            migrationBuilder.InsertData(
                table: "Campuses",
                columns: new[] { "Id", "City", "Name", "SchoolId" },
                values: new object[] { 5, "Edmonton", "North", 2 });

            migrationBuilder.InsertData(
                table: "Campuses",
                columns: new[] { "Id", "City", "Name", "SchoolId" },
                values: new object[] { 6, "Edmonton", "Augustana", 2 });

            migrationBuilder.InsertData(
                table: "Campuses",
                columns: new[] { "Id", "City", "Name", "SchoolId" },
                values: new object[] { 7, "Edmonton", "Saint-Jean", 2 });

            migrationBuilder.InsertData(
                table: "Campuses",
                columns: new[] { "Id", "City", "Name", "SchoolId" },
                values: new object[] { 8, "Edmonton", "South", 2 });

            migrationBuilder.InsertData(
                table: "Campuses",
                columns: new[] { "Id", "City", "Name", "SchoolId" },
                values: new object[] { 9, "Calgary", "Main", 3 });

            migrationBuilder.InsertData(
                table: "Campuses",
                columns: new[] { "Id", "City", "Name", "SchoolId" },
                values: new object[] { 10, "Edmonton", "Main", 4 });

            migrationBuilder.InsertData(
                table: "Campuses",
                columns: new[] { "Id", "City", "Name", "SchoolId" },
                values: new object[] { 11, "Vancouver", "Vancouver", 5 });

            migrationBuilder.InsertData(
                table: "Campuses",
                columns: new[] { "Id", "City", "Name", "SchoolId" },
                values: new object[] { 12, "Kelowna", "Okanagan", 5 });

            migrationBuilder.InsertData(
                table: "Campuses",
                columns: new[] { "Id", "City", "Name", "SchoolId" },
                values: new object[] { 13, "Calgary", "Main", 6 });

            migrationBuilder.InsertData(
                table: "Campuses",
                columns: new[] { "Id", "City", "Name", "SchoolId" },
                values: new object[] { 14, "Saskatoon", "Main", 7 });

            migrationBuilder.InsertData(
                table: "Campuses",
                columns: new[] { "Id", "City", "Name", "SchoolId" },
                values: new object[] { 15, "Victoria", "Main", 8 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Campuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Campuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Campuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Campuses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Campuses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Campuses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Campuses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Campuses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Campuses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Campuses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Campuses",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Campuses",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Campuses",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Campuses",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Campuses",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}
