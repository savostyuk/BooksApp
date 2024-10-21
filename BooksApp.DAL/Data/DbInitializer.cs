using Microsoft.EntityFrameworkCore;
using BooksApp.Domain.Entities;

namespace BooksApp.DAL.Data;

public class DbInitializer
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FictionBook>().HasData(
            new FictionBook
            {
                Id = 1,
                Name = "Harry Potter",
                Author = "Joanne Rowling",
                Year = 2000,
                Genre = "Fantasy",
                AgeRestrictions = 6

            },
            new FictionBook
            {
                Id = 2,
                Name = "The Lord of the Rings",
                Author = "John Ronald Reuel Tolkien",
                Year = 2010,
                Genre = "Mystery",
                AgeRestrictions = 18

            }
        );

        modelBuilder.Entity<EducationalBook>().HasData(
            new EducationalBook
            {
                Id = 3,
                Name = "C# for adults",
                Author = "Natalya Shulzhenka",
                Year = 2015,
                Speciality = "Programming",
                Level = "Adults"

            },
            new EducationalBook
            {
                Id = 4,
                Name = "How to learn",
                Author = "Mister Bean",
                Year = 2005,
                Speciality = "Psycology",
                Level = "Children"

            }
        );

        modelBuilder.Entity<Publisher>().HasData(
            new Publisher
            {
                Id = 1,
                Name = "Ad Press",
                Country = "Belarus",
                Email = "ad_press@gmail.com",

            },
            new Publisher
            {
                Id = 2,
                Name = "Academic Studies",
                Country = "Poland",
                Email = "academic_studies@gmail.com",
            }
        );
    }
}
