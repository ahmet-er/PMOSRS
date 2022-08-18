using Microsoft.AspNetCore.Mvc;
using PMOSRS.Areas.API.Controllers.Base;
using PMOSRS.Data.Core.Repository;
using PMOSRS.Model.Models.Entities;
using System;
using System.Threading.Tasks;

namespace PMOSRS.Areas.API
{
    [Area("API")]
    public class SettingController : BaseController
    {
        private readonly SettingRepository _settingRepository;

        public SettingController(SettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] t_Settings entity)
        {
            return View();
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] t_Settings entity)
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
