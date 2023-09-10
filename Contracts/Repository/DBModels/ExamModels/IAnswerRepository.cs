using Entities.CoreServicesModels.ExamModels;
using Entities.DBModels.ExamModels;

namespace Contracts.Repository.DBModels.ExamModels
{
    public interface IAnswerRepository : IRepositoryBase<Answer>
    {
        IQueryable<Answer> FindAll(AnswerParameters parameters, bool trackChanges);
        Task<Answer> FindById(int id, bool trackChanges);
    }
}
