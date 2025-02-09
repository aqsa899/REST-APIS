using BookstoreManagementSystem.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreManagementSystem.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        // Static list of authors (Temporary storage before using a database)
        private static List<Author> _authors = new()
        {
            new Author { Id = 1, Name = "George Orwell", Nationality = "British", DateOfBirth = new DateTime(1903, 6, 25) },
            new Author { Id = 2, Name = "J.K. Rowling", Nationality = "British", DateOfBirth = new DateTime(1965, 7, 31) },
            new Author { Id = 3, Name = "Mark Twain", Nationality = "American", DateOfBirth = new DateTime(1835, 11, 30) }
        };

        [HttpGet]
        public IActionResult GetAuthors()
        {
            return Ok(_authors);
        }


        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            var author = _authors.FirstOrDefault(a => a.Id == id);
            if (author == null) return NotFound($"Author with ID {id} not found.");

            return Ok(author);
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] Author author)
        {
            author.Id = _authors.Max(a => a.Id) + 1;
            _authors.Add(author);
            return CreatedAtAction(nameof(GetAuthorById), new { id = author.Id }, author);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] Author updatedAuthor)
        {
            var author = _authors.FirstOrDefault(a => a.Id == id);
            if (author == null) return NotFound($"Author with ID {id} not found.");

            author.Name = updatedAuthor.Name;
            author.Nationality = updatedAuthor.Nationality;
            author.DateOfBirth = updatedAuthor.DateOfBirth;

            return Ok(author);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            var author = _authors.FirstOrDefault(a => a.Id == id);
            if (author == null) return NotFound($"Author with ID {id} not found.");

            _authors.Remove(author);
            return NoContent();
        }
    }
}
