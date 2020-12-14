using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Models;
using LibraryAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        BookRepository repo;

        public BooksController(LibraryContext context)
        {
            repo = new BookRepository(context);
        }

        [HttpPost]
        public ActionResult AddBook([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            repo.Add(book);
            book.Description = "";
            return Accepted(book);
        }

        [HttpGet]
        public ActionResult GetBooks()
        {
            var books = repo.GetAll();
            if (books != null)
            {
                return Ok(books);
            }
            return NotFound();
        }

        [HttpGet("available")]
        public ActionResult GetAvailableBooks()
        {
            var books = repo.GetAvailableBooks();
            if (books != null)
            {
                return Ok(books);
            }
            return NotFound();
        }

        [HttpGet("/Author/{authorId}")]
        public ActionResult GetBooksByAuthor(Guid authorId)
        {
            var books = repo.GetBooksByAuthor(authorId);
            if (books != null)
            {
                return Ok(books);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult GetBook(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var book = repo.GetById(id);
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(Guid id, [FromBody] Book book)
        {
            if (id != book.BookId)
            {
                return BadRequest();
            }

            repo.Update(book);

            if (repo.GetById(id) == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBook(Guid id)
        {
            var book = repo.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            repo.Delete(id);

            return NoContent();
        }
    }
}
