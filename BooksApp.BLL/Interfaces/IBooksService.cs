using BooksApp.Domain.Entities;

namespace BooksApp.BLL.Interfaces
{
    public interface IBooksService
    {
        IEnumerable<FictionBook>? GetAllBooks();
        FictionBook? GetBookById(int id);
        void AddBook(FictionBook book);
        void UpdateBook(FictionBook book);
        void DeleteBook(int id);
    }
}
