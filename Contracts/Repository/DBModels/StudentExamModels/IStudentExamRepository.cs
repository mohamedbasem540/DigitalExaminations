using Entities.CoreServicesModels.StudentExamModels;
using Entities.DBModels.StudentExamModels;

namespace Contracts.Repository.DBModels.StudentExamModels
{
    public interface IStudentExamRepository : IRepositoryBase<StudentExam>
    {
        IQueryable<StudentExam> FindAll(StudentExamParameters parameters, bool trackChanges);
        Task<StudentExam> FindById(int id, bool trackChanges);
    }
}
