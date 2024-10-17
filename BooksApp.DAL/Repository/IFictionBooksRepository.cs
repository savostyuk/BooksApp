using BooksApp.Domain.Entities;

namespace BooksApp.DAL.Repository;

public interface IFictionBooksRepository : IRepository<FictionBook>
{
    Task UpdateAsync(FictionBook entity);
}
