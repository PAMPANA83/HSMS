using HSMS.Domain.Domains;
using HSMS.shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Application.IRepositories
{
    public interface QualificationMastersIRepositories
    {
        Task<Result<List<QualificationMasters>>> GetAllQualificationMasters();
        Task<Result<QualificationMasters>> GetQualificationMasterById(int id);
        Task<Result<bool>> CreateQualificationMaster(QualificationMasters dto);
        Task<Result<bool>> UpdateQualificationMaster(QualificationMasters dto);
        Task<Result<bool>> DeleteQualificationMaster(int id);
    }
}
