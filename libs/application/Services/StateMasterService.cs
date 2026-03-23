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
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Application.Services
{
    public class StateMasterService : StateMasterIService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        public StateMasterService(IUnitOfWork unitOfWork, IMapper mapper,IMemoryCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Result<string>> CreateStateMasterAysnc(StateDto obj)
        {
            try
            {
                var _res = new StateMasters(null,obj.stateID?? string.Empty,
                      obj.StateName ?? string.Empty,obj.StateCode,obj.CountryID,1,DateTimeHelper.Now(),
                      GetIPAddress.GetLocalIpAddress(),null, null, null);
                var res = await _unitOfWork.state.CreateStateMasterAsync(_res);
                if(!res.IsSuccess)
                {
                    return new Result<string>
                    {
                        ErrorMessage = res.ErrorMessage,
                    };
                }
                _cache.Remove(CacheKeys.StateList);
                return new Result<string>
                {
                    Data = "State created successfully"
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

        public async Task<Result<string>> DeleteStateMasterAsync(int id)
        {
            try
            {   
                var res = await _unitOfWork.state.DeleteStateMasterAsync(id);
                if(!res.IsSuccess)
                {
                    return new Result<string>
                    {
                        ErrorMessage = res.ErrorMessage,
                    };
                }
                _cache.Remove(CacheKeys.StateList);
                return new Result<string>
                {
                    Data = "State deleted successfully"
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

        public async Task<Result<List<StateMasterDto>>> GetAllStateMasterbyIdsAysnc(int Id)
        {
            try
            {
                if (_cache.TryGetValue(CacheKeys.StateList, out List<StateMasterDto> cachedData))
                {
                    return new Result<List<StateMasterDto>>
                    {
                        Data = cachedData?.Where(x=>x.CountryID==Id).ToList(),
                    };
                }
                var res = await _unitOfWork.state.GetAllStateMasterAsync();
                if (!res.IsSuccess)
                {
                    return new Result<List<StateMasterDto>>
                    {
                        ErrorMessage = res.ErrorMessage,
                    };
                }
                var states = res.Data;


                var countryRes = await _unitOfWork.country.GetAllCountryMastersAsync();
                if (!countryRes.IsSuccess)
                {
                    return new Result<List<StateMasterDto>>
                    {
                        ErrorMessage = countryRes.ErrorMessage,
                    };
                }
                var country = countryRes.Data;

                List<StateMasterDto> result = (from s in states
                                               join c in country on s.CountryID equals c.Id
                                               where s.CountryID == Id
                                               select new StateMasterDto
                                               {
                                                   ID = s.ID ?? 0,
                                                   stateID = s.stateID,
                                                   StateName = s.StateName,
                                                   StateCode = s.StateCode,
                                                   CountryID = s.CountryID ?? 0,
                                                   CountryName = c.CountryName ?? "Unknown",
                                                   EDITDATE = s.EDITDATE,
                                                   EDITTERMINALID = s.EDITTERMINALID,
                                                   EDITUSERID = s.EDITUSERID,
                                                   CREATEDATE = s.CREATEDATE,
                                                   CREATETERMINALID = s.CREATETERMINALID,
                                                   CREATEUSERID = s.CREATEUSERID
                                               }).ToList();
                return new Result<List<StateMasterDto>>
                {

                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new Result<List<StateMasterDto>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<List<StateMasterDto>>> GetAllStateMastersAysnc()
        {
            try
            {
                if (_cache.TryGetValue(CacheKeys.StateList, out List<StateMasterDto> cachedData))
                {
                    return new Result<List<StateMasterDto>>
                    {
                        Data = cachedData,
                    };
                }
                var res = await _unitOfWork.state.GetAllStateMasterAsync();
                if (!res.IsSuccess)
                {
                    return new Result<List<StateMasterDto>>
                    {
                        ErrorMessage = res.ErrorMessage,
                    };
                }
                var states = res.Data;


                var countryRes = await _unitOfWork.country.GetAllCountryMastersAsync();
                if (!countryRes.IsSuccess)
                {
                    return new Result<List<StateMasterDto>>
                    {
                        ErrorMessage = countryRes.ErrorMessage,
                    };
                }
                var country = countryRes.Data;

                List<StateMasterDto> result = (from s in states
                              join c in country
                              on s.CountryID equals c.Id                        
                              select new StateMasterDto
                              {
                                  ID = s.ID ?? 0,
                                  stateID = s.stateID,
                                  StateName = s.StateName,
                                  StateCode = s.StateCode,
                                  CountryID = s.CountryID ?? 0,
                                  CountryName = c.CountryName ?? "Unknown",
                                  EDITDATE = s.EDITDATE,
                                  EDITTERMINALID = s.EDITTERMINALID,
                                  EDITUSERID = s.EDITUSERID,
                                  CREATEDATE = s.CREATEDATE,
                                  CREATETERMINALID = s.CREATETERMINALID,
                                  CREATEUSERID = s.CREATEUSERID
                              }).ToList();

                _cache.Set(CacheKeys.StateList, result, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(3),
                    Priority = CacheItemPriority.High
                });

                return new Result<List<StateMasterDto>>
                {

                    Data = result
                };
            }

            catch (Exception ex)
            {
                return new Result<List<StateMasterDto>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }
    }
}
