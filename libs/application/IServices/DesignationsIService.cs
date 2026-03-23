using HSMS.contracts.Dto;
using HSMS.shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Application.IServices
{
    
    public  interface DesignationsIService
    {
        Task<Result<string>> CreateDesignationAsync(DesigDto dto);
        Task<Result<string>> DeleteDesignationAsync(int id);
        Task<Result<List<DesignationsDto>>> GetDesignationsAsync();

        Task<Result<List<DesignationsDto>>> GetDesignationsByBranchIdAsync(int Id);
    }
}
