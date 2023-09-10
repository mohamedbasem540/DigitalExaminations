using Entities.CoreServicesModels.ExamModels;
using Entities.DBModels.ExamModels;

namespace Contracts.Repository.DBModels.ExamModels
{
    public interface IQuestionRepository : IRepositoryBase<Question>
    {
        IQueryable<Question> FindAll(QuestionParameters parameters, bool trackChanges);
        Task<Question> FindById(int id, bool trackChanges);
    }
}
