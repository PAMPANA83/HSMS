using HSMS.Domain.Domains;
using HSMS.shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Application.IRepositories
{
    public interface DepartmentMastersIRepositories
    {
        Task<Result<List<DepartmentMasters>>> GetAllDepartmentMasters();
        Task<Result<DepartmentMasters>> GetDepartmentMastersById(int id);
        Task<Result<bool>> AddDepartmentMasters(DepartmentMasters departmentMasters);
        Task<Result<bool>> UpdateDepartmentMasters(DepartmentMasters departmentMasters);
        Task<Result<bool>> DeleteDepartmentMasters(int id);
        Task<Result<List<DepartmentMasters>>> GetDepartmentMastersByIdAsync(int id);
    }
}
