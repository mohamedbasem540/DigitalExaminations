using Entities.RequestFeatures;

namespace Entities.CoreServicesModels.ExamModels
{
    public class AnswerParameters : RequestParameters
    {
        public int Fk_Question { get; set; }
    }

    public class AnswerModel : ImageEntity
    {
        [ForeignKey(nameof(Question))]
        [DisplayName(nameof(Question))]
        public int Fk_Question { get; set; }

        [DisplayName(nameof(Question))]
        public QuestionModel Question { get; set; }

        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName(nameof(AnswerText))]
        [DataType(DataType.MultilineText)]
        public string AnswerText { get; set; }

        [DisplayName(nameof(IsCorrect))]
        public bool IsCorrect { get; set; }
    }
}
