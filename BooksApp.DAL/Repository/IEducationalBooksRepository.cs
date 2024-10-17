using BooksApp.Domain.Entities;

namespace BooksApp.DAL.Repository;

public interface IEducationalBooksRepository : IRepository<EducationalBook>
{
    Task UpdateAsync(EducationalBook entity);
}
