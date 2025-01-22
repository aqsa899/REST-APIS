namespace BookstoreManagementSystem.Model
{
    public class Book
    {
        public int Id { get; set; } // Primary key
        public string? Title { get; set; } // Book title
        public string? Genre { get; set; } // Genre of the book
        public DateTime PublishedDate { get; set; } // Publication date
        public decimal Price { get; set; } // Price of the book
        public int AuthorId { get; set; } // Foreign key to Author
        public Author Author { get; set; } // Navigation property for Author
        public string ISBN { get; set; } // ISBN number for identification
        public string Language { get; set; } // Language of the book
        public string Description { get; set; } // Short description or summary
        public bool IsAvailable { get; set; } // Availability status
    }

}
