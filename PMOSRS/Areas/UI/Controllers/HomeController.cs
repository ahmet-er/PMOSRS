using Microsoft.AspNetCore.Mvc;

namespace PMOSRS.Areas.UI.Controllers
{
    [Area("UI")]
    public class HomeController : Controller
    {
		[HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
