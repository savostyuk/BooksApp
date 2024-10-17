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

        modelBuilder.Entity<Publisher>()
            .ToTable("Publishers")
            .HasKey(pb => pb.Id);

        //many-to-many
        modelBuilder.Entity<Book>()
            .ToTable("Books")
            .HasKey(b => b.Id);

        modelBuilder.Entity<Publisher>()
            .HasMany(b  => b.Books)
            .WithMany()
            .UsingEntity(i => i.ToTable("PublisherBooks"));

        DbInitializer.SeedData(modelBuilder);
    }
}
