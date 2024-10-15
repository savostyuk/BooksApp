using BooksApp.BLL.Interfaces;
using BooksApp.Domain.Entities;

namespace BooksApp.BLL.Services
{
    public class StubBooksService: IBooksService
    {
        private static List<FictionBook> books =
        [
            new FictionBook { Id = 1, Name = "First", Author = "Natalya", Year = 2024 },
            new FictionBook { Id = 2, Name = "Second", Author = "Mikalai",  Year = 2023 },
            new FictionBook { Id = 3, Name = "Third", Author = "Dmitry",  Year = 2022 }
        ];

        public IEnumerable<FictionBook> GetAllBooks()
        {
            return books;
        }

        public FictionBook? GetBookById(int id)
        {
            return books?.FirstOrDefault(s => s.Id == id);
        }

        public void AddBook(FictionBook book)
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

        public void UpdateBook(FictionBook books)
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
