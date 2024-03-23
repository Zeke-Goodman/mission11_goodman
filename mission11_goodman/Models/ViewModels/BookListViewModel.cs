namespace mission11_goodman.Models.ViewModels
{
    public class BookListViewModel
    {
        public IQueryable<Book> Books { get; set; }
        public Pagination Pagination { get; set; } = new Pagination();
    }
}
