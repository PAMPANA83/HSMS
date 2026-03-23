using HSMS.Domain.Domains;
using HSMS.shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Application.IRepositories
{
    public interface AreaMastersIRepositories
    {
        Task<Result<bool>> AddAreaMaster(AreaMasters areaMaster);
        Task<Result<bool>> UpdateAreaMaster(AreaMasters areaMaster);
        Task<Result<bool>> DeleteAreaMaster(int id);
        Task<Result<AreaMasters>> GetAreaMasterById(int id);
        Task<Result<List<AreaMasters>>> GetAllAreaMasters();
        
        Task<Result<List<AreaMasters>>> GetAllAreaMastersAsync(List<int?> id);
    }
}
