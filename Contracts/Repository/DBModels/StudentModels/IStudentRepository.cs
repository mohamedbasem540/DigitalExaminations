using Entities.CoreServicesModels.StudentModels;
using Entities.DBModels.StudentModels;

namespace Contracts.Repository.DBModels.StudentModels
{
    public interface IStudentRepository : IRepositoryBase<Student>
    {
        IQueryable<Student> FindAll(StudentParameters parameters, bool trackChanges);
        Task<Student> FindById(int id, bool trackChanges);
    }
}
