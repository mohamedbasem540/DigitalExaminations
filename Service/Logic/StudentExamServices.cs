using Entities.CoreServicesModels.ExamModels;
using Entities.CoreServicesModels.StudentExamModels;
using Entities.DBModels.StudentExamModels;

namespace CoreServices.Logic;

public class StudentExamServices : IStudentExamServices
{
    private readonly IRepositoryManager _repository;

    public StudentExamServices(IRepositoryManager repository)
    {
        _repository = repository;
    }

    #region Student Exam
    public IQueryable<StudentExamModel> GetStudentExams(StudentExamParameters parameters)
    {
        return _repository.StudentExam
            .FindAll(parameters, trackChanges: false)
            .Select(a => new StudentExamModel
            {
                Id = a.Id,
                Fk_Exam = a.Fk_Exam,
                Exam = new ExamModel
                {
                    Name = a.Exam.Name
                },
                Fk_Student = a.Fk_Student,
                StudentExamAnswers = parameters.IncludeAnswers ? a.StudentExamAnswers.Select(b => new StudentExamAnswerModel
                {
                    Fk_Answer = b.Fk_Answer,
                    IsCorrect = b.IsCorrect,
                }).ToList() : null,
                QuestionCount = a.QuestionCount,
                SuccessCount = a.SuccessCount,
                FailedCount = a.FailedCount,
                CreatedAt = a.CreatedAt,
            })
            .Search(parameters.SearchColumns, parameters.SearchTerm)
            .Sort(parameters.OrderBy);
    }

    public async Task<PagedList<StudentExamModel>> GetStudentExamsPaged(
        StudentExamParameters parameters)
    {
        return await PagedList<StudentExamModel>.ToPagedList(GetStudentExams(parameters), parameters.PageNumber, parameters.PageSize);
    }

    public async Task<StudentExam> FindStudentExambyId(int id, bool trackChanges)
    {
        return await _repository.StudentExam.FindById(id, trackChanges);
    }

    public void CreateStudentExam(StudentExam StudentExam)
    {
        _repository.StudentExam.Create(StudentExam);
    }

    public async Task DeleteStudentExam(int id)
    {
        StudentExam StudentExam = await FindStudentExambyId(id, trackChanges: true);
        _repository.StudentExam.Delete(StudentExam);
    }

    public StudentExamModel GetStudentExamById(int id)
    {
        return GetStudentExams(new StudentExamParameters { Id = id }).SingleOrDefault();
    }

    public int GetStudentExamCount()
    {
        return _repository.StudentExam.Count();
    }

    #endregion

    #region Student Exam Answer 
    public IQueryable<StudentExamAnswerModel> GetStudentExamAnswers(StudentExamAnswerParameters parameters)
    {
        return _repository.StudentExamAnswer
            .FindAll(parameters, trackChanges: false)
            .Select(a => new StudentExamAnswerModel
            {
                Id = a.Id,
                Fk_Answer = a.Fk_Answer,
                Answer = new AnswerModel
                {
                    AnswerText = a.Answer.AnswerText,
                    IsCorrect = a.Answer.IsCorrect
                },
                IsCorrect = a.IsCorrect,
                Fk_StudentExam = a.Fk_StudentExam,
                StudentExam = new StudentExamModel
                {
                    QuestionCount = a.StudentExam.QuestionCount,
                    SuccessCount = a.StudentExam.SuccessCount,
                    FailedCount = a.StudentExam.FailedCount,
                },
                Fk_Question = a.Fk_Question,
                Question = new QuestionModel
                {
                    QuestionText = a.Question.QuestionText,
                    QuestionType = a.Question.QuestionType
                },
                CreatedAt = a.CreatedAt,
            })
            .Search(parameters.SearchColumns, parameters.SearchTerm)
            .Sort(parameters.OrderBy);
    }

    public async Task<PagedList<StudentExamAnswerModel>> GetStudentExamAnswersPaged(
        StudentExamAnswerParameters parameters)
    {
        return await PagedList<StudentExamAnswerModel>.ToPagedList(GetStudentExamAnswers(parameters), parameters.PageNumber, parameters.PageSize);
    }

    public async Task<StudentExamAnswer> FindStudentExamAnswerbyId(int id, bool trackChanges)
    {
        return await _repository.StudentExamAnswer.FindById(id, trackChanges);
    }

    public void CreateStudentExamAnswer(StudentExamAnswer StudentExamAnswer)
    {
        _repository.StudentExamAnswer.Create(StudentExamAnswer);
    }

    public async Task DeleteStudentExamAnswer(int id)
    {
        StudentExamAnswer StudentExamAnswer = await FindStudentExamAnswerbyId(id, trackChanges: true);
        _repository.StudentExamAnswer.Delete(StudentExamAnswer);
    }

    public StudentExamAnswerModel GetStudentExamAnswerById(int id)
    {
        return GetStudentExamAnswers(new StudentExamAnswerParameters { Id = id }).SingleOrDefault();
    }

    public int GetStudentExamAnswerCount()
    {
        return _repository.StudentExamAnswer.Count();
    }

    #endregion
}