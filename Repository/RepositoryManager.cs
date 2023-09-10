using Contracts.Repository;
using Contracts.Repository.DBModels.ExamModels;
using Contracts.Repository.DBModels.StudentExamModels;
using Contracts.Repository.DBModels.StudentModels;
using Contracts.Repository.DBModels.UserModels;
using Repository.DBModels.ExamModels;
using Repository.DBModels.StudentExamModels;
using Repository.DBModels.StudentModels;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly BaseContext _dBContext;

        #region private

        #region User
        private IUserRepository _user;
        private IRefreshTokenRepository _refreshToken;
        #endregion

        #region Student
        private IStudentRepository _student;
        #endregion

        #region Exam
        private IExamRepository _exam;
        private IAnswerRepository _answer;
        private IQuestionRepository _question;
        #endregion

        #region StudentExam
        private IStudentExamRepository _studentExam;
        private IStudentExamAnswerRepository _studentExamAnswer;
        #endregion

        #endregion

        public RepositoryManager(BaseContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task Save()
        {
            _ = await _dBContext.SaveChangesAsync();
        }

        #region Public

        #region UserModels

        public IUserRepository User
        {
            get
            {
                _user ??= new UserRepository(_dBContext);
                return _user;
            }
        }

        public IRefreshTokenRepository RefreshToken
        {
            get
            {
                _refreshToken ??= new RefreshTokenRepository(_dBContext);
                return _refreshToken;
            }
        }

        #endregion

        public IStudentRepository Student
        {
            get
            {
                _student ??= new StudentRepository(_dBContext);
                return _student;
            }
        }

        public IStudentExamRepository StudentExam
        {
            get
            {
                _studentExam ??= new StudentExamRepository(_dBContext);
                return _studentExam;
            }
        }

        public IStudentExamAnswerRepository StudentExamAnswer
        {
            get
            {
                _studentExamAnswer ??= new StudentExamAnswerRepository(_dBContext);
                return _studentExamAnswer;
            }
        }

        public IExamRepository Exam
        {
            get
            {
                _exam ??= new ExamRepository(_dBContext);
                return _exam;
            }
        }

        public IAnswerRepository Answer
        {
            get
            {
                _answer ??= new AnswerRepository(_dBContext);
                return _answer;
            }
        }

        public IQuestionRepository Question
        {
            get
            {
                _question ??= new QuestionRepository(_dBContext);
                return _question;
            }
        }
        #endregion
    }
}
