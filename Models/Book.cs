using MyMvcExamProject.Data; // <-- Bunu mutlaka ekle
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using MyMvcExamProject.Models;




namespace MyMvcExamProject.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık zorunludur.")]
        public string Title { get; set; } = null;

        [Required(ErrorMessage = "Yazar adı zorunludur.")]
        public string Author { get; set; } = null;

        [Required]
        [Range(1, 3000, ErrorMessage = "Geçerli bir yıl giriniz.")]
        public int Year { get; set; }

        // Kitapla ilişkili soruları içeren navigasyon özelliği
        public ICollection<Question> Questions { get; set; }
        public ICollection<ExamResult> ExamResults { get; set; } // Bu satırı ekleyin
    }
}
