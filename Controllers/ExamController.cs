using Microsoft.AspNetCore.Mvc;
using MyMvcExamProject.Models;
using MyMvcExamProject.Data;
using Microsoft.EntityFrameworkCore;

namespace MyMvcExamProject.Controllers
{
    public class ExamController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExamController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int bookId)
        {
            var questions = await _context.Questions
                .Where(q => q.BookId == bookId)
                .Include(q => q.Options)
                .ToListAsync();

            var book = await _context.Books.FindAsync(bookId);  // Kitap bilgilerini al

            var model = new ExamViewModel
            {
                Book = book,  // Kitap bilgilerini modelin içine ekle
                Questions = questions,
                UserAnswers = new List<int?>(new int?[questions.Count]),
            };

            return View(model);
        }
       [HttpPost]
public async Task<IActionResult> Submit(ExamViewModel model)
{
    // Soruları veritabanından tekrar al
    var questions = await _context.Questions
        .Where(q => q.BookId == model.BookId)
        .Include(q => q.Options)
        .ToListAsync();

    if (model.UserAnswers == null || model.UserAnswers.Count != questions.Count)
    {
        model.UserAnswers = new List<int?>(new int?[questions.Count]);
    }

    bool hasEmptyAnswers = false;
    for (int i = 0; i < questions.Count; i++)
    {
        if (model.UserAnswers.Count <= i || model.UserAnswers[i] == null)
        {
            hasEmptyAnswers = true;
        }
    }

    if (hasEmptyAnswers)
    {
        model.Questions = questions; // Geri dönerken tekrar doldur
        model.Book = await _context.Books.FindAsync(model.BookId); // Kitap bilgisi de lazım
        ModelState.AddModelError("", "Lütfen tüm soruları cevaplayınız.");
        return View("Index", model);
    }

    int score = 0;
    for (int i = 0; i < questions.Count; i++)
    {
        var correctOption = questions[i].Options.FirstOrDefault(o => o.IsCorrect);
        if (correctOption != null && model.UserAnswers[i] == correctOption.Id)
        {
            score++;
        }
    }

    var book = await _context.Books.FindAsync(model.BookId);

    var resultModel = new ExamResultViewModel
    {
        Score = score,
        TotalQuestions = questions.Count,
        BookId = model.BookId,
        Book = book
    };

    return View("Result", resultModel);
}

    }
}
