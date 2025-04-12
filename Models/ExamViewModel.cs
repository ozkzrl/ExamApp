
namespace MyMvcExamProject.Models
{
public class ExamViewModel
{
    public List<Question> Questions { get; set; } // Sadece soruları içeren bir liste
    public List<int?> UserAnswers { get; set; } // Kullanıcı cevapları için bir liste
    public Book Book { get; set; } // Kitap bilgisi ekleyin
}

}
