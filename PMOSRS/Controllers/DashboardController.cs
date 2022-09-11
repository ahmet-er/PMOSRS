using Microsoft.AspNetCore.Mvc;

namespace PMOSRS.Controllers
{
    [Route("[Controller]")]
    public class DashboardController : Controller
    {
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("Project")]
        public IActionResult Project()
        {
            return View();
        }
        [HttpGet("TS")]
        public IActionResult TS()
        {
            return View();
        }

    }
}
