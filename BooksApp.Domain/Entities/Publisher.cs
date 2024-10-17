using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BooksApp.Domain.Entities;

[Table("Publishers")]
public class Publisher
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public ICollection<Book> Books { get; set; } = [];

}
