using BooksApp.DAL.Data;
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
    }
}
