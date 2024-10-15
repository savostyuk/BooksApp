using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksApp.Domain.Entities;

[Table("PublisherBooks")]
public class PublisherBook
{
    [Key]
    public int Id {  get; set; }

    public int PublisherId { get; set; } //foreign key for Publisher
    public Publisher Publisher { get; set; } //navigation property

    public int BookId { get; set; } //foreign key for Book
    public Book Book { get; set; } //navigation property
}
