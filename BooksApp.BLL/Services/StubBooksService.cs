using BooksApp.BLL.Interfaces;
using BooksApp.Domain.Entities;

namespace BooksApp.BLL.Services
{
    public class StubBooksService: IBooksService
    {
        private static List<Book> books =
        [
            new Book { Id = 1, Name = "First", Author = "Natalya", Year = 2024 },
            new Book { Id = 2, Name = "Second", Author = "Mikalai",  Year = 2023 },
            new Book { Id = 3, Name = "Third", Author = "Dmitry",  Year = 2022 }
        ];

        public IEnumerable<Book> GetAllBooks()
        {
            return books;
        }

        public Book? GetBookById(int id)
        {
            return books?.FirstOrDefault(s => s.Id == id);
        }

        public void AddBook(Book book)
        {
            book.Id = books.Count > 0 ? books.Max(s => s.Id) + 1 : 1;
            books.Add(book);
        }

        public void DeleteBook(int id)
        {
            var book = GetBookById(id);

            if (book != null)
            {
                books.Remove(book);
            }
        }

        public void UpdateBook(Book books)
        {
            var existingBook = GetBookById(books.Id);

            if (existingBook != null)
            {
                existingBook.Name = books.Name;
                existingBook.Author = books.Author;
                existingBook.Year = books.Year;
            }
        }
    }
}
