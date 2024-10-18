using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BooksApp.Models;

public class BookViewModel 
{

    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(1000, ErrorMessage = "Name of the book can't be longer than 100.")]
    public string Name { get; set; }

    [AllowNull]
    public string? Author { get; set; }

    [Range(1000, 2024, ErrorMessage = "Please enter a valid year")]
    public int Year { get; set; }

}
