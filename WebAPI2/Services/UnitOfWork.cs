using WebAPI2.Repository;

namespace WebAPI2.Services
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public IBookRepository Books { get; private set; }
        public IAuthorRepository Authors { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Books = new BookRepository(_context);
            Authors = new AuthorRepository(_context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
