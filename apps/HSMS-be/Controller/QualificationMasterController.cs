using HSMS.Application.IServices;
using HSMS.contracts.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HSMS_be.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualificationMasterController : ControllerBase
    {
        private readonly QualificationMastersIService _Service;

        public QualificationMasterController(QualificationMastersIService Service)
        {
            _Service = Service;
        }

        [HttpPost("CreateQualificationMaster")]
        public async Task<IActionResult> CreateQualificationMaster(Qualification dto)
        {
            var res = await _Service.CreateQualificationMasterAsync(dto);
            if (!res.IsSuccess)
            {
                return BadRequest(res.ErrorMessage);
            }
            return Ok(res.Data);
        }

        [HttpDelete("DeleteQualificationMaster/{id}")]
        public async Task<IActionResult> DeleteQualificationMaster(int id)
        {
            var res = await _Service.DeleteQualificationMasterAsync(id);
            if (!res.IsSuccess)
            {
                return BadRequest(res.ErrorMessage);
            }
            return Ok(res.Data);
        }

        [HttpGet("GetALLQualificationMaster")]
        public async Task<IActionResult> GetQualificationMaster()
        {
            var res = await _Service.GetQualificationMasterAsync();
            if (!res.IsSuccess)
            {
                return BadRequest(res.ErrorMessage);
            }
            return Ok(res.Data);
        }
    }
}
