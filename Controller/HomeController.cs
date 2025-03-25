using Microsoft.AspNetCore.Mvc;

namespace Event_Plus.Controller
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
