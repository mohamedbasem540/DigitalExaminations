using Entities.RequestFeatures;
using static Entities.EnumData.DBEnum;

namespace Entities.CoreServicesModels.ExamModels
{
    public class QuestionParameters : RequestParameters
    {
        public int Fk_Exam { get; set; }
    }

    public class QuestionModel : ImageEntity
    {
        [ForeignKey(nameof(Exam))]
        [DisplayName(nameof(Exam))]
        public int Fk_Exam { get; set; }

        [DisplayName(nameof(Exam))]
        public ExamModel Exam { get; set; }

        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName(nameof(QuestionText))]
        [DataType(DataType.MultilineText)]
        public string QuestionText { get; set; }

        [DisplayName(nameof(QuestionType))]
        public QuestionTypeEnum QuestionType { get; set; }

        [DisplayName(nameof(Answers))]
        public List<AnswerModel> Answers { get; set; }
    }

    public class QuestionSubmissionModel
    {
        [DisplayName(nameof(FK_Question))]
        public int FK_Question { get; set; }

        [DisplayName(nameof(Fk_Answer))]
        public int Fk_Answer { get; set; }
    }
}
