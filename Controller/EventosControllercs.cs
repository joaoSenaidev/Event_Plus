using Microsoft.AspNetCore.Mvc;

namespace Event_Plus.Controller
{
    public class EventosControllercs : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
