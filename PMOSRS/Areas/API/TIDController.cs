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
    public class TIDController : BaseController
    {
        private readonly TIDRepository _tIDRepository;
        private readonly TIDBusiness _tIDBusiness;

        public TIDController(TIDRepository tIDRepository)
        {
            _tIDRepository = tIDRepository;
            _tIDBusiness = new TIDBusiness(_tIDRepository);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] t_TIDs entity)
        {
            return Json(await _tIDBusiness.Add(entity));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] t_TIDs entity)
        {
            return Json(await _tIDBusiness.Update(entity));
        }

        [HttpGet("Remove")]
        public async Task<IActionResult> Remove(Guid id)
        {
            return Json(await _tIDBusiness.Delete(id));
        }

        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            return Json(await _tIDBusiness.IliskiliList());
        }
    }
}
