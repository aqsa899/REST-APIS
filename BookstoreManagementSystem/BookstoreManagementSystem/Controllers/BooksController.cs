using Asp.Versioning;
using BookstoreManagementSystem.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreManagementSystem.Controllers
{
    [ApiController]
  //  [ApiVersion("V1")]
    [Route("books")]
    public class BooksController : ControllerBase
    {
        private Author author = new()
        {
            Id = 1,
            Name = "Shubo",
            Nationality = "pakistani",
            DateOfBirth = DateTime.Now,
        };
        private List<Book> b = new()
       {
           new Book {
           Id = 1,
           Title = "C# Programming",
           Genre = "Learning",
           PublishedDate = DateTime.Now,
           Price = 1000,
           AuthorId = 1
           },
           new Book
           {
               Id = 1,
               Title = "Romeo Juliet",
               Genre = "Romance",
               PublishedDate = DateTime.Now,
               Price = 1000,
               AuthorId = 2
           }
       };

        private readonly ILogger<Book> _logger;

        public BooksController(ILogger<Book> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("getBooks")]
        public IEnumerable<Book> Get()
        {
            return b;
        }
    }
}
