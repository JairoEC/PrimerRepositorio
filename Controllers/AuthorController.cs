using Microsoft.AspNetCore.Mvc;
using WebApplication_NET_CORE.Entities;
using WebApplication_NET_CORE.Managers;
using WebApplication_NET_CORE.ViewModels.Author;

namespace WebApplication_NET_CORE.Controllers
{
    public class AuthorController : Controller
    {
        private readonly AuthorManager _authorManager;
        public AuthorController(AuthorManager authorManager)
        {
            _authorManager = authorManager;
        }
        public async Task<IActionResult> Index()
        {
            var reg = await _authorManager.GetAllAsync();
            return View(reg);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost] async Task<IActionResult> Create(AuthorCreateVM reg)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Mensaje = "Algo salio mal";
                return View(reg);
            }
            await _authorManager.CreateAsync(reg);
            ViewBag.Mensaje = "Se realizó el registro del autor "+reg.AuthorName;
            return View(reg);
        }
        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }
    }
}
