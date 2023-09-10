using Entities.CoreServicesModels.ExamModels;
using Entities.DBModels.ExamModels;
using Entities.DBModels.StudentExamModels;
using Entities.RequestFeatures;

namespace Contracts.CoreServices.Logic
{
    public interface IExamServices
    {
        void CreateAnswer(Answer Answer);
        void CreateExam(Exam Exam);
        void CreateQuestion(Question Question);
        Task DeleteAnswer(int id);
        Task DeleteExam(int id);
        Task DeleteQuestion(int id);
        Task<Answer> FindAnswerbyId(int id, bool trackChanges);
        Task<Exam> FindExambyId(int id, bool trackChanges);
        Task<Question> FindQuestionbyId(int id, bool trackChanges);
        AnswerModel GetAnswerById(int id);
        int GetAnswerCount();
        IQueryable<AnswerModel> GetAnswers(AnswerParameters parameters);
        Dictionary<string, string> GetAnswersLookUp(AnswerParameters parameters);
        Task<PagedList<AnswerModel>> GetAnswersPaged(AnswerParameters parameters);
        ExamModel GetExamById(int id);
        ExamModel GetFullExamById(int id);
        int GetExamCount();
        IQueryable<ExamModel> GetExams(ExamParameters parameters);
        Dictionary<string, string> GetExamsLookUp(ExamParameters parameters);
        Task<PagedList<ExamModel>> GetExamsPaged(ExamParameters parameters);
        StudentExam SubmitExam(ExamSubmissionModel model, int fk_Student);
        QuestionModel GetQuestionById(int id);
        int GetQuestionCount();
        IQueryable<QuestionModel> GetQuestions(QuestionParameters parameters);
        Dictionary<string, string> GetQuestionsLookUp(QuestionParameters parameters);
        Task<PagedList<QuestionModel>> GetQuestionsPaged(QuestionParameters parameters);
    }
}
