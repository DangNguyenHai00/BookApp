using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI2.Services;
using WebAPI2.Models;

namespace WebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        public BookController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _unitofwork.Books.All();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _unitofwork.Books.GetById(id);

            if (book == null)
                return NotFound(); // 404 http status code 

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> NewBook(Book book)
        {
            if (ModelState.IsValid)
            {
                bool wait_book = false;
                Author author;
                wait_book = await _unitofwork.Books.AddBook(book);
                author = await _unitofwork.Authors.GetById(book.AuthorId);
                if(wait_book && author != null)
                {
                    await _unitofwork.CompleteAsync();
                    return CreatedAtAction("GetBook", new { id = book.BookId },book);
                }
            }

            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _unitofwork.Books.GetById(id);

            if (item == null)
                return BadRequest();

            await _unitofwork.Books.DeleteBook(id);
            await _unitofwork.CompleteAsync();

            return Ok(item);
        }
    }
}
