using Microsoft.AspNetCore.Mvc;
using MyMvcExamProject.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyMvcExamProject.Data; // <-- Bunu mutlaka ekle
using Microsoft.AspNetCore.Authorization;



namespace MyMvcExamProject.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchTerm)
        {
            List<Book> books;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                books = await _context.Books
                    .Where(b => b.Title.Contains(searchTerm))
                    .OrderByDescending(b => b.Id)
                    .ToListAsync();
            }
            else
            {
                books = await _context.Books
                    .OrderByDescending(b => b.Id)
                    .Take(10)
                    .ToListAsync();
            }

            return View(books);
        }


        public async Task<IActionResult> BooksIndex()
        {
            return View(await _context.Books.ToListAsync());
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminBooksIndex()
        {
            return View(await _context.Books.ToListAsync());
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {

            _context.Add(book);
            await _context.SaveChangesAsync();
            return RedirectToAction("AdminBooksIndex");

        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();
            return View(book);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(Book book)
        {

            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return RedirectToAction("AdminBooksIndex");


        }

        // GET: Books/Delete/9
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/DeleteConfirmed/9
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("AdminBooksIndex");
        }
    }
}
