using BooksApp.DAL.Data;
using BooksApp.DAL.Repositories.Interfaces;
using BooksApp.Domain.Entities;

namespace BooksApp.DAL.Repositories;

public class EducationalBooksRepository : Repository<EducationalBook>, IEducationalBooksRepository
{
    private ApplicationDbContext _context;
    public EducationalBooksRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}
