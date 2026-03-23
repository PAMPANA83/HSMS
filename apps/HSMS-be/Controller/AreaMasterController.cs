using HSMS.Application.IServices;
using HSMS.contracts.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HSMS_be.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaMasterController : ControllerBase
    {
        private readonly AreaMasterIService _service;

        public AreaMasterController(AreaMasterIService service)
        {
            _service = service;
        }

        [HttpGet("GetAllAreaMaster")]
        public async Task<IActionResult> GetAllAreaMasterAsync()
        {
            var res = await _service.GetAllAreaMasterAsync();
            if (!res.IsSuccess)
            {
                return BadRequest(res.ErrorMessage);
            }
            return Ok(res.Data);
        }

        [HttpPost("CreateArea")]
        public async Task<IActionResult> CreateAreaMasterAsync([FromBody] AreaDto dto)
        {
            var res = await _service.CreateAreaMastersAsync(dto);
            if (!res.IsSuccess)
            {
                return BadRequest(res.ErrorMessage);
            }
            return Ok(res.Data);
        }

        [HttpDelete("DeleteAreaId/{id}")]
        public async Task<IActionResult> DeleteAreaMasterAsync(int id)
        {
            var res = await _service.DeleteAreaMasterAsync(id);
            if (!res.IsSuccess)
            {
                return BadRequest(res.ErrorMessage);
            }
            return Ok(res.Data);
        }

        [HttpGet("GetAreabyId/{id}")]
        public async Task<IActionResult> GetAreaMasterByIdAsync(int id)
        {
            var res = await _service.GetAreaMasterByIdAsync(id);
            if (!res.IsSuccess)
            {
                return BadRequest(res.ErrorMessage);
            }
            return Ok(res.Data);
        }
    }
}
