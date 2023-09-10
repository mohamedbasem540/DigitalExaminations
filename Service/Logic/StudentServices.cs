using Entities.CoreServicesModels.StudentModels;
using Entities.CoreServicesModels.UserModels;
using Entities.DBModels.StudentModels;

namespace CoreServices.Logic;

public class StudentServices : IStudentServices
{
    private readonly IRepositoryManager _repository;

    public StudentServices(IRepositoryManager repository)
    {
        _repository = repository;
    }

    #region Student 
    public IQueryable<StudentModel> GetStudents(StudentParameters parameters)
    {
        return _repository.Student
            .FindAll(parameters, trackChanges: false)
            .Select(a => new StudentModel
            {
                Id = a.Id,
                GradeName = a.GradeName,
                SchoolName = a.SchoolName,
                Fk_User = a.Fk_User,
                User = new UserModel
                {
                    FirstName = a.User.FirstName,
                    LastName = a.User.LastName,
                    FullName = a.User.FullName,
                    PhoneNumber = a.User.PhoneNumber,
                    EmailAddress = a.User.EmailAddress,
                    UserName = a.User.UserName,
                },
                CreatedAt = a.CreatedAt
            })
            .Search(parameters.SearchColumns, parameters.SearchTerm)
            .Sort(parameters.OrderBy);
    }

    public async Task<PagedList<StudentModel>> GetStudentsPaged(
        StudentParameters parameters)
    {
        return await PagedList<StudentModel>.ToPagedList(GetStudents(parameters), parameters.PageNumber, parameters.PageSize);
    }

    public async Task<Student> FindStudentbyId(int id, bool trackChanges)
    {
        return await _repository.Student.FindById(id, trackChanges);
    }

    public void CreateStudent(Student Student)
    {
        _repository.Student.Create(Student);
    }

    public async Task DeleteStudent(int id)
    {
        Student Student = await FindStudentbyId(id, trackChanges: true);
        _repository.Student.Delete(Student);
    }

    public StudentModel GetStudentById(int id)
    {
        return GetStudents(new StudentParameters { Id = id }).SingleOrDefault();
    }

    public StudentModel GetStudentByUserId(int id)
    {
        return GetStudents(new StudentParameters { Fk_User = id }).SingleOrDefault();
    }

    public int GetStudentCount()
    {
        return _repository.Student.Count();
    }

    #endregion
}