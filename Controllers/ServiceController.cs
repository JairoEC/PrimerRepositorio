using Microsoft.AspNetCore.Mvc;
using WebApplication_NET_CORE.Context;
using WebApplication_NET_CORE.Managers;
using WebApplication_NET_CORE.Models;

namespace WebApplication_NET_CORE.Controllers
{
    public class ServiceController(ServiceManager _serviceManager) : Controller
    {
        public IActionResult Index()
        {
            var list = _serviceManager.GetAll(1);
            return View(list);
        }
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]public IActionResult New(ServiceVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //TODO change userid
            model.UserId = 1;
            var response = _serviceManager.New(model);
            if(response == 1) return RedirectToAction("Index");
            ViewBag.message = "Error";
            return View();
        }
        public IActionResult Edit(int id)
        {
            var model = _serviceManager.GetById(id);
            return View(model);
        }
        [HttpPost]public IActionResult Edit(ServiceVM model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.message = "ID: "+model.ServiceId.ToString();
                return View(model);
            }
            var response = _serviceManager.Edit(model);
            if (response == 1) return RedirectToAction("Index");
            ViewBag.message = "Error al editar";
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var response = _serviceManager.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
