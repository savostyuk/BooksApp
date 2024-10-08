using Microsoft.EntityFrameworkCore;
using BooksApp.Domain.Entities;

namespace BooksApp.DAL.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Book> Book {  get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Add seed data for Books table.
        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Name = "First book", Author = "Roman", Year = 2010},
            new Book { Id = 2, Name = "Second book", Author = "Natalya", Year = 2020 },
            new Book { Id = 3, Name = "Third book", Author = "Anton", Year = 2021 }
        );
    }
}
