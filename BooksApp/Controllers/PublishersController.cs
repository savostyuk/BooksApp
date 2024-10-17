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
    }
}
