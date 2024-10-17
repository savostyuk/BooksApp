using BooksApp.BLL.Interfaces;
using BooksApp.Domain.Entities;
using BooksApp.DAL.Repository;
namespace BooksApp.BLL.Services;

public class FictionBookService : IBooksService<FictionBook>
{

    private readonly IFictionBooksRepository _repository;
    public FictionBookService(IFictionBooksRepository repository)
    {
        _repository = repository;
    }

    public async Task<FictionBook> CreateAsync(FictionBook entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        return await _repository.CreateAsync(entity);
    }
    public async Task<FictionBook> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }
    public async Task<IEnumerable<FictionBook>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
    public async Task UpdateAsync(FictionBook entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        await _repository.UpdateAsync(entity);
    }
    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
