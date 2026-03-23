using HSMS.Application.IServices;
using HSMS.contracts.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HSMS_be.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictMasterController : ControllerBase
    {
        private readonly DistrictMasterIService _service;

        public DistrictMasterController(DistrictMasterIService services)
        {
            _service = services;
        }

        [HttpPost("CreateDistrict")]
        public async Task<IActionResult> CreateDistrictAsync([FromBody] Districtdto dto)
        {
            var res = await _service.CreateDistrictMasterAysnc(dto);
            if (!res.IsSuccess)
            {
                return BadRequest(res.ErrorMessage);
            }

            return Ok(res.Data);

        }
        [HttpDelete("DeleteDistrictId/{id}")]
        public async Task<IActionResult> DeleteDistrictAsync(int id)
        {
            var res = await _service.DeleteDistrictMasterAsync(id);
            if (!res.IsSuccess)
            {
                return BadRequest(new { res.ErrorMessage });
            }
            return Ok(res.Data);
        }

        [HttpGet("GetAllDistrict")]
        public async Task<IActionResult> GetAllDistrictAsync()
        {
            var res = await _service.GetAllDistrictMastersAysnc();
            if (!res.IsSuccess)
            {
                return BadRequest(res.ErrorMessage);
            }

            return Ok(res.Data);
        }

        [HttpGet("GetAllDistrictbyID/{id}")]
        public async Task<IActionResult> GetAllDistrictbyIDAsync(int id)
        {
            var res = await _service.GetAllDistrictMastersbyIDAysnc(id);
            if (!res.IsSuccess)
            {
                return BadRequest(res.ErrorMessage);
            }
            return Ok(res.Data);
        }
    }
}
