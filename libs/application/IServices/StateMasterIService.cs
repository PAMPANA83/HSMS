using HSMS.contracts.Dto;
using HSMS.shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Application.IServices
{
    public interface StateMasterIService
    {
        Task<Result<string>> CreateStateMasterAysnc(StateDto obj);
        Task<Result<List<StateMasterDto>>> GetAllStateMastersAysnc();
        Task<Result<string>> DeleteStateMasterAsync(int id);

        Task<Result<List<StateMasterDto>>> GetAllStateMasterbyIdsAysnc(int Id);

    }
}
