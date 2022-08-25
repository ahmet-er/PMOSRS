using Microsoft.AspNetCore.Mvc;
using PMOSRS.Data.Core.Business;
using PMOSRS.Data.Core.Repository;
using PMOSRS.Model.Models.Entities;
using System;
using System.Threading.Tasks;

namespace PMOSRS.Controllers
{
    public class HelloController : Controller
    {
        // GET: /HelloWorld/

        public string Index()
        {
            return "This is my default action...";
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }

        private readonly ProjectRepository _projectRepository;
        private readonly ProjectBusiness _projectBusiness;

        public HelloController(ProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
            _projectBusiness = new ProjectBusiness(_projectRepository);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] t_Projects entity)
        {
            return Json(await _projectBusiness.Add(entity));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] t_Projects entity)
        {
            return Json(await _projectBusiness.Update(entity));
        }

        [HttpPost("Remove")]
        public async Task<IActionResult> Remove([FromBody] Guid id)
        {
            return Json(await _projectBusiness.Delete(id));
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Json(await _projectBusiness.Select());
        }
    }
}
