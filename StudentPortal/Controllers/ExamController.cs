using Entities.AuthenticationModels;
using Entities.CoreServicesModels.ExamModels;
using Entities.CoreServicesModels.StudentExamModels;
using Entities.DBModels.StudentExamModels;
using StudentPortal.ViewModel;

namespace StudentPortal.Controllers
{
    [Authorize]
    public class ExamController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExamController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            ViewData["Exams"] = _unitOfWork.Exam.GetExamsLookUp(new ExamParameters
            {
                IsPublished = true,
            });

            return View();
        }

        public ActionResult<ExamListViewModel> LoadTable(int fk_Exam)
        {
            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[HeadersConstants.User];

            ExamListViewModel examList = new()
            {
                StudentExams = _unitOfWork.StudentExam.GetStudentExams(new StudentExamParameters
                {
                    Fk_Student = auth.Fk_Student,
                    Fk_Exam = fk_Exam
                }).ToList()

            };
            return Ok(examList);
        }

        public IActionResult TakeExam()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TakeExam(int fk_Exam)
        {
            return !ModelState.IsValid
                ? View(fk_Exam)
                : fk_Exam == 0 ? RedirectToAction("Index") : View(_unitOfWork.Exam.GetFullExamById(fk_Exam));
        }

        [HttpPost]
        public async Task<IActionResult> SubmitExam(ExamSubmissionModel model)
        {
            if (!ModelState.IsValid)
            {
                List<string> errorMessages = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();

                return BadRequest(errorMessages);
            }

            try
            {
                UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[HeadersConstants.User];

                StudentExam studentExam = _unitOfWork.Exam.SubmitExam(model, auth.Fk_Student);

                _unitOfWork.StudentExam.CreateStudentExam(studentExam);

                await _unitOfWork.Save();

                return Ok(new
                {
                    studentExam.SuccessCount,
                    studentExam.QuestionCount
                });
            }
            catch (Exception ex)
            {
                ViewData["error"] = ex.Message;
            }

            return BadRequest(new List<string> { ViewData["error"].ToString() });
        }
    }
}
