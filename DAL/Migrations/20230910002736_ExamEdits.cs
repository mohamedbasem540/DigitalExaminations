using Microsoft.EntityFrameworkCore.Migrations;


namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ExamEdits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropForeignKey(
                name: "FK_StudentExamAnswers_Answer_Fk_Answer",
                table: "StudentExamAnswers");

            _ = migrationBuilder.DropColumn(
                name: "SubmitAt",
                table: "StudentExams");

            _ = migrationBuilder.DropColumn(
                name: "AnswerText",
                table: "StudentExamAnswers");

            _ = migrationBuilder.RenameColumn(
                name: "TotalMark",
                table: "StudentExams",
                newName: "SuccessCount");

            _ = migrationBuilder.AddColumn<int>(
                name: "QuestionCount",
                table: "StudentExams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            _ = migrationBuilder.AlterColumn<int>(
                name: "Fk_Answer",
                table: "StudentExamAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            _ = migrationBuilder.AddForeignKey(
                name: "FK_StudentExamAnswers_Answer_Fk_Answer",
                table: "StudentExamAnswers",
                column: "Fk_Answer",
                principalTable: "Answer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropForeignKey(
                name: "FK_StudentExamAnswers_Answer_Fk_Answer",
                table: "StudentExamAnswers");

            _ = migrationBuilder.DropColumn(
                name: "QuestionCount",
                table: "StudentExams");

            _ = migrationBuilder.RenameColumn(
                name: "SuccessCount",
                table: "StudentExams",
                newName: "TotalMark");

            _ = migrationBuilder.AddColumn<DateTime>(
                name: "SubmitAt",
                table: "StudentExams",
                type: "datetime2",
                nullable: true);

            _ = migrationBuilder.AlterColumn<int>(
                name: "Fk_Answer",
                table: "StudentExamAnswers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            _ = migrationBuilder.AddColumn<string>(
                name: "AnswerText",
                table: "StudentExamAnswers",
                type: "nvarchar(max)",
                nullable: true);

            _ = migrationBuilder.AddForeignKey(
                name: "FK_StudentExamAnswers_Answer_Fk_Answer",
                table: "StudentExamAnswers",
                column: "Fk_Answer",
                principalTable: "Answer",
                principalColumn: "Id");
        }
    }
}
