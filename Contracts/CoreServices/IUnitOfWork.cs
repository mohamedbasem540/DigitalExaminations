using Contracts.CoreServices.Logic;

namespace Contracts.CoreServices
{
    public interface IUnitOfWork
    {
        IExamServices Exam { get; }
        IStudentServices Student { get; }
        IStudentExamServices StudentExam { get; }
        IUserServices User { get; }

        Task Save();
    }
}