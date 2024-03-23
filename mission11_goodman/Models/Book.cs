using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mission11_goodman.Models
{
    // Model class representing a book
    public partial class Book
    {
        [Key]
        [Required]
        public int BookId { get; set; } // Unique identifier for the book

        [Required]
        public string Title { get; set; } = null!; // Title of the book

        [Required]
        public string Author { get; set; } = null!; // Author of the book

        [Required]
        public string Publisher { get; set; } = null!; // Publisher of the book

        [Required]
        public string Isbn { get; set; } = null!; // ISBN of the book

        [Required]
        public string Classification { get; set; } = null!; // Classification of the book

        [Required]
        public string Category { get; set; } = null!; // Category of the book

        [Required]
        public int PageCount { get; set; } // Number of pages in the book

        [Required]
        public double Price { get; set; } // Price of the book
    }
}
