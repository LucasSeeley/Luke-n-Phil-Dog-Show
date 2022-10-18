using Microsoft.AspNetCore.Mvc;

namespace Luke_n_Phil_Dog_Show.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Events()
        {
            return View();
        }

        public IActionResult Tickets()
        {
            return View();
        }
    }
}
