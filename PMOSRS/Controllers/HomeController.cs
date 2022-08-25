using Microsoft.AspNetCore.Mvc;

namespace PMOSRS.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
