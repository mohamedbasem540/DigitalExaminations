using Microsoft.EntityFrameworkCore.Migrations;



namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.InsertData(
                table: "Exam",
                columns: new[] { "Id", "Instrucations", "IsPublished", "Name" },
                values: new object[] { 1, "This is a test exam", true, "Test Exam" });

            _ = migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Fk_Exam", "ImageUrl", "QuestionText", "QuestionType", "StorageUrl" },
                values: new object[,]
                {
                    { 1, 1, null, "This is a test (multiple choice) question", 1, null },
                    { 2, 1, null, "This is a test (true, false) question 2", 2, null },
                    { 3, 1, null, "This is a test (fill in the blank) question, .....", 3, null },
                    { 4, 1, null, "This is a test (essay) question,Do you agree or disagree with the following statement?", 4, null }
                });

            _ = migrationBuilder.InsertData(
                table: "Answer",
                columns: new[] { "Id", "AnswerText", "Fk_Question", "ImageUrl", "IsCorrect", "StorageUrl" },
                values: new object[,]
                {
                    { 1, "This is a test answer 1", 1, null, true, null },
                    { 2, "This is a test answer 2", 1, null, false, null },
                    { 3, "This is a test answer 3", 1, null, false, null },
                    { 4, "This is a test answer 4", 1, null, false, null },
                    { 5, "True", 2, null, true, null },
                    { 6, "False", 2, null, false, null },
                    { 7, "This is a test answer 1", 3, null, true, null },
                    { 8, "This is a test answer 2", 3, null, false, null },
                    { 9, "This is a test answer 3", 3, null, false, null },
                    { 10, "Yes", 4, null, true, null },
                    { 11, "No", 4, null, false, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "Id",
                keyValue: 1);

            _ = migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "Id",
                keyValue: 2);

            _ = migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "Id",
                keyValue: 3);

            _ = migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "Id",
                keyValue: 4);

            _ = migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "Id",
                keyValue: 5);

            _ = migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "Id",
                keyValue: 6);

            _ = migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "Id",
                keyValue: 7);

            _ = migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "Id",
                keyValue: 8);

            _ = migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "Id",
                keyValue: 9);

            _ = migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "Id",
                keyValue: 10);

            _ = migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "Id",
                keyValue: 11);

            _ = migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 1);

            _ = migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 2);

            _ = migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 3);

            _ = migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 4);

            _ = migrationBuilder.DeleteData(
                table: "Exam",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
