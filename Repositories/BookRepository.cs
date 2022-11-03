using BookServiceAPI.Models;

namespace BookServiceAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        private static List<Book> books = new List<Book>()
        {
            new Book(){BookId=13,BookName="Harry Potter",Price=3450,Author="R.K ROWLING", Lang="English",ReleaseDate=new DateTime(2022,02,20)}
        };
        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void DeleteBook(int bookId)
        {
            Book e = null;
            foreach (var book in books)
            {
                if (book.BookId.Equals(bookId))
                {
                    e = book;
                }
            }
            books.Remove(e);
        }

        public void EditBook(Book book)
        {
            Book e = null;
            int bookId = book.BookId;
            var obj = books.FirstOrDefault(x => x.BookId == bookId);
            if (obj != null) obj = book;
  
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }


        public List<Book> GetBooksByAuthor(string author)
        {
            return books.Where(x => x.Author == author).ToList();

        }

        public List<Book> GetBooksByLang(string lang)
        {
            return books.Where(x => x.Lang == lang).ToList();
        }

        public List<Book> GetBooksByYear(int year)
        {
            return books.Where(x => x.ReleaseDate.Year == year).ToList();
        }
    }
}
