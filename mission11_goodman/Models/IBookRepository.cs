namespace mission11_goodman.Models
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
    }
}
