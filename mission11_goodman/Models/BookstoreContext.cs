using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace mission11_goodman.Models
{
    // Represents the database context for the bookstore application
    public partial class BookstoreContext : DbContext
    {
        public BookstoreContext()
        {
        }

        // Constructor to initialize the context with options
        public BookstoreContext(DbContextOptions<BookstoreContext> options)
            : base(options)
        {
        }

        // DbSet representing the 'Books' table in the database
        public virtual DbSet<Book> Books { get; set; }

        // Method to configure the model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                // Configuring index for the BookId column
                entity.HasIndex(e => e.BookId, "IX_Books_BookID").IsUnique();

                // Configuring property mappings
                entity.Property(e => e.BookId).HasColumnName("BookID");
                entity.Property(e => e.Isbn).HasColumnName("ISBN");
            });
        }
    }
}
