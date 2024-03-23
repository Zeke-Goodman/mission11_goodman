using System.Linq;

namespace mission11_goodman.Models
{
    // Entity Framework implementation of the book repository interface
    public class EFBookRepository : IBookRepository
    {
        private readonly BookstoreContext _context; // Database context variable

        // Constructor to initialize the repository with a database context
        public EFBookRepository(BookstoreContext temp)
        {
            _context = temp; // Assigning the injected database context to the private variable
        }

        // Property to access the collection of books
        public IQueryable<Book> Books => _context.Books;
    }
}
