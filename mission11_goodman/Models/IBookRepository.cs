using System.Linq;

namespace mission11_goodman.Models
{
    // Interface representing a book repository
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; } // Property to access the collection of books
    }
}
