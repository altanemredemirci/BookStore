using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        public static List<Book> BookList = new List<Book>(){
            new Book{
                Id=1,
                Title="Simyacı",
                GenreId=1,
                PageCount=200,
                PublishDate=new DateTime(1999,01,01)
            },
            new Book{
                Id=2,
                Title="Martı",
                GenreId=2,
                PageCount=200,
                PublishDate=new DateTime(1997,01,01)
            },
            new Book{
                Id=3,
                Title="Metal Fırtına",
                GenreId=3,
                PageCount=300,
                PublishDate=new DateTime(2005,01,01)
            }
        };


        [HttpGet]
        public List<Book> Get()
        {
            var bookList = BookList.OrderBy(i => i.Id).ToList<Book>();
            return bookList;
        }

        [HttpGet("{id}")]
        public Book GetById(int Id)
        {
            var book = BookList.FirstOrDefault(i => i.Id == Id);
            return book;
        }

        [HttpPost]
        public IActionResult AddBook(Book newBook)
        {
            var book = BookList.FirstOrDefault(i => i.Title == newBook.Title);

            if (book is not null)
                return BadRequest();

            BookList.Add(book);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,Book updatedBook)
        {
            var book = BookList.FirstOrDefault(i => i.Id == updatedBook.Id);

            if (book is not null)
                return BadRequest();

            book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;
            book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
            book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;
            book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
            return Ok();
        }
    }
}
