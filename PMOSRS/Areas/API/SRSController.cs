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
    public class SRSController : BaseController
    {
        private readonly SRSRepository _sRSRepository;
        private readonly SRSBusiness _sRSBusiness;

        public SRSController(SRSRepository sRSRepository)
        {
            _sRSRepository = sRSRepository;
            _sRSBusiness = new SRSBusiness(_sRSRepository);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] t_SRSs entity)
        {
            return Json(await _sRSBusiness.Add(entity));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] t_SRSs entity)
        {
            return Json(await _sRSBusiness.Update(entity));
        }

        [HttpGet("Remove")]
        public async Task<IActionResult> Remove(Guid id)
        {
            return Json(await _sRSBusiness.Delete(id));
        }

        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            return Json(await _sRSBusiness.IliskiliList());
        }
    }
}
