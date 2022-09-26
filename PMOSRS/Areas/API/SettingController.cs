using Microsoft.AspNetCore.Mvc;
using PMOSRS.Areas.API.Controllers.Base;
using PMOSRS.Data.Core.Business;
using PMOSRS.Data.Core.Repository;
using PMOSRS.Model.Models.Context;
using PMOSRS.Model.Models.Entities;
using System;
using System.Threading.Tasks;

namespace PMOSRS.Areas.API
{
    [Area("API")]
    [Route("API/[Controller]")]
    public class SettingController : BaseController
    {
        private readonly SettingRepository _settingRepository;
        private readonly SettingBusiness _settingBusiness;

        public SettingController(SettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
            _settingBusiness = new SettingBusiness(_settingRepository);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] t_Settings entity)
        {
            return Json(await _settingBusiness.Add(entity));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] t_Settings entity)
        {
            return Json(await _settingBusiness.Update(entity));
        }

        [HttpGet("Remove")]
        public async Task<IActionResult> Remove(Guid id)
        {
            return Json(await _settingBusiness.Delete(id));
        }

        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            return Json(await _settingBusiness.List());
        }
    }
}
