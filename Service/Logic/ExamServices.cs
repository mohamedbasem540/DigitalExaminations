using Entities.CoreServicesModels.ExamModels;
using Entities.DBModels.ExamModels;
using Entities.DBModels.StudentExamModels;

namespace CoreServices.Logic;

public class ExamServices : IExamServices
{
    private readonly IRepositoryManager _repository;

    public ExamServices(IRepositoryManager repository)
    {
        _repository = repository;
    }

    #region Answer
    public IQueryable<AnswerModel> GetAnswers(AnswerParameters parameters)
    {
        return _repository.Answer
            .FindAll(parameters, trackChanges: false)
            .Select(a => new AnswerModel
            {
                Id = a.Id,
                Fk_Question = a.Fk_Question,
                AnswerText = a.AnswerText,
                ImageUrl = a.StorageUrl + a.ImageUrl,
                IsCorrect = a.IsCorrect,
                CreatedAt = a.CreatedAt,
            })
            .Search(parameters.SearchColumns, parameters.SearchTerm)
            .Sort(parameters.OrderBy);
    }

    public async Task<PagedList<AnswerModel>> GetAnswersPaged(
        AnswerParameters parameters)
    {
        return await PagedList<AnswerModel>.ToPagedList(GetAnswers(parameters), parameters.PageNumber, parameters.PageSize);
    }

    public Dictionary<string, string> GetAnswersLookUp(AnswerParameters parameters)
    {
        return GetAnswers(parameters).ToDictionary(a => a.Id.ToString(),
            a => a.AnswerText);
    }

    public async Task<Answer> FindAnswerbyId(int id, bool trackChanges)
    {
        return await _repository.Answer.FindById(id, trackChanges);
    }

    public void CreateAnswer(Answer Answer)
    {
        _repository.Answer.Create(Answer);
    }

    public async Task DeleteAnswer(int id)
    {
        Answer Answer = await FindAnswerbyId(id, trackChanges: true);
        _repository.Answer.Delete(Answer);
    }

    public AnswerModel GetAnswerById(int id)
    {
        return GetAnswers(new AnswerParameters { Id = id }).SingleOrDefault();
    }

    public int GetAnswerCount()
    {
        return _repository.Answer.Count();
    }

    #endregion

    #region Exam
    public IQueryable<ExamModel> GetExams(ExamParameters parameters)
    {
        return _repository.Exam
                   .FindAll(parameters, trackChanges: false)
                   .Select(a => new ExamModel
                   {
                       Id = a.Id,
                       Name = a.Name,
                       Instrucations = a.Instrucations,
                       CreatedAt = a.CreatedAt,
                       QuestionsCount = a.Questions.Count,
                       Questions = parameters.IncludeFullExam ? a.Questions.Select(b => new QuestionModel
                       {
                           Id = b.Id,
                           Fk_Exam = b.Fk_Exam,
                           ImageUrl = b.StorageUrl + b.ImageUrl,
                           QuestionText = b.QuestionText,
                           QuestionType = b.QuestionType,
                           Answers = b.Answers.Select(c => new AnswerModel
                           {
                               Id = c.Id,
                               Fk_Question = c.Fk_Question,
                               AnswerText = c.AnswerText,
                               ImageUrl = c.StorageUrl + c.ImageUrl,
                               IsCorrect = c.IsCorrect,
                           }).ToList()
                       }).ToList() : null
                   })
                   .Search(parameters.SearchColumns, parameters.SearchTerm)
                   .Sort(parameters.OrderBy);
    }

    public async Task<PagedList<ExamModel>> GetExamsPaged(
              ExamParameters parameters)
    {
        return await PagedList<ExamModel>.ToPagedList(GetExams(parameters), parameters.PageNumber, parameters.PageSize);
    }

    public Dictionary<string, string> GetExamsLookUp(ExamParameters parameters)
    {
        return GetExams(parameters).ToDictionary(a => a.Id.ToString(),
            a => a.Name);
    }

    public async Task<Exam> FindExambyId(int id, bool trackChanges)
    {
        return await _repository.Exam.FindById(id, trackChanges);
    }

    public void CreateExam(Exam Exam)
    {
        _repository.Exam.Create(Exam);
    }

    public async Task DeleteExam(int id)
    {
        Exam Exam = await FindExambyId(id, trackChanges: true);
        _repository.Exam.Delete(Exam);
    }

    public ExamModel GetFullExamById(int id)
    {
        return GetExams(new ExamParameters { Id = id, IncludeFullExam = true }).SingleOrDefault();
    }

    public ExamModel GetExamById(int id)
    {
        return GetExams(new ExamParameters { Id = id }).SingleOrDefault();
    }

    public int GetExamCount()
    {
        return _repository.Exam.Count();
    }

    public StudentExam SubmitExam(ExamSubmissionModel model, int fk_Student)
    {
        StudentExam studentExam = new()
        {
            Fk_Exam = model.Id,
            Fk_Student = fk_Student,
            StudentExamAnswers = new List<StudentExamAnswer>(),
        };

        ExamModel exam = GetFullExamById(model.Id);

        studentExam.QuestionCount = exam.Questions.Count;

        foreach (QuestionModel question in exam.Questions)
        {
            if (model.Questions.Any(a => a.FK_Question == question.Id))
            {
                StudentExamAnswer studentExamAnswer = new()
                {
                    Fk_Question = question.Id,
                    Fk_StudentExam = studentExam.Id,
                    Fk_Answer = model.Questions.Where(a => a.FK_Question == question.Id).SingleOrDefault().Fk_Answer,
                };

                studentExam.StudentExamAnswers.Add(studentExamAnswer);

                if (studentExamAnswer.Fk_Answer == question.Answers.Where(a => a.IsCorrect).SingleOrDefault().Id)
                {
                    studentExam.SuccessCount++;
                }
            }
        }

        return studentExam;
    }

    #endregion

    #region Question
    public IQueryable<QuestionModel> GetQuestions(QuestionParameters parameters)
    {
        return _repository.Question
            .FindAll(parameters, trackChanges: false)
            .Select(a => new QuestionModel
            {
                Id = a.Id,
                Fk_Exam = a.Fk_Exam,
                CreatedAt = a.CreatedAt,
                ImageUrl = a.StorageUrl + a.ImageUrl,
                QuestionText = a.QuestionText,
                QuestionType = a.QuestionType,
            })
            .Search(parameters.SearchColumns, parameters.SearchTerm)
            .Sort(parameters.OrderBy);
    }

    public async Task<PagedList<QuestionModel>> GetQuestionsPaged(
        QuestionParameters parameters)
    {
        return await PagedList<QuestionModel>.ToPagedList(GetQuestions(parameters), parameters.PageNumber, parameters.PageSize);
    }

    public Dictionary<string, string> GetQuestionsLookUp(QuestionParameters parameters)
    {
        return GetQuestions(parameters).ToDictionary(a => a.Id.ToString(),
            a => a.QuestionText);
    }

    public async Task<Question> FindQuestionbyId(int id, bool trackChanges)
    {
        return await _repository.Question.FindById(id, trackChanges);
    }

    public void CreateQuestion(Question Question)
    {
        _repository.Question.Create(Question);
    }

    public async Task DeleteQuestion(int id)
    {
        Question Question = await FindQuestionbyId(id, trackChanges: true);
        _repository.Question.Delete(Question);
    }

    public QuestionModel GetQuestionById(int id)
    {
        return GetQuestions(new QuestionParameters { Id = id }).SingleOrDefault();
    }

    public int GetQuestionCount()
    {
        return _repository.Question.Count();
    }

    #endregion
}