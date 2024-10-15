using BooksApp.BLL.Interfaces;
using BooksApp.Domain.Entities;
using BooksApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        // GET: BooksController
        public IActionResult Index()
        {
            var books = _booksService.GetAllBooks();

            var bookViewModels = books?.Select(book => new BookViewModel
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Year = book.Year,

            }).ToList();

            return View(bookViewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] BookViewModel book)
        {
            if (ModelState.IsValid)
            {
                _booksService.AddBook(new FictionBook
                {
                    Id = book.Id,
                    Name = book.Name,
                    Author = book.Author,
                    Year = book.Year,
                });

                return RedirectToAction(nameof(Index));
            }

            return View(book);
        }

        public IActionResult Edit(int id)
        {
            var book = _booksService.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }

            var bookViewModel = new BookViewModel
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Year = book.Year,
            };

            return View(bookViewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, [FromForm] BookViewModel book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            var existingBook = _booksService.GetBookById(id);

            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.Name = book.Name;
            existingBook.Author = book.Author;
            existingBook.Year = book.Year;

            _booksService.UpdateBook(existingBook);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var book = _booksService.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }

            var bookViewModel = new BookViewModel
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Year = book.Year,
            };

            return View(bookViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _booksService.GetBookById(id);

            if (book != null)
            {
                _booksService.DeleteBook(book.Id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}