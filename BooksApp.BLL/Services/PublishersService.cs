using BooksApp.BLL.Interfaces;
using BooksApp.DAL.Repository.Interfaces;
using BooksApp.Domain.Entities;

namespace BooksApp.BLL.Services;

public class PublishersService : IPublishersService<Publisher>
{
    private readonly IPublisherRepository _repository;
    public PublishersService(IPublisherRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Publisher>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
}
