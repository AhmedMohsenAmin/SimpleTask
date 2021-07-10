using Task.BLL;
using Task.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Entity;

namespace Invoicing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StepController : ControllerBase
    {
        public IUnitOfWork IUnitOfWork;
        StepManager _Manager;
        public StepController(IUnitOfWork UOW)
        {
            IUnitOfWork = UOW;
            _Manager = new StepManager(IUnitOfWork);
        }

        [HttpGet("GetAllSteps")]
        public async Task<IActionResult> GetAllSteps()
        {
            var _response = await _Manager.GetSteps();
            return Ok(_response);
        }

        [HttpGet("GetStepByKey")]
        public async Task<IActionResult> GetStepByKey(Int64 Id)
        {
            var _response = await _Manager.GetStepByKey(Id);
            return Ok(_response);
        }

        [HttpPut("UpdateStep")]
        public async Task<IActionResult> UpdateStep(Step step)
        {
            var _response = await _Manager.UpdateStep(step);
            return Ok(_response);
        }

        [HttpPut("DeleteStep")]
        public async Task<IActionResult> DeleteStep(Int64 Id)
        {
            var _response = await _Manager.SoftDeleteStep(Id);
            return Ok(_response);
        }
    }
}
