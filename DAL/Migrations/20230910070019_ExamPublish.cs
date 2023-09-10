using Microsoft.EntityFrameworkCore.Migrations;


namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ExamPublish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Exam",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Exam");
        }
    }
}
