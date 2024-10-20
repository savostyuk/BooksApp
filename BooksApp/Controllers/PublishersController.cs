using BooksApp.BLL.Interfaces;
using BooksApp.BLL.Services;
using BooksApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BooksApp.Web.Controllers
{
    public class PublishersController : Controller
    {
        private readonly IPublishersService<Publisher> _publishersService;

        public PublishersController(IPublishersService<Publisher> publishersService)
        {
            _publishersService = publishersService;
        }
        public async Task<IActionResult> Index()
        {
            var publishers = await _publishersService.GetAllAsync();

            return View(publishers);
        }

        public IActionResult GetPublisher(int id, string books)
        {
            var publisherBooks = new Dictionary<int, List<string>>()
            {
                {
                    1, new List<string> {"Math", "HarryPotter" }

                },
                { 2, new List <string>{"SilverSpoon", "Echo" }}
            };

            if (string.IsNullOrEmpty(books))
            {
                if (publisherBooks.TryGetValue(id, out var publisherCollection))
                {
                    ViewBag.Id = id;
                    ViewBag.Books = publisherCollection;

                    return View();
                }
                return Content("Publisher not found!");
            }

            var booksList = books.Split('/');

            if (publisherBooks.ContainsKey(id))
            {
                var foundBooks = new List<string>();

                foreach (var book in booksList)
                {
                    if (publisherBooks[id].Contains(book))
                    {
                        foundBooks.Add(book);
                    }
                }
                return View(foundBooks);
            }
            return Content("Publisher or books not found!");
        }
    }
}
