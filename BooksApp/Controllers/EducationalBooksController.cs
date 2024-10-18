using BooksApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using BooksApp.BLL.Interfaces;
using FluentValidation;

namespace BooksApp.Web.Controllers;

public class EducationalBooksController : Controller
{

    private readonly IBooksService<EducationalBook> _booksService;
    private readonly IValidator<EducationalBook> _validator;

    public EducationalBooksController (IBooksService<EducationalBook> booksService, IValidator<EducationalBook> validator)
    {
        _booksService = booksService;
        _validator = validator;
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
    public async Task<IActionResult> Create(EducationalBook book)
    {
        var result = await _validator.ValidateAsync(book);

        if (!result.IsValid)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return View(book);
        }

        await _booksService.CreateAsync(book);
        return RedirectToAction(nameof(Index));

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
    public async Task<IActionResult> Edit(int id, EducationalBook book)
    {
        if (id != book.Id)
        {
            return BadRequest();
        }
        if (ModelState.IsValid)
        {
            await _booksService.UpdateAsync(book);
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
        return RedirectToAction(nameof(Index));
    }
}
