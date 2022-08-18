using Microsoft.AspNetCore.Mvc;
using PMOSRS.Areas.API.Controllers.Base;
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

        public RoleController(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] t_Roles entity)
        {
            return View();
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] t_Roles entity)
        {
            return View();
        }

        [HttpPost("Remove")]
        public async Task<IActionResult> Remove([FromBody] Guid id)
        {
            return View();
        }

        [HttpPost("List")]
        public async Task<IActionResult> List()
        {
            return View();
        }
    }
}
