namespace BookstoreCollection.Domain.Models
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string NameAuthor { get; set; }
        public string Year { get; set; }
        public string SerialNumber { get; set; }
    }
}