using HSMS.contracts.Dto;
using HSMS.Domain.Domains;
using HSMS.shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Application.IServices
{
    public interface MainDepartmentIService
    {
        Task<Result<string>> CreateMainDepartmentAsync(MainDepartmentdto dto);
        Task<Result<string>> DeleteMainDepartmentAsync(int id);
        Task<Result<List<MainDepartmentMastersDto>>> GetAllMainDepartmentAysnc();
    }
}
