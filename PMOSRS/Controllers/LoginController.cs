using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMOSRS.Model.Models.Context;
using PMOSRS.Model.Models.Items;
using PMOSRS.Models;
using System.Diagnostics;
using System.Linq;

namespace PMOSRS.Controllers
{
	[Route("[Controller]")]
	public class LoginController : Controller
	{
		[HttpGet("Index")]
		public IActionResult Index()
		{
			LoginItem loginItem = new LoginItem();
			return View(loginItem);
		}

        [HttpPost("Index")]
        public IActionResult Index(LoginItem loginItem)
        {
            string message;
            int responsetypeid;
            PMOSRSContext c = new PMOSRSContext();
            var loginstatus = c.t_Users.Where(x => x.Email == loginItem.Email && x.Password == loginItem.Password).FirstOrDefault();
            if (loginstatus != null)
            {
                message = "Giriş Başarılı";
                responsetypeid = 1;
            }
            else
            {
                message = "Geçersiz Giriş";
                responsetypeid = 0;
            }
            return Json(new { message = message, status = responsetypeid });
        }
    }
}
