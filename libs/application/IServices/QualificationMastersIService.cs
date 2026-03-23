using HSMS.contracts.Dto;
using HSMS.shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Application.IServices
{
    public interface QualificationMastersIService
    {
        Task<Result<string>> CreateQualificationMasterAsync(Qualification dto);
        Task<Result<string>> DeleteQualificationMasterAsync(int Id);
        Task<Result<List<QualificationMastersDto>>> GetQualificationMasterAsync();      

    }
}
