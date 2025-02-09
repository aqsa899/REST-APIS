namespace BookstoreManagementSystem.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime PublishedDate { get; set; }
        public decimal Price { get; set; }

        // Foreign Key (Link to Author)
        public int AuthorId { get; set; }
        public Author Author { get; set; }  // Navigation Property
    }

}
