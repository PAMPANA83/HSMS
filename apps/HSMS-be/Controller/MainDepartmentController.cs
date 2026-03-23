using HSMS.Application.IServices;
using HSMS.contracts.Dto;
using HSMS.Domain.Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HSMS_be.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainDepartmentController : ControllerBase
    {
        private readonly MainDepartmentIService _service;

        public MainDepartmentController(MainDepartmentIService service)
        {
            _service = service;
        }

        [HttpPost("CreateMainDepartment")]
        public async Task<IActionResult> CreateMainDepartment(MainDepartmentdto dto)
        {
            var result = await _service.CreateMainDepartmentAsync(dto);
            if (result.IsSuccess)
                return Ok(result.Data);
            else
                return BadRequest(result.ErrorMessage);
        }

        [HttpDelete("DeleteMainDepartment/{id}")]
        public async Task<IActionResult> DeleteMainDepartment(int id)
        {
            var result = await _service.DeleteMainDepartmentAsync(id);
            if (result.IsSuccess)
                return Ok(result.Data);
            else
                return BadRequest(result.ErrorMessage);
        }

        [HttpGet("GetAllMainDepartment")]
        public async Task<IActionResult> GetAllMainDepartment()
        {
            var result = await _service.GetAllMainDepartmentAysnc();
            if (result.IsSuccess)
                return Ok(result.Data);
            else
                return BadRequest(result.ErrorMessage);

        }



    }
}
