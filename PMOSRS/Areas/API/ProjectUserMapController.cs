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
    [Route("API/[Controller]")]
    public class ProjectUserMapController : BaseController
    {
        private readonly ProjectUserMapRepository _projectUserMapRepository;
        private readonly ProjectUserMapBusiness _projectUserMapBusiness;

        public ProjectUserMapController(ProjectUserMapRepository projectUserMapRepository)
        {
            _projectUserMapRepository = projectUserMapRepository;
            _projectUserMapBusiness = new ProjectUserMapBusiness(_projectUserMapRepository);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] t_ProjectUserMaps entity)
        {
            return Json(await _projectUserMapBusiness.Add(entity));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] t_ProjectUserMaps entity)
        {
            return Json(await _projectUserMapBusiness.Update(entity));
        }

        [HttpGet("Remove")]
        public async Task<IActionResult> Remove(Guid id)
        {
            return Json(await _projectUserMapBusiness.Delete(id));
        }

        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            return Json(await _projectUserMapBusiness.Select());
        }
    }
}
