using HSMS.contracts.Dto;
using HSMS.shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Application.IServices
{
    public interface DepartmentIServices
    {
       Task<Result<string>> CreateDepartmentAsync(Departmentdto dto);
        Task<Result<List<DepartmentMastersDto>>> GetDepartmentsAsync();
        Task<Result<string>> DeleteDepartmentAsync(int id);
        Task<Result<List<DepartmentMastersDto>>> GetDepartmentsByBranchIdAsync(int id);

    }
}
