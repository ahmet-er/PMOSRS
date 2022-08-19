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
    public class RoleController : BaseController
    {
        private readonly RoleRepository _roleRepository;
        private readonly RoleBusiness _roleBusiness;

        public RoleController(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
            _roleBusiness = new RoleBusiness(_roleRepository);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] t_Roles entity)
        {
            return Json(await _roleBusiness.Add(entity));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] t_Roles entity)
        {
            return Json(await _roleBusiness.Update(entity));
        }

        [HttpPost("Remove")]
        public async Task<IActionResult> Remove([FromBody] Guid id)
        {
            return Json(await _roleBusiness.Delete(id));
        }

        [HttpPost("List")]
        public async Task<IActionResult> List()
        {
            return Json(await _roleBusiness.Select());
        }
    }
}
