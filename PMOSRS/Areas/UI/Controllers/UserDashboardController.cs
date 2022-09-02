using Microsoft.AspNetCore.Mvc;

namespace PMOSRS.Areas.UI.Controllers
{
	[Area("UI")]
	public class UserDashboardController : Controller
	{
		[HttpGet("Index")]
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet("AddProject")]
		public IActionResult AddProject()
		{
			return View();
		}
		[HttpGet("ListProject")]
		public IActionResult ListProject()
		{
			return View();
		}
		[HttpGet("AddTS")]
		public IActionResult AddTS()
		{
			return View();
		}
		[HttpGet("ListTS")]
		public IActionResult ListTS()
		{
			return View();
		}
	}
}
