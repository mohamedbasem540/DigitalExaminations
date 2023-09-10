using Entities.CoreServicesModels.StudentExamModels;

namespace StudentPortal.ViewModel
{
    public class ExamListViewModel
    {
        public Dictionary<string, string> Exams { get; set; }

        public List<StudentExamModel> StudentExams { get; set; }
    }
}
