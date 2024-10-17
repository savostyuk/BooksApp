namespace BooksApp.BLL.Interfaces;

public interface IPublishersService<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
}
