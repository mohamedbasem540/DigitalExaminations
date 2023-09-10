using Contracts.Repository.DBModels.ExamModels;
using Entities.CoreServicesModels.ExamModels;
using Entities.DBModels.ExamModels;

namespace Repository.DBModels.ExamModels
{
    public class ExamRepository : RepositoryBase<Exam>, IExamRepository
    {
        public ExamRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<Exam> FindAll(
            ExamParameters parameters,
            bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id,
                           parameters.IsPublished);
        }

        public async Task<Exam> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges).SingleOrDefaultAsync();
        }
    }

    public static class ExamRepositoryExtensions
    {
        public static IQueryable<Exam> Filter(
            this IQueryable<Exam> students,
            int id,
            bool? isPublished)
        {
            return students.Where(a => (id == 0 || a.Id == id) &&
                                       (isPublished == null || a.IsPublished == isPublished));
        }
    }
}
