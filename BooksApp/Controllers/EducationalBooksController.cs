using BooksApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using BooksApp.BLL.Interfaces;
using FluentValidation;

namespace BooksApp.Web.Controllers;

public class EducationalBooksController : Controller
{
    private readonly IBooksService<EducationalBook> _booksService;
    private readonly IValidator<EducationalBook> _validator;
    private readonly ILogger<EducationalBooksController> _logger;

    public EducationalBooksController (IBooksService<EducationalBook> booksService, 
        IValidator<EducationalBook> validator, 
        ILogger<EducationalBooksController> logger)
    {
        _booksService = booksService;
        _validator = validator;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        _logger.LogInformation("Entering Index() method");

        try
        {
            var books = await _booksService.GetAllAsync();
            _logger.LogInformation("Successfully retrieved books in Index()");

            return View(books);
        }
        catch (Exception ex) 
        { 
            _logger.LogInformation(ex, "Error occurred in Index()");

            return StatusCode(500, "An error occurred");
        }
    }

    public async Task<IActionResult> Details(int id)
    {
        _logger.LogInformation($"Entering Details() method with id {id}");

        try
        {
            var book = await _booksService.GetByIdAsync(id);

            if (book == null)
            {
                _logger.LogWarning($"Book with id {id} not found in Details()");

                return NotFound();
            }

            _logger.LogInformation($"Successfully retrieved book with id {id} in Details()");

            return View(book);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred in Details() with id {id}");

            return StatusCode(500, "An error occurred");
        }
    }
    public IActionResult Create()
    {
        _logger.LogInformation("Entering Create() GET method");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(EducationalBook book)
    {
        _logger.LogInformation("Entering Create() POST method");

        var result = await _validator.ValidateAsync(book);

        if (!result.IsValid)
        {
            _logger.LogWarning("Validation failed in Create() POST method");

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                _logger.LogWarning($"Validation error: {error.ErrorMessage} on {error.PropertyName}");
            }

            return View(book);
        }

        try
        {
            await _booksService.CreateAsync(book);
            _logger.LogInformation("Successfully created a book in Create() POST method");

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred in Create() POST method");

            return StatusCode(500, "An error occurred");
        }
    }

    public async Task<IActionResult> Edit(int id)
    {
        _logger.LogInformation($"Entering Edit() GET method with id {id}");

        try
        {
            var book = await _booksService.GetByIdAsync(id);

            if (book == null)
            {
                _logger.LogWarning($"Book with id {id} not found in Edit() GET method");

                return NotFound();
            }
            return View(book);
        }
        catch (Exception ex) 
        {
            _logger.LogError(ex, $"Error occurred in Edit() GET method with id {id}");

            return StatusCode(500, "An error occurred");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, EducationalBook book)
    {
        _logger.LogInformation($"Entering Edit() POST method with id {id}");

        if (id != book.Id)
        {
            _logger.LogWarning("Book id mismatch in Edit() POST method");

            return BadRequest();
        }
        if (ModelState.IsValid)
        {
            try
            {
                await _booksService.UpdateAsync(book);
                _logger.LogInformation($"Successfully updated book with id {id} in Edit() POST method");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating book with id {id} in Edit() POST method");

                return StatusCode(500, "An error occurred");
            }
        }

        _logger.LogWarning($"ModelState is invalid in Edit() POST method with id {id}");

        return View(book);
    }

    public async Task<IActionResult> Delete(int id)
    {
        _logger.LogInformation($"Entering Delete() GET method with id {id}");

        try
        {
            var book = await _booksService.GetByIdAsync(id);

            if (book == null)
            {
                _logger.LogWarning($"Book with id {id} not found in Delete() GET method");

                return NotFound();
            }
            return View(book);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred in Delete() GET method with id {id}");

            return StatusCode(500, "An error occurred");
        }
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        _logger.LogInformation($"Entering DeleteConfirmed() POST method with id {id}");

        try
        {
            await _booksService.DeleteAsync(id);
            _logger.LogInformation($"Successfully deleted book with id {id} in DeleteConfirmed() POST method");

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while deleting book with id {id} in DeleteConfirmed() POST method");

            return StatusCode(500, "An error occurred");
        }
    }
}
