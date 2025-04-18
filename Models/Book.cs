using MyMvcExamProject.Data; // <-- Bunu mutlaka ekle
using Microsoft.EntityFrameworkCore;


namespace MyMvcExamProject.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
           public int Year { get; set; }
        
        // Kitapla ilişkili soruları içeren navigasyon özelliği
        public ICollection<Question> Questions { get; set; }
         public ICollection<ExamResult> ExamResults { get; set; } // Bu satırı ekleyin
    }
}
