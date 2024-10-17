using BooksApp.Domain.Entities;

namespace BooksApp.DAL.Repository;

public interface IPublisherRepository : IRepository<Publisher>
{
    Task UpdateAsync(Publisher entity);
}

