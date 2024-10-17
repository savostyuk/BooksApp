using BooksApp.BLL.Interfaces;
using BooksApp.DAL.Repository.Interfaces;
using BooksApp.Domain.Entities;

namespace BooksApp.BLL.Services;

public class EducationalBooksService: IBooksService<EducationalBook>
{
    private readonly IEducationalBooksRepository _repository;
    public EducationalBooksService(IEducationalBooksRepository repository)
    {
        _repository = repository;
    }

    public async Task<EducationalBook> CreateAsync(EducationalBook entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        return await _repository.CreateAsync(entity);
    }
    public async Task<EducationalBook> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }
    public async Task<IEnumerable<EducationalBook>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
    public async Task UpdateAsync(EducationalBook entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        await _repository.UpdateAsync(entity);
    }
    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
