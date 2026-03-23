using HSMS.Domain.Domains;
using HSMS.shared.Helpers;

namespace HSMS.Application.IRepositories
{
    public interface StateMasterIRepositories
    {
        Task<Result<bool>> CreateStateMasterAsync(StateMasters dto);
        Task<Result<bool>> UpdateStateMasterAsync(StateMasters dto);
        Task<Result<List<StateMasters>>> GetAllStateMasterAsync();
        Task<Result<bool>> DeleteStateMasterAsync(int id);

        Task<Result<List<StateMasters>>> GetAllStateMasteByIDrAsync(List<int?> id);
    }
}
