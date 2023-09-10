using Contracts.CoreServices;
using CoreServices.Logic;

namespace CoreServices
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRepositoryManager _repository;

        #region Private
        private IUserServices _user;
        private IStudentServices _student;
        private IExamServices _exam;
        private IStudentExamServices _studentExam;
        #endregion

        public UnitOfWork(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task Save()
        {
            await _repository.Save();
        }

        #region Public

        public IUserServices User
        {
            get
            {
                _user ??= new UserServices(_repository);
                return _user;
            }
        }

        public IStudentServices Student
        {
            get
            {
                _student ??= new StudentServices(_repository);
                return _student;
            }
        }

        public IExamServices Exam
        {
            get
            {
                _exam ??= new ExamServices(_repository);
                return _exam;
            }
        }

        public IStudentExamServices StudentExam
        {
            get
            {
                _studentExam ??= new StudentExamServices(_repository);
                return _studentExam;
            }
        }
        #endregion
    }
}
