using BooksApp.Domain.Entities;

namespace BooksApp.DAL.Repository.Interfaces;

public interface IFictionBooksRepository : IRepository<FictionBook>
{
    Task UpdateAsync(FictionBook entity);
}
