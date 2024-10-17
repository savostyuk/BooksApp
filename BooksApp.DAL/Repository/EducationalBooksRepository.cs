using BooksApp.DAL.Data;
using BooksApp.DAL.Repository.Interfaces;
using BooksApp.Domain.Entities;

namespace BooksApp.DAL.Repository;

public class EducationalBooksRepository : Repository<EducationalBook>, IEducationalBooksRepository
{
    private ApplicationDbContext _context;
    public EducationalBooksRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    public async Task UpdateAsync(EducationalBook entity)
    {
        var originalEntity = await _context.EducationalBooks.FindAsync(entity.Id);

        if (originalEntity != null)
        {
            originalEntity.Name = entity.Name;
            originalEntity.Author = entity.Author;
            originalEntity.Year = entity.Year;
            originalEntity.Level = entity.Level;
            originalEntity.Speciality = entity.Speciality;

            await _context.SaveChangesAsync();
        }
    }
}
