using Microsoft.AspNetCore.Mvc;
using PMOSRS.Model.Models.Entities;

namespace PMOSRS.Areas.UI.Controllers
{
    [Area("UI")]
    public class RegisterController : Controller
    {
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Index(t_Users users)
        //{
        //    return users == null ? View() : View(users);
        //}
    }
}
