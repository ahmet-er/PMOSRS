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
    public class FileController : BaseController
    {
        private readonly FileRepository _fileRepository;
        private readonly FileBusiness _fileBusiness;

        public FileController(FileRepository fileRepository)
        {
            _fileRepository = fileRepository;
            _fileBusiness = new FileBusiness(_fileRepository);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] t_Files entity)
        {
            return Json(await _fileBusiness.Add(entity));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] t_Files entity)
        {
            return Json(await _fileBusiness.Update(entity));
        }

        [HttpGet("Remove")]
        public async Task<IActionResult> Remove(Guid id)
        {
            return Json(await _fileBusiness.Delete(id));
        }

        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            return Json(await _fileBusiness.List());
        }
    }
}
