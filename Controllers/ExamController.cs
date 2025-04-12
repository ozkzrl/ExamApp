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
public IActionResult Submit(ExamViewModel model)
{
    var questions = model.Questions;

    // Check if UserAnswers is null or not of the same length as Questions
    if (model.UserAnswers == null || model.UserAnswers.Count != questions.Count)
    {
        // Initialize UserAnswers if it's null or its count is incorrect
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
        ModelState.AddModelError("", "Lütfen tüm soruları cevaplayınız.");
        return View("Index", model);
    }

    // Handle score calculation logic
    int score = 0;
    for (int i = 0; i < questions.Count; i++)
    {
        var correctOption = questions[i].Options.FirstOrDefault(o => o.IsCorrect);
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
