using HSMS.Application.IServices;
using HSMS.contracts.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HSMS_be.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateMastersController : ControllerBase
    {
        private readonly StateMasterIService _stateMasterIService;

        public StateMastersController(StateMasterIService stateMasterIService)
        {
            _stateMasterIService = stateMasterIService;
        }

        [HttpGet("GetAllStateMaster")]
        public async Task<IActionResult> GetAllStateMasters()
        {
            var stateMasters = await _stateMasterIService.GetAllStateMastersAysnc();
            if(stateMasters == null)
            {
                return BadRequest(stateMasters?.ErrorMessage);

            }
            return Ok(stateMasters.Data);
        }

        [HttpPost("CreateState")]
        public async Task<IActionResult> CreateStateMaster([FromBody] StateDto dto)
        {
            if(dto==null)
            {
                return NotFound();
            }
            var _res = await _stateMasterIService.CreateStateMasterAysnc(dto);
            if(!_res.IsSuccess)
            {
                return BadRequest(_res.ErrorMessage);
            }

            return Ok(_res.Data);

        }


        [HttpDelete("DeleteStateId/{id}")]
        public async Task<IActionResult> DeleteStateAsync(int id)
        {
            var res = await _stateMasterIService.DeleteStateMasterAsync(id);
            if (!res.IsSuccess)
            {
                return BadRequest(new { res.ErrorMessage });
            }
            return Ok(res.Data);
        }


        [HttpGet("GetStateId/{id}")]
        public async Task<IActionResult> GetStateAsync(int id)
        {
            var res = await _stateMasterIService.GetAllStateMasterbyIdsAysnc(id);
            if (!res.IsSuccess)
            {
                return BadRequest(new { res.ErrorMessage });
            }
            return Ok(res.Data);
        }
    }
}
