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
    public class AuthorityRoleMapController : BaseController
    {
        private readonly AuthorityRoleMapRepository _authorityRoleMapRepository;
        private readonly AuthorityRoleMapBusiness _authorityRoleMapBusiness;

        public AuthorityRoleMapController(AuthorityRoleMapRepository authoryRoleMapRepository)
        {
            _authorityRoleMapRepository = authoryRoleMapRepository;
            _authorityRoleMapBusiness = new AuthorityRoleMapBusiness(_authorityRoleMapRepository);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] t_AuthorityRoleMaps entity)
        {
            return Json(await _authorityRoleMapBusiness.Add(entity));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] t_AuthorityRoleMaps entity)
        {
            return Json(await _authorityRoleMapBusiness.Update(entity));
        }

        [HttpPost("Remove")]
        public async Task<IActionResult> Remove([FromBody] Guid id)
        {
            return Json(await _authorityRoleMapBusiness.Delete(id));
        }

        [HttpPost("List")]
        public async Task<IActionResult> List()
        {
            return Json(await _authorityRoleMapBusiness.Select());
        }
    }
}
