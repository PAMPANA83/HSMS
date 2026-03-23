using HSMS.Application.IServices;
using HSMS.contracts.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HSMS_be.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityMasterController : ControllerBase
    {
        private readonly CityMasterIServices _services;

        public CityMasterController(CityMasterIServices services)
        {
            _services = services;
        }

        [HttpPost("CreateCity")]
        public async Task<IActionResult> CreateCityMaster([FromBody] CityDto dto)
        {
            var res=await _services.CreateCityMastersAync(dto);
            if(!res.IsSuccess)
            {
                return BadRequest(res.ErrorMessage);
            }

            return Ok(res.Data);
        }

        [HttpGet("GetAllCityMaster")]
        public async Task<IActionResult> GetAllCityMasterAsync()
        {
            var res = await _services.GetCityMasterAync();
            if (!res.IsSuccess)
            {
                return BadRequest(res.ErrorMessage);
            }
            
            return Ok(res.Data);               
            
        }

        [HttpDelete("CityMasterById")]
        public async Task<IActionResult> DeleteCityMasterAsync([FromBody] int CityId)
        {
            var res= await _services.DeleteCityMasterAync(CityId);
            if(!res.IsSuccess)
            {
                return BadRequest(res.ErrorMessage);
            }
            return Ok(res.Data);
        }


        [HttpGet("CityMasterByDistId")]
        public async Task<IActionResult> DeleteCityMasterbyIDAsync([FromBody] int Id)
        {
            var res = await _services.GetCityMasterByIdAync(Id);
            if (!res.IsSuccess)
            {
                return BadRequest(res.ErrorMessage);
            }
            return Ok(res.Data);
        }
    }
}
