using HSMS.Domain.Domains;
using HSMS.shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Application.IRepositories
{
    public interface BranchMastersIRepositories
    {
        Task<Result< List<BranchMasters>>> GetAllBranchMasters();
        Task<Result<BranchMasters>> GetBranchMastersById(int id);
        Task<Result<bool>> AddBranchMasters(BranchMasters branchMasters);
        Task<Result<bool>> UpdateBranchMasters(BranchMasters branchMasters);
        Task<Result<bool>> DeleteBranchMasters(int id);

        Task<Result<List<BranchMasters>>> GetAllBranchMastersAsync(List<int?> id);

    }
}
