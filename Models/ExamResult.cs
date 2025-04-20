
using MyMvcExamProject.Models;

namespace MyMvcExamProject.Models
{
    public class ExamResult
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int Score { get; set; }
        public int TotalQuestions { get; set; }
        public DateTime TakenAt { get; set; }
    }
}
