using Contracts.Repository.DBModels.ExamModels;
using Contracts.Repository.DBModels.StudentExamModels;
using Contracts.Repository.DBModels.StudentModels;
using Contracts.Repository.DBModels.UserModels;

namespace Contracts.Repository
{
    public interface IRepositoryManager
    {
        Task Save();

        #region User
        IUserRepository User { get; }
        IRefreshTokenRepository RefreshToken { get; }
        #endregion

        #region Exam
        IExamRepository Exam { get; }
        IQuestionRepository Question { get; }
        IAnswerRepository Answer { get; }
        #endregion

        #region Student
        IStudentRepository Student { get; }
        #endregion

        #region StudentExam
        IStudentExamRepository StudentExam { get; }
        IStudentExamAnswerRepository StudentExamAnswer { get; }
        #endregion
    }
}
