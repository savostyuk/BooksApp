using Microsoft.EntityFrameworkCore;
using BooksApp.Domain.Entities;

namespace BooksApp.DAL.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Book> Books { get; set; }
    public DbSet<EducationalBook> EducationalBooks { get; set; }
    public DbSet<FictionBook> FictionBooks { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<PublisherBook> PublisherBooks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<FictionBook>()
            .ToTable("FictionBooks")
            .HasBaseType<Book>() // Specifies that FictionBook inherits from Book
            .HasOne<Book>()
            .WithMany()
            .HasForeignKey(fb => fb.Id);

        modelBuilder.Entity<EducationalBook>()
            .ToTable("EducationalBooks")
            .HasBaseType<Book>() // Specifies that EducationalBook inherits from Book
            .HasOne<Book>()
            .WithMany()
            .HasForeignKey(eb => eb.Id);

        modelBuilder.Entity<PublisherBook>()
            .HasKey(pb => pb.Id);

        //many-to-many
        modelBuilder.Entity<PublisherBook>()
            .HasOne(pb => pb.Publisher)
            .WithMany(p => p.PublisherBooks)
            .HasForeignKey(pb => pb.PublisherId);

        modelBuilder.Entity<PublisherBook>()
            .HasOne(pb => pb.Book)
            .WithMany()
            .HasForeignKey(pb => pb.BookId);

        DbInitializer.SeedData(modelBuilder);
    }
}
