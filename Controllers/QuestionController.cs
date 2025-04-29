using Microsoft.AspNetCore.Mvc;
using MyMvcExamProject.Data;
using MyMvcExamProject.Models;

public class QuestionController : Controller
{
    private readonly ApplicationDbContext _context;

    public QuestionController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Kitaba ait soruları listele
    public IActionResult Index(int bookId)
    {
        var book = _context.Books.Find(bookId);
        if (book == null) return NotFound();

        var questions = _context.Questions
            .Where(q => q.BookId == bookId)
            .ToList();

        ViewBag.Book = book;
        return View(questions);
    }

    // Yeni soru ekle formu
    public IActionResult Create(int bookId)
    {
        ViewBag.BookId = bookId;
        return View();
    }

    [HttpPost]
    public IActionResult Create(Question question, List<string> options, int correctOptionIndex)
    {
        _context.Questions.Add(question);
        _context.SaveChanges();

        for (int i = 0; i < options.Count; i++)
        {
            var option = new Option
            {
                QuestionId = question.Id,
                Text = options[i],
                IsCorrect = (i == correctOptionIndex)
            };
            _context.Options.Add(option);
        }

        _context.SaveChanges();
        return RedirectToAction("Index", new { bookId = question.BookId });
    }

    // Buraya istersek Edit, Delete işlemleri de ekleriz.
}
