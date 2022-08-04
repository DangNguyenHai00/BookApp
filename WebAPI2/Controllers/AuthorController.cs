using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI2.Services;
using WebAPI2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        public AuthorController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _unitofwork.Authors.All();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            var author = await _unitofwork.Authors.GetById(id);

            if (author == null)
                return NotFound(); // 404 http status code 

            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> NewAuthor(Author author)
        {
            if (ModelState.IsValid)
            {
                Author exist_author = await _unitofwork.Authors.GetById(author.AuthorId);
                if (exist_author == null)
                {
                    await _unitofwork.Authors.AddAuthor(author);
                    await _unitofwork.CompleteAsync();
                    return CreatedAtAction("GetAuthor", new {id = author.AuthorId} ,author);
                }
                else
                {
                    return new JsonResult("Something went wrong") { StatusCode = 500 };
                }
            }
            else
            {
                return new JsonResult("Something went wrong") { StatusCode = 500 };
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _unitofwork.Authors.GetById(id);

            if (item == null)
                return BadRequest();

            await _unitofwork.Authors.DeleteAuthor(id);
            await _unitofwork.CompleteAsync();

            return Ok(item);
        }
    }
}
