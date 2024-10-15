using BooksApp.BLL.DTO;
using BooksApp.BLL.Interfaces;
using BooksApp.DAL.Repositories.Interfaces;
using BooksApp.Domain.Entities;


namespace BooksApp.BLL.Services;

public class EducationalBooksService: IEducationalBooksService
{
    private readonly IEducationalBooksRepository _repository;
    public EducationalBooksService(IEducationalBooksRepository repository)
    {
        _repository = repository;
    }
    public async Task<EducationalBook> CreateEduBookAsync(EducationalBook eduBook)
    {
        await _repository.AddAsync(eduBook);
        return eduBook;
    }
    public async Task<IEnumerable<EducationalBook>> GetAllEduBooksAsync()
    {
        return await _repository.GetAllAsync();
    }
    public async Task<EducationalBook> GetEduBookByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }
    public async Task<EducationalBook> UpdateEduBookAsync(EducationalBook eduBook)
    {
        await _repository.UpdateAsync(eduBook);
        return eduBook;
    }
    public async Task DeleteEduBookAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
    // Filter by Name
    public async Task<IEnumerable<EducationalBook>> GetEduBookByNameAsync(string name)
    {
        var allEduBooks = await _repository.GetAllAsync();
        return allEduBooks.Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
    }
    // Sort by Name
    public async Task<IEnumerable<EducationalBook>> GetSortedEduBooksAsync()
    {
        var allEduBooks = await _repository.GetAllAsync();
        return allEduBooks.OrderBy(s => s.Name).ToList();
    }
    // Project to DTO
    public async Task<IEnumerable<EducationalBookDTO>> GetEduBooklDtosAsync()
    {
        var allEduBooks = await _repository.GetAllAsync();
        return allEduBooks.Select(s => new EducationalBookDTO
        {
            Id = s.Id,
            Name = s.Name
        }).ToList();
    }
}
