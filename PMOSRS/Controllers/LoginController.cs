using Microsoft.AspNetCore.Mvc;
using PMOSRS.Model.Models.Context;
using System.Linq;

namespace PMOSRS.Controllers
{
	[Route("[Controller]")]
	public class LoginController : Controller
	{
		[HttpGet("Index")]
		public IActionResult Index()
		{
			using (var context = new PMOSRSContext())
			{
				var settings = context.t_Settings.First();
				ViewBag.v = settings.Version;
			}
			return View();
		}
	}
}
