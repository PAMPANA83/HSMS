using HSMS.contracts.Dto;
using HSMS.shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Application.IServices
{
    public interface CityMasterIServices
    {
        Task<Result<string>> CreateCityMastersAync(CityDto dto);
        Task<Result<List<CityMastersDto>>> GetCityMasterAync();
        Task<Result<string>> DeleteCityMasterAync(int id);

      
    }
}
