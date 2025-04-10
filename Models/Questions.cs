using MyMvcExamProject.Data; // <-- Bunu mutlaka ekle



namespace MyMvcExamProject.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }

        // Kitap ile ilişki
        public int BookId { get; set; }
        public Book Book { get; set; } // Soru, kitapla ilişkilidir

        // Şıklar ile ilişki
        public ICollection<Option> Options { get; set; }

        // Doğru şık
        public int CorrectOptionIndex { get; set; }
    }
}
