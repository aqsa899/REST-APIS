using Asp.Versioning;
using BookstoreManagementSystem.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookstoreManagementSystem.Controllers
{
    [ApiController]
  //  [ApiVersion("V1")]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        // Static list of books (Temporary storage before using a database)
        private static List<Book> _books = new()
        {
            new Book { Id = 1, Title = "1984", Genre = "Dystopian", PublishedDate = new DateTime(1949, 6, 8), Price = 15.99m, AuthorId = 1 },
            new Book { Id = 2, Title = "Harry Potter and the Sorcerer's Stone", Genre = "Fantasy", PublishedDate = new DateTime(1997, 6, 26), Price = 25.99m, AuthorId = 2 },
            new Book { Id = 3, Title = "The Adventures of Tom Sawyer", Genre = "Adventure", PublishedDate = new DateTime(1876, 6, 10), Price = 10.99m, AuthorId = 3 }
        };

        private readonly ILogger<Book> _logger;

        public BooksController(ILogger<Book> logger)
        {
            _logger = logger;
        }

        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [HttpGet]
        [Route("getBooks")]
        public IActionResult GetBooks()
        {
            if (_books == null || _books.Count == 0)
                return NotFound("No books found.");

            // Return the list of books along with a 200 OK status code
            return Ok(_books);
        }

        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [HttpGet]
        [Route("getBook/{id}")]
        public IActionResult GetBook([FromRoute] int id)
        {
            var book = _books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                // Return a 404 Not Found status with a message
                return NotFound($"Book with ID {id} not found.");
            }

            // Return the book data along with a 200 OK status code
            return Ok(book);
        }
        
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [HttpGet]
        [Route("getBookWithAuthorId/{id}")]
        public IActionResult GetBookWithAuthorId([FromRoute] int id)
        {
            var book = _books.FirstOrDefault(x => x.AuthorId == id);
            if (book == null)
            {
                // Return a 404 Not Found status with a message
                return NotFound($"Book with author ID {id} not found.");
            }

            // Return the book data along with a 200 OK status code
            return Ok(book);
        }
        
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [HttpGet]
        [Route("getBookWithAuthorName/{name}")]
        public IActionResult GetBookWithAuthorName([FromRoute] string name)
        {
            var book = _books.FirstOrDefault(x => x.Author.Name == name);
            if (book == null)
            {
                // Return a 404 Not Found status with a message
                return NotFound($"Book with author ID {name} not found.");
            }

            // Return the book data along with a 200 OK status code
            return Ok(book);
        }
        
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [HttpPost]
        [Route("addBook/{book}")]
        public IActionResult AddBook([FromBody] Book book)
        {
            //var book = b.FirstOrDefault(x => x.Author.Name == name);
            if (book == null)
            {
                // Return a 404 Not Found status with a message
                return BadRequest($"Book cannot be null.");
            }
            _books.Add(book);
            // Return the book data along with a 200 OK status code
            return Created();
        }
        
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound($"Book with ID {id} not found.");

            book.Title = updatedBook.Title;
            book.Genre = updatedBook.Genre;
            book.PublishedDate = updatedBook.PublishedDate;
            book.Price = updatedBook.Price;
            book.AuthorId = updatedBook.AuthorId;

            return Ok(book);
        }

        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound($"Book with ID {id} not found.");

            _books.Remove(book);
            return NoContent();
        }
    }
}
