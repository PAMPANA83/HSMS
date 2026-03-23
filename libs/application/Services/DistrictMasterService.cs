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
    public class DistrictMasterService : DistrictMasterIService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        public DistrictMasterService(IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Result<string>> CreateDistrictMasterAysnc(Districtdto obj)
        {
            
            try
            {
                var _dist = new DistrictMasters(null, obj.DistrictID, obj.DistrictName, obj.StateID, 1,
                    DateTimeHelper.Now(), GetIPAddress.GetLocalIpAddress(), null, null, null);
                var res = await _unitOfWork.district.CreateDistrictMasterAsync(_dist);
                if(!res.IsSuccess)
                {
                    return new Result<string>
                    {
                        ErrorMessage = res.ErrorMessage,
                    };
                }
                _cache.Remove(CacheKeys.DistrictList);
                return new Result<string>
                {
                    Data = "District created successfully"
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

        public async Task<Result<string>> DeleteDistrictMasterAsync(int id)
        {
            try
            {
                var res = await _unitOfWork.district.DeleteDistrictMasterAsync(id);
                if (!res.IsSuccess)
                {
                    return new Result<string>
                    {
                        ErrorMessage = res.ErrorMessage,
                    };
                }
                _cache.Remove(CacheKeys.DistrictList);
                return new Result<string>
                {
                    Data = "District deleted successfully"
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

        public async Task<Result<List<DistrictMasterdto>>> GetAllDistrictMastersAysnc()
        {

            try
            {
                 if(_cache.TryGetValue(CacheKeys.DistrictList,out List<DistrictMasterdto> list))
                {
                    return new Result<List<DistrictMasterdto>>
                    {
                        Data = list
                    };
                }

                var _dist=await _unitOfWork.district.GetAllDistrictMasterAsync();
                if( !_dist.IsSuccess )
                {
                    return new Result<List<DistrictMasterdto>>
                    {
                        ErrorMessage = _dist.ErrorMessage
                    };
                }

       

                var _stateres = await _unitOfWork.state.GetAllStateMasterAsync();
                if(!_stateres.IsSuccess)
                {
                    return new Result<List<DistrictMasterdto>>
                    {
                        ErrorMessage = _stateres.ErrorMessage
                    };
                }

                List<DistrictMasterdto> res = (from x in _dist.Data
                                               join s in _stateres.Data on x.StateID equals s.ID
                                               select new DistrictMasterdto
                                               {
                                                   ID= x.ID,
                                                   DistrictID= x.DistrictID,
                                                   DistrictName= x.DistrictName,
                                                   StateID= x.StateID,
                                                   StateName=s.StateName,
                                                   CREATEDATE=x.CREATEDATE,
                                                   CREATETERMINALID= x.CREATETERMINALID,
                                                   CREATEUSERID= x.CREATEUSERID,
                                                   EDITDATE= x.EDITDATE,
                                                   EDITTERMINALID= x.EDITTERMINALID,
                                                   EDITUSERID= x.EDITUSERID,
                                               }
                                             ).ToList();

                _cache.Set(CacheKeys.DistrictList, res, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(3),
                    Priority = CacheItemPriority.High
                });

                return new Result<List<DistrictMasterdto>>
                {
                    Data = res,
                };


            }
            catch (Exception ex)
            {
                return new Result<List<DistrictMasterdto>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<List<DistrictMasterdto>>> GetAllDistrictMastersbyIDAysnc(int id)
        {
            try
            {
                if (_cache.TryGetValue(CacheKeys.DistrictList, out List<DistrictMasterdto> list))
                {
                    return new Result<List<DistrictMasterdto>>
                    {
                        Data = list?.Where(x => x.StateID == id).ToList()
                    };
                }
                var _dist = await _unitOfWork.district.GetAllDistrictMasterAsync();
                if (!_dist.IsSuccess)
                {
                    return new Result<List<DistrictMasterdto>>
                    {
                        ErrorMessage = _dist.ErrorMessage
                    };
                }



                var _stateres = await _unitOfWork.state.GetAllStateMasterAsync();
                if (!_stateres.IsSuccess)
                {
                    return new Result<List<DistrictMasterdto>>
                    {
                        ErrorMessage = _stateres.ErrorMessage
                    };
                }

                List<DistrictMasterdto> res = (from x in _dist.Data
                                               join s in _stateres.Data on x.StateID equals s.ID
                                               where x.StateID == id
                                               select new DistrictMasterdto
                                               {
                                                   ID = x.ID,
                                                   DistrictID = x.DistrictID,
                                                   DistrictName = x.DistrictName,
                                                   StateID = x.StateID,
                                                   StateName = s.StateName,
                                                   CREATEDATE = x.CREATEDATE,
                                                   CREATETERMINALID = x.CREATETERMINALID,
                                                   CREATEUSERID = x.CREATEUSERID,
                                                   EDITDATE = x.EDITDATE,
                                                   EDITTERMINALID = x.EDITTERMINALID,
                                                   EDITUSERID = x.EDITUSERID,
                                               }
                                             ).ToList();

                return new Result<List<DistrictMasterdto>>
                {
                    Data = res,
                };
            }
            catch (Exception ex)
            {
                return new Result<List<DistrictMasterdto>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }
    }
}
