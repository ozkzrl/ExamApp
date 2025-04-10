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
            return View(questions);
        }

        [HttpPost]
        public IActionResult Submit(List<int> userAnswers)
        {
            var questions = _context.Questions.Include(q => q.Options).ToList();

            if (userAnswers == null || userAnswers.Count != questions.Count)
            {
                ModelState.AddModelError("", "Lütfen tüm soruları cevaplayınız.");
                return View("Index", questions);
            }

            int score = 0;

            for (int i = 0; i < questions.Count; i++)
            {
                var correctOption = questions[i].Options.FirstOrDefault(o => o.IsCorrect);

                if (correctOption != null && userAnswers[i] == correctOption.Id)
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