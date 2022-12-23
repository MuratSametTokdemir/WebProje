using Microsoft.AspNetCore.Mvc;

namespace WebProje.Controllers
{
    public class FilmlerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
