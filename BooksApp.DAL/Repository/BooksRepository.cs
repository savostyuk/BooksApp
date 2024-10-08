using Microsoft.EntityFrameworkCore;
using BooksApp.DAL.Data;
using BooksApp.Domain.Entities;

namespace BooksApp.DAL.Repository;

public class BooksRepository : IBooksRepository
{
    private readonly ApplicationDbContext _context;

    public BooksRepository (ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Book book)
    {
        await _context.Set<Book>().AddAsync(book);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var book = await _context.Set<Book>().FindAsync(id);

        if (book != null)
        {
            _context.Set<Book>().Remove(book);

            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _context.Set<Book>().ToListAsync();
    }

    public async Task<Book> GetByIdAsync(int id)
    {
        return await _context.Set<Book>().FindAsync(id);
    }

    public async Task UpdateAsync(Book book)
    {
        _context.Set<Book>().Update(book);

        await _context.SaveChangesAsync();
    }
}
