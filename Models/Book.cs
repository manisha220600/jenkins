namespace BookServiceAPI.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public double Price { get; set; }
        public string Author { get; set; }
        public string Lang { get; set; }
        public DateTime ReleaseDate { get; set; }
        
    }
}
