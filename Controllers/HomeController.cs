using Microsoft.AspNetCore.Mvc;

namespace ExploreCaliforniaMyProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
