using HSMS.Domain.Domains;
using HSMS.shared.Helpers;

namespace HSMS.Application.IRepositories
{
    public interface CountryMasterIRepositories
    {
        Task<Result<CountryMasters>> CreateCountryMastersAsync(CountryMasters dto);
        Task<Result<List<CountryMasters>>> GetAllCountryMastersAsync();

        Task<Result<bool>> DeleteCountryMasterAsync(int id);

        Task<Result<List<CountryMasters>>> GetAllCountryMasterAsync(int[] ids);
       
    }
}
