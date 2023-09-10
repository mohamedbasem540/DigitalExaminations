using Microsoft.EntityFrameworkCore.Migrations;


namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.UpdateData(
                table: "Exam",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Test Exam 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.UpdateData(
                table: "Exam",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Test Exam");
        }
    }
}
