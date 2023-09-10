using Contracts.Repository.DBModels.ExamModels;
using Entities.CoreServicesModels.ExamModels;
using Entities.DBModels.ExamModels;

namespace Repository.DBModels.ExamModels
{
    public class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
    {
        public QuestionRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<Question> FindAll(
            QuestionParameters parameters,
            bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id);
        }

        public async Task<Question> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges).SingleOrDefaultAsync();
        }
    }

    public static class QuestionRepositoryExtensions
    {
        public static IQueryable<Question> Filter(
            this IQueryable<Question> students,
            int id)
        {
            return students.Where(a => id == 0 || a.Id == id);
        }
    }
}
