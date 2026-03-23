using HSMS.contracts.Dto;
using HSMS.shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Application.IServices
{
    public interface CompanyMasterIService
    {
        Task<Result<string>> CreateCompanyMasterAysnc(CompanyDto dto);
        Task<Result<List<CompanyMastersDto>>> GetAllCompnayMasterAsync();
        Task<Result<string>> DeleteCompnayMasterAsync(int id);
    }
}
