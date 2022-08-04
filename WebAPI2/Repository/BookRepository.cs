using WebAPI2.Models;
using WebAPI2.Services;
using Microsoft.EntityFrameworkCore;

namespace WebAPI2.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddBook(Book book)
        {
            var existingBook = await _context.Books.Where(x => book.BookId == x.BookId).FirstOrDefaultAsync();

            if (existingBook == null)
            {
                _context.Books.Add(book);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Book>> All()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<bool> DeleteBook(int id)
        {
            var existingBook = await _context.Books.Where(x => id == x.BookId).FirstOrDefaultAsync();

            if (existingBook != null)
            {
                _context.Books.Remove(existingBook);
                return true;
            }
            return false;
        }

        public async Task<Book> GetById(int id)
        {
            var existingBook = await _context.Books.Where(x => id == x.BookId).FirstOrDefaultAsync();
            return existingBook;
        }
    }
}
