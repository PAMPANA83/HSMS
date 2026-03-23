using HSMS.Domain.Domains;
using HSMS.shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Application.IRepositories
{
    public interface CompanyMastersIRepositories
    {
        Task<Result<List<CompanyMasters>>> GetAllCompanyMasters();
        Task<Result<CompanyMasters>> GetCompanyMasterById(int id);
        Task<Result<bool>> CreateCompanyMaster(CompanyMasters companyMaster);
        Task<Result<bool>> UpdateCompanyMaster(CompanyMasters companyMaster);
        Task<Result<bool>> DeleteCompanyMaster(int id);
        Task<Result<List<CompanyMasters>>> GetAllCompanyMastersAsync(List<int?> id);
    }
}
