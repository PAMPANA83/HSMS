using HSMS.Application.IServices;
using HSMS.contracts.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HSMS_be.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly DesignationsIService _designationService;

        public DesignationController(DesignationsIService designationService)
        {
            _designationService = designationService;
        }

        [HttpPost("CreateDesignation")]
        public async Task<IActionResult> CreateDesignation([FromBody] DesigDto dto)
        {
            var res = await _designationService.CreateDesignationAsync(dto);
            if (!res.IsSuccess)
            {
                return BadRequest(res.ErrorMessage);
            }
            return Ok(res.Data);
        }

        [HttpGet("GetAlldesignation")]
        public async Task<IActionResult> GetDesignations()
        {
            var res = await _designationService.GetDesignationsAsync();
            if (!res.IsSuccess)
            {
                return BadRequest(res.ErrorMessage);
            }
            return Ok(res.Data);

        }

        [HttpDelete("DeleteDesignation/{id}")]
        public async Task<IActionResult> DeleteDesignation(int id)
        {
            var res = await _designationService.DeleteDesignationAsync(id);
            if (!res.IsSuccess)
            {
                return BadRequest(res.ErrorMessage);
            }
            return Ok(res.Data);
        }

        [HttpGet("GetDesignationsbyID/{id}")]
        public async Task<IActionResult> GetDesignationsbyID(int id)
        {
            var res = await _designationService.GetDesignationsByBranchIdAsync(id);
            if (!res.IsSuccess)
            {
                return BadRequest(res.ErrorMessage);
            }
            return Ok(res.Data);
        }
    }
}
