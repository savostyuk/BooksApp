using BooksApp.Domain.Entities;

namespace BooksApp.BLL.Interfaces
{
    public interface IBooksService
    {
        IEnumerable<Book>? GetAllBooks();
        Book? GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
    }
}
