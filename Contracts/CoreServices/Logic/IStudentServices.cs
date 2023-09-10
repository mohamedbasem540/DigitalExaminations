using Entities.CoreServicesModels.StudentModels;
using Entities.DBModels.StudentModels;
using Entities.RequestFeatures;

namespace Contracts.CoreServices.Logic
{
    public interface IStudentServices
    {
        void CreateStudent(Student Student);
        Task DeleteStudent(int id);
        Task<Student> FindStudentbyId(int id, bool trackChanges);
        StudentModel GetStudentByUserId(int id);
        StudentModel GetStudentById(int id);
        int GetStudentCount();
        IQueryable<StudentModel> GetStudents(StudentParameters parameters);
        Task<PagedList<StudentModel>> GetStudentsPaged(StudentParameters parameters);
    }
}