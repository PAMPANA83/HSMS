using HSMS.contracts.Dto;
using HSMS.shared.Helpers;

namespace HSMS.Application.IServices
{
    public interface CountryMasterIService
    {
        Task<Result<string>> CreateCountryMasterAysnc(CountryDto obj);
        Task<Result<List<CountryMastersDto>>> GetAllCountryMastersAysnc();
        Task<Result<string>> DeleteCountryMasterAsync(int id);
    }
}
