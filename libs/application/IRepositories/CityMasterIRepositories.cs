using HSMS.Domain.Domains;
using HSMS.shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Application.IRepositories
{
    public interface CityMasterIRepositories
    {
        Task<Result<bool>> AddCityMaster(CityMasters cityMaster);
        Task<Result<bool>> UpdateCityMaster(CityMasters cityMaster);
        Task<Result<bool>> DeleteCityMaster(int id);
        Task<Result<CityMasters>> GetCityMasterById(int id);
        Task<Result<List<CityMasters>>> GetAllCityMasters();

        Task<Result<List<CityMasters>>> GetAllCityMastersAsync(List<int?> id);
    }
}
