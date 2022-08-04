using WebAPI2.Models;

namespace WebAPI2.Services
{
    public class Writer:IWriter
    {
        public void Write(Book book)
        {
            Console.WriteLine("New book with id {0} has been added successfully.",book.BookId);
        }
    }
}
