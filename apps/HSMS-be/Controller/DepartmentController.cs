using HSMS.Application.IServices;
using HSMS.contracts.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HSMS_be.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentIServices _Service;

        public DepartmentController(DepartmentIServices Service)
        {
            _Service = Service;
        }

        [HttpPost("CreateDepartment")]
        public async Task<IActionResult> CreateDepartment([FromBody] Departmentdto dto)
        {
            var res = await _Service.CreateDepartmentAsync(dto);
            if (!res.IsSuccess)
            {
                return BadRequest(res.ErrorMessage);
            }
            return Ok(res.Data);
        }


        [HttpDelete("DeleteDepartment/{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var res = await _Service.DeleteDepartmentAsync(id);
            if (!res.IsSuccess)
            {
                return BadRequest(res.ErrorMessage);
            }
            return Ok(res.Data);
        }

        [HttpGet("GetALLDepartment")]
        public async Task<IActionResult> GetDepartment()
        {
            var res = await _Service.GetDepartmentsAsync();
            if (!res.IsSuccess)
            {
                return BadRequest(res.ErrorMessage);
            }
            return Ok(res.Data);
        }

        [HttpGet("GetDepartmentByMainID/{Mainid}")]
        public async Task<IActionResult> GetDepartmentByBranchID(int Mainid)
        {
            var res = await _Service.GetDepartmentsByBranchIdAsync(Mainid);
            if (!res.IsSuccess)
            {
                return BadRequest(res.ErrorMessage);
            }
            return Ok(res.Data);
        }
    }
}
