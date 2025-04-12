using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMvcExamProject.Models;
using MyMvcExamProject.Data; // <-- Bunu mutlaka ekle

namespace ExamApp.Controllers
{
    public class ExamController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Constructor'da DbContext'i alıyoruz
        public ExamController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Ana sayfa, soruları ve seçenekleri veritabanından alıyor
        public async Task<IActionResult> Index()
        {
            var questions = await _context.Questions.Include(q => q.Options).ToListAsync();
            var model = new ExamViewModel
            {
                Questions = questions,
                UserAnswers = new List<int?>(new int?[questions.Count]) // Hepsi null başlangıçta
            };
            return View(model);
        }

       [HttpPost]
public IActionResult Submit(ExamViewModel model)
{
    var questions = _context.Questions.Include(q => q.Options).ToList();
    model.Questions = questions;

    // Kullanıcının gönderdiği cevap listesi eksikse tamamla
    if (model.UserAnswers == null)
    {
        model.UserAnswers = new List<int?>(new int?[questions.Count]);
    }

    // Boş bırakılan soruları kontrol et
    bool hasEmptyAnswers = false;
    for (int i = 0; i < questions.Count; i++)
    {
        if (model.UserAnswers.Count <= i || model.UserAnswers[i] == null)
        {
            hasEmptyAnswers = true; // Boş bir cevap var
        }
    }

    // Eğer en az bir soru boş bırakıldıysa hata mesajı göster
    if (hasEmptyAnswers)
    {
        ModelState.AddModelError("", "Lütfen tüm soruları cevaplayınız.");
        return View("Index", model);
    }

    // Tüm sorulara cevap verildiyse puanı hesapla
    int score = 0;
    for (int i = 0; i < questions.Count; i++)
    {
        var correctOption = questions[i].Options.FirstOrDefault(o => o.IsCorrect);
        // Cevap doğruysa puanı artır
        if (correctOption != null && model.UserAnswers[i] == correctOption.Id)
        {
            score++;
        }
    }

    var resultModel = new ExamResultViewModel
    {
        Score = score,
        TotalQuestions = questions.Count
    };

    return View("Result", resultModel);
}

    }

}