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
    public class TSController : BaseController
    {
        private readonly TSRepository _tSRepository;
        private readonly TSBusiness _tSBusiness;

        public TSController(TSRepository tSRepository)
        {
            _tSRepository = tSRepository;
            _tSBusiness = new TSBusiness(_tSRepository);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] t_TSs entity)
        {
            return Json(await _tSBusiness.Add(entity));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] t_TSs entity)
        {
            return Json(await _tSBusiness.Update(entity));
        }

        [HttpGet("Remove")]
        public async Task<IActionResult> Remove(Guid id)
        {
            return Json(await _tSBusiness.Delete(id));
        }

        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            //var query = from m in _tSBusiness
            //            join pi in _tSBusiness on
            //            m.ProjectId equals pi.ProjectId
            return Json(await _tSBusiness.IliskiliSelect());
        }
    }
}
