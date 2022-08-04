using WebAPI2.Models;

namespace WebAPI2.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> All();
        Task<Book> GetById(int id);
        Task<bool> AddBook(Book book);
        Task<bool> DeleteBook(int id);
    }
}
