using Microsoft.AspNetCore.Mvc;

namespace PMOSRS.Controllers
{
	[Route("[Controller]")]
	public class LoginController : Controller
	{
		[HttpGet("Index")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
