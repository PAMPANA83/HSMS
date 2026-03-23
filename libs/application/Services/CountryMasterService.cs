using AutoMapper;
using HSMS.Application.IServices;
using HSMS.Application.UoW;
using HSMS.contracts.Dto;
using HSMS.Domain.Domains;
using HSMS.shared.Helpers;
using Microsoft.Extensions.Caching.Memory;

namespace HSMS.Application.Services
{
    public class CountryMasterService: CountryMasterIService
    {
       
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        public CountryMasterService(IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Result<string>> CreateCountryMasterAysnc(CountryDto obj)
        {

            try
            {
               
                var ss = GetIPAddress.GetLocalIpAddress();
                var _res = new CountryMasters(null,  
                     string.IsNullOrEmpty(obj.CountryName) ? string.Empty : RegionCode.RegionInfo(obj.CountryName),
                      obj.CountryName,
                     1,
                    DateTimeHelper.Now(),
                    GetIPAddress.GetLocalIpAddress(),
                    null,null,null
                );

                var res = await _unitOfWork.country.CreateCountryMastersAsync(_res);
                if (!res.IsSuccess)
                {
                    return new Result<string>
                    {
                        ErrorMessage = res.ErrorMessage,
                    };
                }
                _cache.Remove(CacheKeys.CountryList);
                return new Result<string>
                {
                    Data = "Country created successfully"
                };
            }
            catch (Exception ex)
            {
                return new Result<string>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<string>> DeleteCountryMasterAsync(int id)
        {
            try
            {
               
                var _res = await _unitOfWork.country.DeleteCountryMasterAsync(id);
                if (!_res.IsSuccess)
                {
                    return new Result<string>
                    {
                        ErrorMessage = _res.ErrorMessage,
                    };
                }
                _cache.Remove(CacheKeys.CountryList);
                return new Result<string>
                {
                    Data = "Country deleted successfully"
                };

            }
            catch (Exception ex)
            {
                return new Result<string>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<List<CountryMastersDto>>> GetAllCountryMastersAysnc()
        {
            try
            {
                if (_cache.TryGetValue(CacheKeys.CountryList, out List<CountryMastersDto> cachedData))
                {
                    return new Result<List<CountryMastersDto>>
                    {
                        Data = cachedData,
                    };
                }
                var _res = await _unitOfWork.country.GetAllCountryMastersAsync();
                if (!_res.IsSuccess)
                {
                    return new Result<List<CountryMastersDto>>
                    {
                        ErrorMessage = _res.ErrorMessage,
                    };
                }
                var result = new List<CountryMastersDto>();
                if (_res.Data != null)
                {
                    result = _mapper.Map<List<CountryMastersDto>>(_res.Data);
                }
                _cache.Set(CacheKeys.CountryList, result, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(3),
                    Priority = CacheItemPriority.High
                });

                return new Result<List<CountryMastersDto>>
                {
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new Result<List<CountryMastersDto>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }
    }
}
