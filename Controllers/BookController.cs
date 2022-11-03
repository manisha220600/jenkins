using BookServiceAPI.Models;
using BookServiceAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookRepository bookRepository;
        public BookController()
        {
            bookRepository = new BookRepository();
        }

        [HttpGet, Route("GetAllBooks")]
        public IActionResult GetAll()
        {
            List<Book> books = bookRepository.GetAllBooks();
            return StatusCode(200, books);
        }

        [HttpGet, Route("GetBooksByAuthor/{author}")]
        public IActionResult Get(string author)
        {
            Console.WriteLine(author);
            List<Book> books = bookRepository.GetBooksByAuthor(author);
            /*List<string> bookNames = new List<string>();
            foreach (Book book in books)
            {
                bookNames.Add(book.BookName);
            }*/
            if (books != null && books.Count > 0)
            {
                return StatusCode(200, books);
            }
            else
            {
                return StatusCode(404, "Invalid Author");
            }
        }

        [HttpGet, Route("GetBooksByLang/{lang}")]
        public IActionResult GetBooksByLang(string lang)
        {
            List<Book> books = bookRepository.GetBooksByLang(lang);
            if (books != null && books.Count > 0)
            {
                return StatusCode(200, books);
            }
            else
            {
                return StatusCode(404, "Invalid lang");
            }
        }

        [HttpGet, Route("GetBooksByYear/{year}")]
        public IActionResult GetBooksByYear(int year)
        {
            List<Book> books = bookRepository.GetBooksByYear(year);
            if (books != null && books.Count > 0)
            {
                return StatusCode(200, books);
            }
            else
            {
                return StatusCode(404, "Invalid Year");
            }
        }

        [HttpPost, Route("AddBook")]
        public IActionResult Add(Book book)
        {
            bookRepository.AddBook(book);
            return StatusCode(200, book);
        }

        [HttpPut, Route("EditBook")]
        public IActionResult Edit(Book book)
        {
            bookRepository.EditBook(book);
            return StatusCode(200, book);
        }

        [HttpDelete, Route("DeleteBook/{bookId}")]
        public IActionResult Delete(int bookId)
        {
            bookRepository.DeleteBook(bookId);
            return StatusCode(200, "Book Deleted");
        }
    }
}
