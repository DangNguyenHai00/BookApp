using WebAPI2.Models;
using WebAPI2.Services;
using Microsoft.EntityFrameworkCore;

namespace WebAPI2.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _context;
        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddAuthor(Author author)
        {
            var existingAuthor = await _context.Authors.Where(x => author.AuthorId == x.AuthorId).FirstOrDefaultAsync();

            if (existingAuthor == null)
            {
                _context.Authors.Add(author);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Author>> All()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<bool> DeleteAuthor(int id)
        {
            var author = await _context.Authors.Where(x => id == x.AuthorId).FirstOrDefaultAsync();

            if (author != null)
            {
                _context.Authors.Remove(author);
                return true;
            }
            return false;
        }

        public async Task<Author> GetById(int id)
        {
            var existingAuthor = await _context.Authors.FindAsync(id);
            return existingAuthor;
        }
    }
}
