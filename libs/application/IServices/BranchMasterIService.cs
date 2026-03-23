using HSMS.contracts.Dto;
using HSMS.shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Application.IServices
{
    public interface BranchMasterIService
    {
        Task<Result<string>> CreateBranchMasterAsync(BranchDto dto);
        Task<Result<string>> DeleteBranchMaster(int id);
        Task<Result<List<BranchMastersdto>>> GetAllBranchMasterAync();

        Task<Result<List<BranchMastersdto>>> GetAllBranchMasterByIdAync(int Id);
    }
}
