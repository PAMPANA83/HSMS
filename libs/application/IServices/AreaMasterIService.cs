using HSMS.contracts.Dto;
using HSMS.shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Application.IServices
{
    public interface AreaMasterIService
    {
        Task<Result<string>> CreateAreaMastersAsync(AreaDto dto);

        Task<Result<List<AreaMastersDto>>> GetAllAreaMasterAsync();

        Task<Result<string>> DeleteAreaMasterAsync(int id);

        Task<Result<List<AreaMastersDto>>> GetAreaMasterByIdAsync(int id);
    }
}
