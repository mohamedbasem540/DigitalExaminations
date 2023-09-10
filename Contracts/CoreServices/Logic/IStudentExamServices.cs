using Entities.CoreServicesModels.StudentExamModels;
using Entities.DBModels.StudentExamModels;
using Entities.RequestFeatures;

namespace Contracts.CoreServices.Logic
{
    public interface IStudentExamServices
    {
        void CreateStudentExam(StudentExam StudentExam);
        void CreateStudentExamAnswer(StudentExamAnswer StudentExamAnswer);
        Task DeleteStudentExam(int id);
        Task DeleteStudentExamAnswer(int id);
        Task<StudentExamAnswer> FindStudentExamAnswerbyId(int id, bool trackChanges);
        Task<StudentExam> FindStudentExambyId(int id, bool trackChanges);
        StudentExamAnswerModel GetStudentExamAnswerById(int id);
        int GetStudentExamAnswerCount();
        IQueryable<StudentExamAnswerModel> GetStudentExamAnswers(StudentExamAnswerParameters parameters);
        Task<PagedList<StudentExamAnswerModel>> GetStudentExamAnswersPaged(StudentExamAnswerParameters parameters);
        StudentExamModel GetStudentExamById(int id);
        int GetStudentExamCount();
        IQueryable<StudentExamModel> GetStudentExams(StudentExamParameters parameters);
        Task<PagedList<StudentExamModel>> GetStudentExamsPaged(StudentExamParameters parameters);
    }
}