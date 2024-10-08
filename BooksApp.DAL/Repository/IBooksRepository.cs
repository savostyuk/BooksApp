using BooksApp.Domain.Entities;

namespace BooksApp.DAL.Repository;

public interface IBooksRepository
{
    Task<Book> GetByIdAsync(int id);
    Task<IEnumerable<Book>> GetAllAsync();
    Task AddAsync(Book book);
    Task UpdateAsync(Book book);
    Task DeleteAsync(int id);
}
