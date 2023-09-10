using Contracts.Repository.DBModels.StudentExamModels;
using Entities.CoreServicesModels.StudentExamModels;
using Entities.DBModels.StudentExamModels;

namespace Repository.DBModels.StudentExamModels
{
    public class StudentExamAnswerRepository : RepositoryBase<StudentExamAnswer>, IStudentExamAnswerRepository
    {
        public StudentExamAnswerRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<StudentExamAnswer> FindAll(
            StudentExamAnswerParameters parameters,
            bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id);
        }

        public async Task<StudentExamAnswer> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges).SingleOrDefaultAsync();
        }
    }

    public static class StudentExamAnswerRepositoryExtensions
    {
        public static IQueryable<StudentExamAnswer> Filter(
            this IQueryable<StudentExamAnswer> students,
            int id)
        {
            return students.Where(a => id == 0 || a.Id == id);
        }
    }
}
