using BooksApp.DAL.Data;
using BooksApp.DAL.Repository.Interfaces;
using BooksApp.Domain.Entities;

namespace BooksApp.DAL.Repository;

public class FictionBooksRepository : Repository<FictionBook>, IFictionBooksRepository
{
    private ApplicationDbContext _context;
    public FictionBooksRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    public async Task UpdateAsync(FictionBook entity)
    {
        var originalEntity = await _context.FictionBooks.FindAsync(entity.Id);

        if (originalEntity != null)
        {
            originalEntity.Name = entity.Name;
            originalEntity.Author = entity.Author;
            originalEntity.Year = entity.Year;
            originalEntity.Genre = entity.Genre;
            originalEntity.AgeRestrictions = entity.AgeRestrictions;

            await _context.SaveChangesAsync();
        }
    }
}
