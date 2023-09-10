using Contracts.Repository.DBModels.ExamModels;
using Entities.CoreServicesModels.ExamModels;
using Entities.DBModels.ExamModels;

namespace Repository.DBModels.ExamModels
{
    public class AnswerRepository : RepositoryBase<Answer>, IAnswerRepository
    {
        public AnswerRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<Answer> FindAll(
            AnswerParameters parameters,
            bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id);
        }

        public async Task<Answer> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges).SingleOrDefaultAsync();
        }
    }

    public static class AnswerRepositoryExtensions
    {
        public static IQueryable<Answer> Filter(
            this IQueryable<Answer> students,
            int id)
        {
            return students.Where(a => id == 0 || a.Id == id);
        }
    }
}
