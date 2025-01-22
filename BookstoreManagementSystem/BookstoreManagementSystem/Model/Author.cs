namespace BookstoreManagementSystem.Model
{
    public class Author
    {
        public int Id { get; set; } // Primary key
        public string? Name { get; set; } // Author's first name
        public DateTime DateOfBirth { get; set; } // Date of birth
        public string? Nationality { get; set; } // Author's nationality
        public List<Book>? Books { get; set; } // Navigation property for related books
    }
}
