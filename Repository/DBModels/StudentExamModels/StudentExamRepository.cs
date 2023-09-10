using Contracts.Repository.DBModels.StudentExamModels;
using Entities.CoreServicesModels.StudentExamModels;
using Entities.DBModels.StudentExamModels;

namespace Repository.DBModels.StudentExamModels
{
    public class StudentExamRepository : RepositoryBase<StudentExam>, IStudentExamRepository
    {
        public StudentExamRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<StudentExam> FindAll(
            StudentExamParameters parameters,
            bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id,
                           parameters.Fk_Exam,
                           parameters.Fk_Student);
        }

        public async Task<StudentExam> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges).SingleOrDefaultAsync();
        }
    }

    public static class StudentExamRepositoryExtensions
    {
        public static IQueryable<StudentExam> Filter(
            this IQueryable<StudentExam> students,
            int id,
            int fk_Exam,
            int fk_Student)
        {
            return students.Where(a => (id == 0 || a.Id == id) &&
                                       (fk_Exam == 0 || a.Fk_Exam == fk_Exam) &&
                                       (fk_Student == 0 || a.Fk_Student == fk_Student));
        }
    }
}
