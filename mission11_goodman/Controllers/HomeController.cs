using Microsoft.AspNetCore.Mvc;
using mission11_goodman.Models;
using mission11_goodman.Models.ViewModels;
using System.Diagnostics;

namespace mission11_goodman.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository _repo;
        public HomeController(IBookRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(int pageNum)
        {
            int pageSize = 5;

            var data = new BookListViewModel
            {
                Books = _repo.Books
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                Pagination = new Pagination
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _repo.Books.Count()
                }
            };
            return View(data);      
        }

        
    }
}
