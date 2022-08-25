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
    public class UserController : BaseController
    {
        private readonly UserRepository _userRepository;
        private readonly UserBusiness _userBusiness;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
            _userBusiness = new UserBusiness(_userRepository);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] t_Users entity)
        {
            return Json(await _userBusiness.Add(entity));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] t_Users entity)
        {
            return Json(await _userBusiness.Update(entity));
        }

        [HttpGet("Remove")]
        public async Task<IActionResult> Remove(Guid id)
        {
            return Json(await _userBusiness.Delete(id));
        }

        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            return Json(await _userBusiness.Select());
        }
    }
}
