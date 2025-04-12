
namespace MyMvcExamProject.Models
{
    public class ExamViewModel
    {
        public List<Question> Questions { get; set; } = new();
        public List<int?> UserAnswers { get; set; } = new();
    }
}
