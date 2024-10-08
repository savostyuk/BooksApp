using System.ComponentModel.DataAnnotations;

namespace BooksApp.Domain.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Author { get; set; }
        public int Year { get; set; }
    }
}
