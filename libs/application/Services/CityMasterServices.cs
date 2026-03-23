using AutoMapper;
using HSMS.Application.IServices;
using HSMS.Application.UoW;
using HSMS.contracts.Dto;
using HSMS.Domain.Domains;
using HSMS.shared.Helpers;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Application.Services
{
    public class CityMasterServices : CityMasterIServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        public CityMasterServices(IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async  Task<Result<string>> CreateCityMastersAync(CityDto dto)
        {
            try
            {
                var _res = new CityMasters(null, dto.CityID, dto.CityName, dto.DistrictID,
                1, DateTimeHelper.Now(),GetIPAddress.GetLocalIpAddress(), null, null, null);
                var res=await _unitOfWork.city.AddCityMaster(_res);
                if(!res.IsSuccess)
                {
                    return new Result<string>
                    {
                        ErrorMessage = res.ErrorMessage
                    };
                }
                _cache.Remove(CacheKeys.CityList);
                return new Result<string>
                {
                    Data = "City Create successfully"
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

        public async Task<Result<string>> DeleteCityMasterAync(int id)
        {
            try
            {
                var _dist = await _unitOfWork.city.DeleteCityMaster(id);
                if(!_dist.IsSuccess)
                {
                    return new Result<string>
                    {
                        ErrorMessage = _dist.ErrorMessage,
                    };
                }
                _cache.Remove(CacheKeys.CityList);
                return new Result<string>
                {
                    Data= "City deleted successfully"
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

        public async Task<Result<List<CityMastersDto>>> GetCityMasterAync()
        {

            try
            {
                if(_cache.TryGetValue(CacheKeys.CityList,out List<CityMastersDto> citysdto))
                {
                    return new Result<List<CityMastersDto>>
                    {
                        Data = citysdto
                    };
                }

                var _res= await _unitOfWork.city.GetAllCityMasters();
                if (!_res.IsSuccess)
                {
                    return new Result<List<CityMastersDto>>
                    {
                        ErrorMessage = _res.ErrorMessage,
                    };
                }

            

                var _resdist = await _unitOfWork.district.GetAllDistrictMasterAsync();
                if(!_resdist.IsSuccess)
                {
                    return new Result<List<CityMastersDto>>
                    {
                        ErrorMessage = _resdist.ErrorMessage,
                    };
                }

                List<CityMastersDto> result = (from c in _res.Data
                                               join d in _resdist.Data on c.DistrictID equals d.ID
                                               select new CityMastersDto
                                               {
                                                   ID= c.ID,
                                                   DistrictID= c.DistrictID,
                                                   CityID= c.CityID,
                                                   CityName= c.CityName,
                                                   DistrictName=d.DistrictName,
                                                   CREATEDATE=c.CREATEDATE,
                                                   CREATETERMINALID=c.CREATETERMINALID,
                                                   CREATEUSERID=c.CREATEUSERID,
                                                   EDITDATE=c.EDITDATE,
                                                   EDITTERMINALID=c.EDITTERMINALID,
                                                   EDITUSERID=c.EDITUSERID
                                               }
                                              ).ToList();

                _cache.Set(CacheKeys.CityList, result, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(3),
                    Priority = CacheItemPriority.High
                });

                return new Result<List<CityMastersDto>>
                {
                    Data = result,
                };
            }
            catch (Exception ex)
            {
                return new Result<List<CityMastersDto>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }
    }
}
