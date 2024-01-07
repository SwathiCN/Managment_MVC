using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Managment.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _SeedMarksTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MarksDetails",
                columns: new[] { "MarksId", "MarksObtained", "Subject" },
                values: new object[,]
                {
                    { 1, 90, "Math" },
                    { 2, 85, "Science" },
                    { 3, 75, "History" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MarksDetails",
                keyColumn: "MarksId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MarksDetails",
                keyColumn: "MarksId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MarksDetails",
                keyColumn: "MarksId",
                keyValue: 3);
        }
    }
}
