using BooksApp.Domain.Entities;

namespace BooksApp.DAL.Repository.Interfaces;

public interface IEducationalBooksRepository : IRepository<EducationalBook>
{
    Task UpdateAsync(EducationalBook entity);
}
