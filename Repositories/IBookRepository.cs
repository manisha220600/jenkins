using BookServiceAPI.Models;

namespace BookServiceAPI.Repositories
{
    public interface IBookRepository
    {
        public List<Book> GetAllBooks();
        public List<Book> GetBooksByAuthor(string author);
        public List<Book> GetBooksByLang(string lang);
        public List<Book> GetBooksByYear(int year);

        public void AddBook(Book book);
        public void EditBook(Book book);
        public void DeleteBook(int bookId);
    }
}
