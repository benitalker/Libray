using Library.Models;
using Library.Service;
using Library.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class SetController : Controller
    {
        private readonly ISetService _setService;
        public SetController(ISetService setService)
        {
            _setService = setService;
        }
        public IActionResult Index(long id)
        {
            ViewBag.Id = id;
            return View(_setService.GetAllSetsById(id));
        }
        
        public IActionResult Create(long id)
        {

            return View(new SetVM() { });
        }
        [HttpPost]
        public IActionResult Create(SetVM set)
        {
            _setService.CreateSet(set);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(long id)
        {
            _setService.DeleteSet(id);
            return RedirectToAction("Index");
        }
    }
}
