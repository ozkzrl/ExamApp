using Microsoft.AspNetCore.Identity;
using MyMvcExamProject.Models;

public class ApplicationUser : IdentityUser
{
    public string? FullName { get; set; } // Ad Soyad
    public DateTime? BirthDate { get; set; } // Doğum tarihi
    public string? Gender { get; set; } // Cinsiyet (İstersen enum olarak da tanımlayabilirsin)
    public string? ProfilePictureUrl { get; set; } // Profil fotoğrafı
    public DateTime? RegisteredAt { get; set; } = DateTime.UtcNow; // Kayıt tarihi
    public bool IsPremiumUser { get; set; } // Örneğin ücretli kullanıcı mı?
    public string? SchoolName { get; set; } // Okul bilgisi

    // Navigasyon özelliği (ilişkili sınav sonuçları)
    public ICollection<ExamResult> ExamResults { get; set; }
}


