using BooksApp.DAL.Data;
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
    }
}
