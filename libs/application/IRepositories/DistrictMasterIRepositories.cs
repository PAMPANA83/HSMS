using HSMS.Domain.Domains;
using HSMS.shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Application.IRepositories
{
    public interface DistrictMasterIRepositories
    {
        Task<Result<bool>> CreateDistrictMasterAsync(DistrictMasters dto);
        Task<Result<bool>> UpdateDistrictMasterAsync(DistrictMasters dto);
        Task<Result<List<DistrictMasters>>> GetAllDistrictMasterAsync();
        Task<Result<List<DistrictMasters>>> GetAllDistrictMastersAsync(List<int?> id);
        Task<Result<bool>> DeleteDistrictMasterAsync(int id);

    }
}
