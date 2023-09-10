using Entities.CoreServicesModels.StudentExamModels;
using Entities.DBModels.StudentExamModels;

namespace Contracts.Repository.DBModels.StudentExamModels
{
    public interface IStudentExamAnswerRepository : IRepositoryBase<StudentExamAnswer>
    {
        IQueryable<StudentExamAnswer> FindAll(StudentExamAnswerParameters parameters, bool trackChanges);
        Task<StudentExamAnswer> FindById(int id, bool trackChanges);
    }
}
