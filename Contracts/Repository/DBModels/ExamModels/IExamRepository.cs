using Entities.CoreServicesModels.ExamModels;
using Entities.DBModels.ExamModels;

namespace Contracts.Repository.DBModels.ExamModels
{
    public interface IExamRepository : IRepositoryBase<Exam>
    {
        IQueryable<Exam> FindAll(ExamParameters parameters, bool trackChanges);
        Task<Exam> FindById(int id, bool trackChanges);
    }
}
