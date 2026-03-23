using HSMS.contracts.Dto;
using HSMS.shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Application.IServices
{
    public interface DistrictMasterIService
    {
        Task<Result<string>> CreateDistrictMasterAysnc(Districtdto obj);
        Task<Result<List<DistrictMasterdto>>> GetAllDistrictMastersAysnc();
        Task<Result<string>> DeleteDistrictMasterAsync(int id);

        Task<Result<List<DistrictMasterdto>>> GetAllDistrictMastersbyIDAysnc(int id);
    }
}
