using Microsoft.AspNetCore.Mvc;

namespace API_DEMO.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
