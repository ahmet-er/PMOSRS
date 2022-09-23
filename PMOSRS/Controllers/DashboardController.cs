using Microsoft.AspNetCore.Mvc;
using PMOSRS.Model.Models.Context;
using System.Linq;

namespace PMOSRS.Controllers
{
    [Route("[Controller]")]
    public class DashboardController : Controller
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
        [HttpGet("Project")]
        public IActionResult Project()
        {
            using (var context = new PMOSRSContext())
            {
                var settings = context.t_Settings.First();
                ViewBag.v = settings.Version;
            }
            return View();
        }
        [HttpGet("TS")]
        public IActionResult TS()
        {
            using (var context = new PMOSRSContext())
            {
                var settings = context.t_Settings.First();
                ViewBag.v = settings.Version;
            }
            return View();
        }
        [HttpGet("TID")]
        public IActionResult TID()
        {
            using (var context = new PMOSRSContext())
            {
                var settings = context.t_Settings.First();
                ViewBag.v = settings.Version;
            }
            return View();
        }
        [HttpGet("SRS")]
        public IActionResult SRS()
        {
            using (var context = new PMOSRSContext())
            {
                var settings = context.t_Settings.First();
                ViewBag.v = settings.Version;
            }
            return View();
        }
        [HttpGet("Parameter")]
        public IActionResult Parameter()
        {
            using (var context = new PMOSRSContext())
            {
                var settings = context.t_Settings.First();
                ViewBag.v = settings.Version;
            }
            return View();
        }
        [HttpGet("User")]
        public IActionResult User()
        {
            using (var context = new PMOSRSContext())
            {
                var settings = context.t_Settings.First();
                ViewBag.v = settings.Version;
            }
            return View();
        }
        [HttpGet("Reports")]
        public IActionResult Reports()
        {
            using (var context = new PMOSRSContext())
            {
                var settings = context.t_Settings.First();
                ViewBag.v = settings.Version;

                var projectCount = context.t_Projects.Count();
                ViewBag.ProjectCount = projectCount;

                var tsCount = context.t_TSs.Count();
                ViewBag.TSCount = tsCount;

                var tidCount = context.t_TIDs.Count();
                ViewBag.TIDCount = tidCount;

                var srsCount = context.t_SRSs.Count();
                ViewBag.SRSCount = srsCount;

                var userCount = context.t_Users.Count();
                ViewBag.UserCount = userCount;
            }
            return View();
        }

    }
}
