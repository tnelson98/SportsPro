using Microsoft.AspNetCore.Mvc;

namespace SportsPro.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Name = "SportsPro";
            return View();
        }

        [Route("About")]
        public IActionResult About()
        {
            return View();
        }
    }
}
