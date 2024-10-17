using BooksApp.Domain.Entities;

namespace BooksApp.DAL.Repository.Interfaces;

public interface IPublisherRepository : IRepository<Publisher>
{
    Task UpdateAsync(Publisher entity);
}

