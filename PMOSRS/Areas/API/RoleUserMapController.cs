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
    public class RoleUserMapController : BaseController
    {
        private readonly RoleUserMapRepository _roleUserMapRepository;
        private readonly RoleUserMapBusiness _roleUserMapBusiness;

        public RoleUserMapController(RoleUserMapRepository roleUserMapRepository)
        {
            _roleUserMapRepository = roleUserMapRepository;
            _roleUserMapBusiness = new RoleUserMapBusiness(_roleUserMapRepository);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] t_RoleUserMaps entity)
        {
            return Json(await _roleUserMapBusiness.Add(entity));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] t_RoleUserMaps entity)
        {
            return Json(await _roleUserMapBusiness.Update(entity));
        }

        [HttpGet("Remove")]
        public async Task<IActionResult> Remove(Guid id)
        {
            return Json(await _roleUserMapBusiness.Delete(id));
        }

        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            return Json(await _roleUserMapBusiness.List());
        }
    }
}
