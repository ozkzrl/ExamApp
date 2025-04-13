
namespace MyMvcExamProject.Models
{
        public class ExamResultViewModel
    {
        public int Score { get; set; }
        public int TotalQuestions { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
