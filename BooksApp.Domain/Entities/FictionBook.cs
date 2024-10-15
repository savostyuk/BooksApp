using System.ComponentModel.DataAnnotations.Schema;

namespace BooksApp.Domain.Entities;

[Table("FictionBooks")]
public class FictionBook : Book
{
    public string Genre { get; set; }
    public int AgeRestrictions { get; set; }
}
