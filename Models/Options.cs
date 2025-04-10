using MyMvcExamProject.Data; // <-- Bunu mutlaka ekle



namespace MyMvcExamProject.Models
{
    public class Option
    {
        public int Id { get; set; }
        public int QuestionId { get; set; } // Soru ile ilişki
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        
        public Question Question { get; set; } // Şık, soru ile ilişkilidir
    }
}
