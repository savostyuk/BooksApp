using Microsoft.EntityFrameworkCore;
using BooksApp.DAL.Data;
using BooksApp.DAL.Repository.Interfaces;
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
            var originalEntity = await _context.Publishers
           .Include(p => p.Books)
           .FirstOrDefaultAsync(u => u.Id == entity.Id);

            if (originalEntity != null)
            {
                originalEntity.Name = entity.Name;
                originalEntity.Country = entity.Country;
                originalEntity.Email = entity.Email;

                originalEntity.Books.Clear();

                foreach (var book in entity.Books)
                {
                    originalEntity.Books.Add(book);
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}
