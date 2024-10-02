using BooksApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BooksApp.Controllers
{
    public class BooksController : Controller
    {
        // GET: BooksController
        [HttpGet]
        public IActionResult Index()
        {
            var book = new BookViewModel
            {
                Id = 1,
                Name = "First Book",
                Author = "Natalya Shulzhenka",
                Year = 2024
            };

            return View(book);
        }

        // GET: BooksController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BooksController/Create
        [HttpPost]
        public ActionResult Create([FromForm] BookViewModel model)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        // GET: BooksController/Edit/1
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: BooksController/Edit/1
        [HttpPost]
        public ActionResult Edit(int id, [FromForm] BookViewModel model)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Delete/1
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: BooksController/Delete/1
        [HttpPost]
        public ActionResult Delete(int id, [FromForm] BookViewModel model)
        {
            try
            {
                ViewBag.Message = $"Item 'Example{id}' has been deleted.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
