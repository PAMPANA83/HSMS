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
    public class AreaMasterService : AreaMasterIService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        public AreaMasterService(IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }
        public async Task<Result<string>> CreateAreaMastersAsync(AreaDto dto)
        {
            try
            {
               var res=new AreaMasters(null,dto.AreaID, dto.AreaName,dto.AreaPINCode,dto.CityID,1,
                   DateTimeHelper.Now(), GetIPAddress.GetLocalIpAddress(), null, null, null,true);

                var _area=await _unitOfWork.area.AddAreaMaster(res);
                if(!_area.IsSuccess)
                {
                    return new Result<string>
                    {
                        ErrorMessage = _area.ErrorMessage,
                    };
                }
                _cache.Remove(CacheKeys.AreaList);
                return new Result<string>
                {
                    Data= "Area Create successfully"
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

        public async Task<Result<string>> DeleteAreaMasterAsync(int id)
        {
            try
            {
                var res=await _unitOfWork.area.DeleteAreaMaster(id);
                if (!res.IsSuccess)
                {
                    return new Result<string>
                    {
                        ErrorMessage = res.ErrorMessage,
                    };
                }

                _cache.Remove(CacheKeys.AreaList);
                return new Result<string>
                {
                    Data= "Area Delete successfully"
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

        public async Task<Result<List<AreaMastersDto>>> GetAllAreaMasterAsync()
        {
            try
            {
                if(_cache.TryGetValue(CacheKeys.AreaList,out List<AreaMastersDto> _res))
                {
                    return new Result<List<AreaMastersDto>>
                    {
                        Data = _res
                    };
                }

                var _area = await _unitOfWork.area.GetAllAreaMasters();
                if(!_area.IsSuccess)
                {
                    return new Result<List<AreaMastersDto>>
                    {
                        ErrorMessage = _area.ErrorMessage,
                    };
                }

             

                var rescity = await _unitOfWork.city.GetAllCityMasters();
                if(!rescity.IsSuccess)
                {
                    return new Result<List<AreaMastersDto>>
                    { ErrorMessage = rescity.ErrorMessage, };
                }

                List<AreaMastersDto> result=(from a in _area.Data
                                             join c in rescity.Data on a.CityID equals c.ID
                                             select new AreaMastersDto
                                             {
                                                 ID = a.ID,
                                                 Active = a.Active,
                                                 AreaID = a.AreaID,
                                                 AreaName = a.AreaName,
                                                 AreaPINCode = a.AreaPINCode,
                                                 CityID = a.CityID,
                                                 CityName=c.CityName,
                                                 CREATEDATE=a.CREATEDATE,
                                                 CREATETERMINALID=a.CREATETERMINALID,
                                                 CREATEUSERID=a.CREATEUSERID,
                                                 EDITDATE=a.EDITDATE,
                                                 EDITTERMINALID=a.EDITTERMINALID,
                                                 EDITUSERID=a.EDITUSERID,
                                             }).ToList();

                _cache.Set(CacheKeys.AreaList, result, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(3),
                    Priority = CacheItemPriority.High
                });
                return new Result<List<AreaMastersDto>>
                {
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new Result<List<AreaMastersDto>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<List<AreaMastersDto>>> GetAreaMasterByIdAsync(int id)
        {
            try
            {
                if (_cache.TryGetValue(CacheKeys.AreaList, out List<AreaMastersDto> _res))
                {
                    return new Result<List<AreaMastersDto>>
                    {
                        Data = _res?.Where(x=>x.CityID==id).ToList()
                    };
                }

                var _area = await _unitOfWork.area.GetAllAreaMasters();
                if (!_area.IsSuccess)
                {
                    return new Result<List<AreaMastersDto>>
                    {
                        ErrorMessage = _area.ErrorMessage,
                    };
                }



                var rescity = await _unitOfWork.city.GetAllCityMasters();
                if (!rescity.IsSuccess)
                {
                    return new Result<List<AreaMastersDto>>
                    { ErrorMessage = rescity.ErrorMessage, };
                }

                List<AreaMastersDto> result = (from a in _area.Data
                                               join c in rescity.Data on a.CityID equals c.ID
                                               where a.CityID== id  
                                               select new AreaMastersDto
                                               {
                                                   ID = a.ID,
                                                   Active = a.Active,
                                                   AreaID = a.AreaID,
                                                   AreaName = a.AreaName,
                                                   AreaPINCode = a.AreaPINCode,
                                                   CityID = a.CityID,
                                                   CityName = c.CityName,
                                                   CREATEDATE = a.CREATEDATE,
                                                   CREATETERMINALID = a.CREATETERMINALID,
                                                   CREATEUSERID = a.CREATEUSERID,
                                                   EDITDATE = a.EDITDATE,
                                                   EDITTERMINALID = a.EDITTERMINALID,
                                                   EDITUSERID = a.EDITUSERID,
                                               }).ToList();

                return new Result<List<AreaMastersDto>>
                {
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new Result<List<AreaMastersDto>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }
    }
}
