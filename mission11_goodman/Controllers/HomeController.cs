using Microsoft.AspNetCore.Mvc;
using mission11_goodman.Models; // Importing necessary models
using mission11_goodman.Models.ViewModels; // Importing necessary view models
using System.Diagnostics; // Importing for debugging purposes

namespace mission11_goodman.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository _repo; // Creating a private variable for the book repository

        // Constructor to initialize the controller with a book repository
        public HomeController(IBookRepository temp)
        {
            _repo = temp; // Assigning the injected book repository to the private variable
        }

        // Action method to handle the home page request
        // pageNum: page number to display
        public IActionResult Index(int pageNum)
        {
            int pageSize = 10; // Setting the page size

            // Retrieving books from the repository, skipping records based on the current page and taking a certain number of records
            var data = new BookListViewModel
            {
                Books = _repo.Books
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                // Creating pagination information for the view
                Pagination = new Pagination
                {
                    CurrentPage = pageNum, // Setting the current page number
                    ItemsPerPage = pageSize, // Setting the number of items per page
                    TotalItems = _repo.Books.Count() // Getting the total number of items from the repository
                }
            };

            return View(data); // Returning the view with the data
        }

        // Other action methods can be added here for handling different requests
    }
}