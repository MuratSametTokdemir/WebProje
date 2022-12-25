using Microsoft.AspNetCore.Mvc;

namespace WebProje.Controllers
{
    public class TemelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Index2()
        {
            return RedirectToAction("Index", "Temel");
        }
    }
}
