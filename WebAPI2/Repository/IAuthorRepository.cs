using WebAPI2.Models;

namespace WebAPI2.Repository
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> All();
        Task<Author> GetById(int id);
        Task<bool> AddAuthor(Author author);
        Task<bool> DeleteAuthor(int id);
    }
}
