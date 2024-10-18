using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BooksApp.Domain.Entities;

[Table("EducationalBooks")]
public class EducationalBook : Book
{
    public string? Speciality {  get; set; }
    public string? Level { get; set; }
}

