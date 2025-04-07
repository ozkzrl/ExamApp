namespace MyMvcExamProject.Models
{
    public class Option
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }  // Question ile ilişki
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }

}