using BooksApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using BooksApp.BLL.Interfaces;

namespace BooksApp.Web.Controllers;

public class FictionBooksController : Controller
{
    private readonly IBooksService<FictionBook> _booksService;

    public FictionBooksController(IBooksService<FictionBook> booksService)
    {
        _booksService = booksService;
    }

    public async Task<IActionResult> Index()
    {
        var books = await _booksService.GetAllAsync();

        return View(books);
    }

    public async Task<IActionResult> Details(int id)
    {
        var book = await _booksService.GetByIdAsync(id);

        if (book == null)
        {
            return NotFound();
        }
        return View(book);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(FictionBook book)
    {
        if (ModelState.IsValid)
        {
            await _booksService.CreateAsync(book);
            TempData["SuccessMessage"] = "Data saved successfully!";

            return RedirectToAction(nameof(Index));
        }
        return View(book);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var book = await _booksService.GetByIdAsync(id);

        if (book == null)
        {
            return NotFound();
        }
        return View(book);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, FictionBook book)
    {
        if (id != book.Id)
        {
            return BadRequest();
        }
        if (ModelState.IsValid)
        {
            await _booksService.UpdateAsync(book);
            TempData["SuccessMessage"] = "Data saved successfully!";

            return RedirectToAction(nameof(Index));
        }
        return View(book);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var book = await _booksService.GetByIdAsync(id);

        if (book == null)
        {
            return NotFound();
        }
        return View(book);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _booksService.DeleteAsync(id);
        TempData["SuccessMessage"] = "Data saved successfully!";

        return RedirectToAction(nameof(Index));
    }
}
