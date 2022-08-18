using Microsoft.AspNetCore.Mvc;
using PMOSRS.Areas.API.Controllers.Base;
using PMOSRS.Data.Core.Business;
using PMOSRS.Data.Core.Repository;
using PMOSRS.Model.Models.Entities;
using System;
using System.Threading.Tasks;

namespace PMOSRS.Areas.API
{

    [Area("API")]
    public class ProjectController : BaseController
    {
        private readonly ProjectRepository _projectRepository;
        private readonly ProjectBusiness _projectBusiness;

        public ProjectController(ProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
            _projectBusiness = new ProjectBusiness(_projectRepository);
        }

        [HttpPost("Add")]
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

        [HttpPost("List")]
        public async Task<IActionResult> List()
        {
            return Json(await _projectBusiness.Select());
        }

    }
}
