using HSMS.Domain.Domains;
using HSMS.shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Application.IRepositories
{
    public interface MainDepartmentMastersIRepositories
    {
        Task<Result<List<MainDepartmentMasters>>> GetAllMainDepartmentMasters();
        Task<Result<MainDepartmentMasters>> GetMainDepartmentMasterById(int id);
        Task<Result<bool>> CreateMainDepartmentMaster(MainDepartmentMasters dto);
        Task<Result<bool>> UpdateMainDepartmentMaster(MainDepartmentMasters dto);
        Task<Result<bool>> DeleteMainDepartmentMaster(int id);
    }
}
