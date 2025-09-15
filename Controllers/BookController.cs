using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication_NET_CORE.Managers;

namespace WebApplication_NET_CORE.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AuthorManager _authorManager;
        private readonly CategoryManager _categoryManager;
        private readonly BookManager _bookManager;
        public BookController(
            ILogger<HomeController> logger, AuthorManager authorManager, 
            CategoryManager categoryManager, BookManager bookManager)
        {
            _logger = logger;
            _authorManager = authorManager;
            _categoryManager = categoryManager;
            _bookManager = bookManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _bookManager.GetAllAsync());
        }
        public async Task<IActionResult> Create()
        {
            var authors = await _authorManager.GetAllAsync();
            var categories = await _categoryManager.GetAllAsync();

            ViewBag.Authors = new SelectList(authors, "AuthorId","AuthorName");
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            return View();
        }
    }
}
