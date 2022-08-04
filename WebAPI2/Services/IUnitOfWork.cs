using WebAPI2.Repository;

namespace WebAPI2.Services
{
    public interface IUnitOfWork
    {
        IBookRepository Books { get; }
        IAuthorRepository Authors { get; }
        Task CompleteAsync();
    }
}
