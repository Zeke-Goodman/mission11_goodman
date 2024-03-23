namespace mission11_goodman.Models.ViewModels
{
    // ViewModel class for pagination information
    public class Pagination
    {
        // Property to hold the total number of items
        public int TotalItems { get; set; }

        // Property to hold the number of items per page
        public int ItemsPerPage { get; set; }

        // Property to hold the current page number
        public int CurrentPage { get; set; }

        // Computed property to calculate the total number of pages based on total items and items per page
        public int TotalNumPages => (int)(Math.Ceiling((decimal)TotalItems / ItemsPerPage));
    }
}