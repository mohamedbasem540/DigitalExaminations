using Microsoft.EntityFrameworkCore.Migrations;


namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initildb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.CreateTable(
                name: "Exam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Instrucations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Exam", x => x.Id);
                });

            _ = migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Users", x => x.Id);
                });

            _ = migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_Exam = table.Column<int>(type: "int", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionType = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Question", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_Question_Exam_Fk_Exam",
                        column: x => x.Fk_Exam,
                        principalTable: "Exam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_User = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonRevoked = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_RefreshTokens_Users_Fk_User",
                        column: x => x.Fk_User,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_User = table.Column<int>(type: "int", nullable: false),
                    SchoolName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GradeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Students", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_Students_Users_Fk_User",
                        column: x => x.Fk_User,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_Question = table.Column<int>(type: "int", nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Answer", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_Answer_Question_Fk_Question",
                        column: x => x.Fk_Question,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "StudentExams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_Exam = table.Column<int>(type: "int", nullable: false),
                    Fk_Student = table.Column<int>(type: "int", nullable: false),
                    SubmitAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalMark = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_StudentExams", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_StudentExams_Exam_Fk_Exam",
                        column: x => x.Fk_Exam,
                        principalTable: "Exam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_StudentExams_Students_Fk_Student",
                        column: x => x.Fk_Student,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "StudentExamAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_StudentExam = table.Column<int>(type: "int", nullable: false),
                    Fk_Question = table.Column<int>(type: "int", nullable: false),
                    Fk_Answer = table.Column<int>(type: "int", nullable: true),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_StudentExamAnswers", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_StudentExamAnswers_Answer_Fk_Answer",
                        column: x => x.Fk_Answer,
                        principalTable: "Answer",
                        principalColumn: "Id");
                    _ = table.ForeignKey(
                        name: "FK_StudentExamAnswers_Question_Fk_Question",
                        column: x => x.Fk_Question,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_StudentExamAnswers_StudentExams_Fk_StudentExam",
                        column: x => x.Fk_StudentExam,
                        principalTable: "StudentExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            _ = migrationBuilder.CreateIndex(
                name: "IX_Answer_Fk_Question",
                table: "Answer",
                column: "Fk_Question");

            _ = migrationBuilder.CreateIndex(
                name: "IX_Question_Fk_Exam",
                table: "Question",
                column: "Fk_Exam");

            _ = migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_Fk_User",
                table: "RefreshTokens",
                column: "Fk_User");

            _ = migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_Token",
                table: "RefreshTokens",
                column: "Token",
                unique: true);

            _ = migrationBuilder.CreateIndex(
                name: "IX_StudentExamAnswers_Fk_Answer",
                table: "StudentExamAnswers",
                column: "Fk_Answer");

            _ = migrationBuilder.CreateIndex(
                name: "IX_StudentExamAnswers_Fk_Question",
                table: "StudentExamAnswers",
                column: "Fk_Question");

            _ = migrationBuilder.CreateIndex(
                name: "IX_StudentExamAnswers_Fk_StudentExam",
                table: "StudentExamAnswers",
                column: "Fk_StudentExam");

            _ = migrationBuilder.CreateIndex(
                name: "IX_StudentExams_Fk_Exam",
                table: "StudentExams",
                column: "Fk_Exam");

            _ = migrationBuilder.CreateIndex(
                name: "IX_StudentExams_Fk_Student",
                table: "StudentExams",
                column: "Fk_Student");

            _ = migrationBuilder.CreateIndex(
                name: "IX_Students_Fk_User",
                table: "Students",
                column: "Fk_User",
                unique: true);

            _ = migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropTable(
                name: "RefreshTokens");

            _ = migrationBuilder.DropTable(
                name: "StudentExamAnswers");

            _ = migrationBuilder.DropTable(
                name: "Answer");

            _ = migrationBuilder.DropTable(
                name: "StudentExams");

            _ = migrationBuilder.DropTable(
                name: "Question");

            _ = migrationBuilder.DropTable(
                name: "Students");

            _ = migrationBuilder.DropTable(
                name: "Exam");

            _ = migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
