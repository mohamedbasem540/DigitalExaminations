using Contracts.Repository.DBModels.StudentModels;
using Entities.CoreServicesModels.StudentModels;
using Entities.DBModels.StudentModels;

namespace Repository.DBModels.StudentModels
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<Student> FindAll(
            StudentParameters parameters,
            bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id,
                           parameters.Fk_User,
                           parameters.SchoolName,
                           parameters.GradeName,
                           parameters.EmailAddress,
                           parameters.PhoneNumber);
        }

        public async Task<Student> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges).SingleOrDefaultAsync();
        }
    }

    public static class StudentRepositoryExtensions
    {
        public static IQueryable<Student> Filter(
            this IQueryable<Student> students,
            int id,
            int fk_User,
            string schoolName,
            string gradeName,
            string emailAddress,
            string phoneNumber)
        {

            phoneNumber = phoneNumber.SafeTrim().SafeLower();
            emailAddress = emailAddress.SafeTrim().SafeLower();

            return students.Where(a => (id == 0 || a.Id == id) &&
                                       (fk_User == 0 || a.Fk_User == fk_User) &&
                                       (string.IsNullOrWhiteSpace(schoolName) ||
                                        a.SchoolName.ToLower().Contains(schoolName.ToLower()) ||
                                        schoolName.ToLower().Contains(a.SchoolName.ToLower())) &&
                                       (string.IsNullOrWhiteSpace(gradeName) ||
                                        a.GradeName.ToLower().Contains(gradeName.ToLower()) ||
                                        schoolName.ToLower().Contains(a.GradeName.ToLower())) &&
                                       (string.IsNullOrWhiteSpace(phoneNumber) ||
                                        (!string.IsNullOrWhiteSpace(a.User.PhoneNumber) &&
                                         a.User.PhoneNumber.ToLower().Contains(phoneNumber))) &&
                                       (string.IsNullOrWhiteSpace(emailAddress) ||
                                         (!string.IsNullOrWhiteSpace(a.User.EmailAddress) &&
                                         a.User.EmailAddress.ToLower().Contains(emailAddress))));
        }
    }
}
