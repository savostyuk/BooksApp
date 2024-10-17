using BooksApp.DAL.Data;
using BooksApp.Domain.Entities;

namespace BooksApp.DAL.Repository
{
    public class PublisherRepository : Repository<Publisher>, IPublisherRepository
    {
        private ApplicationDbContext _context;
        public PublisherRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task UpdateAsync(Publisher entity)
        {
        }
    }
}
