using BooksApp.Domain.Entities;

namespace BooksApp.BLL.Interfaces;

public interface IEducationalBooksService
{
    Task<EducationalBook> CreateEduBookAsync(EducationalBook eduBook);
    Task<EducationalBook> GetEduBookByIdAsync(int id);
    Task<IEnumerable<EducationalBook>> GetAllEduBooksAsync();
    Task<EducationalBook> UpdateEduBookAsync(EducationalBook eduBook);
    Task DeleteEduBookAsync(int id);
}
