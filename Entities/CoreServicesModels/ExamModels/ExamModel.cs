using Entities.RequestFeatures;

namespace Entities.CoreServicesModels.ExamModels
{
    public class ExamParameters : RequestParameters
    {
        public bool IncludeFullExam { get; set; }

        public bool? IsPublished { get; set; }
    }

    public class ExamModel : BaseEntity
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [StringLength(100, ErrorMessage = PropertyAttributeConstants.StringLength100Msg)]
        [DisplayName(nameof(Name))]
        public string Name { get; set; }

        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName(nameof(Instrucations))]
        [DataType(DataType.MultilineText)]
        public string Instrucations { get; set; }

        [DisplayName(nameof(IsPublished))]
        public bool IsPublished { get; set; }

        public int QuestionsCount { get; set; }

        [DisplayName(nameof(Questions))]
        public List<QuestionModel> Questions { get; set; }
    }

    public class ExamSubmissionModel
    {
        [DisplayName(nameof(Id))]
        public int Id { get; set; }

        [Required]
        public List<QuestionSubmissionModel> Questions { get; set; }
    }

}
