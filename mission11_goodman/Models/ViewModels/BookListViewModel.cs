namespace mission11_goodman.Models.ViewModels
{
    // ViewModel class for displaying a list of books with pagination information
    public class BookListViewModel
    {
        // Property to hold the list of books
        public IQueryable<Book> Books { get; set; }

        // Property to hold pagination information with default initialization
        public Pagination Pagination { get; set; } = new Pagination();
    }
}