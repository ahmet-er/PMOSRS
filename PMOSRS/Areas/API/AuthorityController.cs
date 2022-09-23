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
    public class AuthorityController : BaseController
    {
        private readonly AuthorityRepository _authorityRepository;
        private readonly AuthorityBusiness _authorityBusiness;

        public AuthorityController(AuthorityRepository authorityRepository)
        {
            _authorityRepository = authorityRepository;
            _authorityBusiness = new AuthorityBusiness(_authorityRepository);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] t_Authorities entity)
        {
            return Json(await _authorityBusiness.Add(entity));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] t_Authorities entity)
        {
            return Json(await _authorityBusiness.Update(entity));
        }

        [HttpGet("Remove")]
        public async Task<IActionResult> Remove(Guid id)
        {
            return Json(await _authorityBusiness.Delete(id));
        }

        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            return Json(await _authorityBusiness.List());
        }
    }
}
