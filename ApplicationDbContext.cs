using Microsoft.EntityFrameworkCore;
using MyMvcExamProject.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Question> Questions { get; set; }
    public DbSet<Option> Options { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // Soruları ekleyelim
    modelBuilder.Entity<Question>().HasData(
        new Question { Id = 1, Text = "George ve Lennie'nin çiftlikte çalışmaya gitme amacı nedir?", CorrectOptionIndex = 0 },
        new Question { Id = 2, Text = "Lennie neden başlarını belaya sokar?", CorrectOptionIndex = 1 },
        new Question { Id = 3, Text = "Lennie'nin en büyük hayali nedir?", CorrectOptionIndex = 0 },
        new Question { Id = 4, Text = "George, Lennie ile ilgili ne kadar endişelenmektedir?", CorrectOptionIndex = 2 },
        new Question { Id = 5, Text = "Çiftlikte çalışmak isteyenlerin motivasyonu nedir?", CorrectOptionIndex = 0 },
        new Question { Id = 6, Text = "Lennie'nin başına gelen olaylar neden genellikle trajik sonuçlanır?", CorrectOptionIndex = 1 },
        new Question { Id = 7, Text = "George ve Lennie'nin hayalini paylaştığı çiftlikte ne tür bir hayat yaşamayı planlarlar?", CorrectOptionIndex = 3 },
        new Question { Id = 8, Text = "George, Lennie'yi hangi durumlarda savunur?", CorrectOptionIndex = 2 },
        new Question { Id = 9, Text = "Lennie'nin zihinsel engelli olmasının etkileri nelerdir?", CorrectOptionIndex = 0 },
        new Question { Id = 10, Text = "Hangi olay, George'un Lennie'yi öldürmesini zorunlu kılar?", CorrectOptionIndex = 3 }
    );        
       
    // Şıkları ekleyelim
    modelBuilder.Entity<Option>().HasData(
        new Option { Id = 1, QuestionId = 1, Text = "Para kazanmak", IsCorrect = true },
        new Option { Id = 2, QuestionId = 1, Text = "Arkadaş bulmak", IsCorrect = false },
        new Option { Id = 3, QuestionId = 1, Text = "Macera yaşamak", IsCorrect = false },
        new Option { Id = 4, QuestionId = 1, Text = "Okula gitmek", IsCorrect = false },

        new Option { Id = 5, QuestionId = 2, Text = "Yalan söylediği için", IsCorrect = false },
        new Option { Id = 6, QuestionId = 2, Text = "Güçlü ama zihinsel engelli olduğu için", IsCorrect = true },
        new Option { Id = 7, QuestionId = 2, Text = "Hırsızlık yaptığı için", IsCorrect = false },
        new Option { Id = 8, QuestionId = 2, Text = "George'u kıskandığı için", IsCorrect = false },

        new Option { Id = 9, QuestionId = 3, Text = "Büyük bir çiftlik kurmak", IsCorrect = true },
        new Option { Id = 10, QuestionId = 3, Text = "Yazın okula gitmek", IsCorrect = false },
        new Option { Id = 11, QuestionId = 3, Text = "Zengin olmak", IsCorrect = false },
        new Option { Id = 12, QuestionId = 3, Text = "Tatile gitmek", IsCorrect = false },

        new Option { Id = 13, QuestionId = 4, Text = "Çiftlikteki diğer işçilerin tavrı", IsCorrect = false },
        new Option { Id = 14, QuestionId = 4, Text = "Lennie'nin zihinsel engeli", IsCorrect = false },
        new Option { Id = 15, QuestionId = 4, Text = "George'un arkadaşlık anlayışı", IsCorrect = true },
        new Option { Id = 16, QuestionId = 4, Text = "Çiftlik işlerinin zor olması", IsCorrect = false },

        new Option { Id = 17, QuestionId = 5, Text = "Zenginleşme ve güç kazanma", IsCorrect = false },
        new Option { Id = 18, QuestionId = 5, Text = "Huzurlu bir yaşam kurma", IsCorrect = true },
        new Option { Id = 19, QuestionId = 5, Text = "Büyük bir çiftlik kurma", IsCorrect = false },
        new Option { Id = 20, QuestionId = 5, Text = "Görkemli bir ev inşa etme", IsCorrect = false },

        new Option { Id = 21, QuestionId = 6, Text = "Çevresindeki insanlara zarar vermek", IsCorrect = false },
        new Option { Id = 22, QuestionId = 6, Text = "Zihinsel engelinin kontrolsüz bir şekilde ortaya çıkması", IsCorrect = true },
        new Option { Id = 23, QuestionId = 6, Text = "Gözyaşlarını tutamaması", IsCorrect = false },
        new Option { Id = 24, QuestionId = 6, Text = "Başka insanları kıskanması", IsCorrect = false },

        new Option { Id = 25, QuestionId = 7, Text = "Yeni insanlar tanımak", IsCorrect = false },
        new Option { Id = 26, QuestionId = 7, Text = "Büyük bir çiftlikte çalışmak", IsCorrect = false },
        new Option { Id = 27, QuestionId = 7, Text = "Güvenli bir yaşam sürmek", IsCorrect = false },
        new Option { Id = 28, QuestionId = 7, Text = "Kendi çiftliklerine sahip olmak", IsCorrect = true },

        new Option { Id = 29, QuestionId = 8, Text = "Onun adına parayı almak", IsCorrect = false },
        new Option { Id = 30, QuestionId = 8, Text = "Ona güvenmek ve korumak", IsCorrect = true },
        new Option { Id = 31, QuestionId = 8, Text = "Başka insanlara yardım etmek", IsCorrect = false },
        new Option { Id = 32, QuestionId = 8, Text = "Kendi çıkarlarını savunmak", IsCorrect = false },

        new Option { Id = 33, QuestionId = 9, Text = "Düşünmeden hareket etmesi", IsCorrect = true },
        new Option { Id = 34, QuestionId = 9, Text = "Çevresindeki insanları sevmesi", IsCorrect = false },
        new Option { Id = 35, QuestionId = 9, Text = "George'a duyduğu hayranlık", IsCorrect = false },
        new Option { Id = 36, QuestionId = 9, Text = "Kendi gücünü fark etmesi", IsCorrect = false },

        new Option { Id = 37, QuestionId = 10, Text = "Bir başkasına zarar vermek", IsCorrect = false },
        new Option { Id = 38, QuestionId = 10, Text = "Lennie'nin yanlış anlaması", IsCorrect = true },
        new Option { Id = 39, QuestionId = 10, Text = "Çiftlikteki diğer işçilerin sorumsuzluğu", IsCorrect = false },
        new Option { Id = 40, QuestionId = 10, Text = "Çiftlik yöneticisinin cezalandırması", IsCorrect = false }

        
    );
}

}
