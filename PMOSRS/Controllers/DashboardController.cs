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
        [HttpGet("TID")]
        public IActionResult TID()
        {
            return View();
        }
        [HttpGet("SRS")]
        public IActionResult SRS()
        {
            return View();
        }
        [HttpGet("Parameter")]
        public IActionResult Parameter()
        {
            return View();
        }
        [HttpGet("User")]
        public IActionResult User()
        {
            return View();
        }
        [HttpGet("Reports")]
        public IActionResult Reports()
        {
            return View();
        }

    }
}
