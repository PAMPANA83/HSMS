using HSMS.Domain.Domains;
using HSMS.shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Application.IRepositories
{
    public interface DesignationsIRepositories
    {
        Task<Result<List<Designations>>> GetAllDesignations();
        Task<Result<Designations>> GetDesignationById(int id);
        Task<Result<bool>> CreateDesignation(Designations designation);
        Task<Result<bool>> UpdateDesignation(Designations designation);
        Task<Result<bool>> DeleteDesignation(int id);
    }
}
