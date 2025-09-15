using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication_NET_CORE.Managers;
using WebApplication_NET_CORE.Models;
using WebApplication_NET_CORE.ViewModels.Book;

namespace WebApplication_NET_CORE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AuthorManager _authorManager;
        private readonly CategoryManager _categoryManager;
        private readonly BookManager _bookManager;

        public HomeController(ILogger<HomeController> logger, AuthorManager authorManager,
            CategoryManager categoryManager, BookManager bookManager)
        {
            _logger = logger;
            _authorManager = authorManager;
            _categoryManager = categoryManager;
            _bookManager = bookManager;
        }

        public async Task<IActionResult> Index()
        {
            List<BookVM> books;
            books = await _bookManager.GetAllAsync();
            return View(books);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
