using Microsoft.AspNetCore.Mvc;
using MyMvcExamProject.Models;
using MyMvcExamProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Linq;

namespace MyMvcExamProject.Controllers
{
    public class ExamController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ExamController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int bookId)
        {
            var questions = await _context.Questions
                .Where(q => q.BookId == bookId)
                .Include(q => q.Options)
                .ToListAsync();

            var book = await _context.Books.FindAsync(bookId);

            var model = new ExamViewModel
            {
                Book = book,
                Questions = questions,
                UserAnswers = new List<int?>(new int?[questions.Count]),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Submit(ExamViewModel model)
        {
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
                model.Questions = questions;
                model.Book = await _context.Books.FindAsync(model.BookId);
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

            var user = await _userManager.GetUserAsync(User);
            var result = new ExamResult
            {
                BookId = model.BookId,  // ExamId yerine BookId
                UserId = user.Id,
                Score = score,
                TakenAt = DateTime.UtcNow
            };
            _context.ExamResults.Add(result);
            await _context.SaveChangesAsync();

            var resultModel = new ExamResultViewModel
            {
                Score = score,
                TotalQuestions = questions.Count,
                BookId = model.BookId,
                Book = await _context.Books.FindAsync(model.BookId)
            };

            return View("Result", resultModel);
        }

        public async Task<IActionResult> Results()
        {
            var user = await _userManager.GetUserAsync(User);
            var results = await _context.ExamResults
                .Include(er => er.Book) // Hatalı Exam yerine doğru olan Book kullanılıyor
                .Where(er => er.UserId == user.Id)
                .ToListAsync();

            return View(results);
        }

    }
}
