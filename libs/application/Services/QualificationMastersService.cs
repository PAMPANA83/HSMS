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
    public class QualificationMastersService : QualificationMastersIService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        public QualificationMastersService(IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }
        public async Task<Result<string>> CreateQualificationMasterAsync(Qualification dto)
        {
            try
            {
                var _qualification = new QualificationMasters(null, dto.QualificationID, dto.QualificationName,
                   1, DateTimeHelper.Now(), GetIPAddress.GetLocalIpAddress(), null, null, null);

                var res = await _unitOfWork.qualification.CreateQualificationMaster(_qualification);
                if(!res.IsSuccess)
                {
                    return new Result<string>
                    {
                        ErrorMessage = res.ErrorMessage
                    };
                }
                _cache.Remove(CacheKeys.QualificationList);
                return new Result<string>
                {
                    Data= "Qualification Create successfully"
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

        public async Task<Result<string>> DeleteQualificationMasterAsync(int Id)
        {
            try
            {
                var _qualification = await _unitOfWork.qualification.DeleteQualificationMaster(Id);
                if(!_qualification.IsSuccess)
                {
                    return new Result<string>
                    {
                        ErrorMessage = _qualification.ErrorMessage,
                    };
                }
                _cache.Remove(CacheKeys.QualificationList);

                return new Result<string>
                {
                    Data= "Qualification Delete successfully"
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

        public async Task<Result<List<QualificationMastersDto>>> GetQualificationMasterAsync()
        {
            try
            {
                if(_cache.TryGetValue(CacheKeys.QualificationList, out List<QualificationMastersDto> data))
                {
                    return new Result<List<QualificationMastersDto>>
                    {
                        Data = data
                    };
                }

                var _res = await _unitOfWork.qualification.GetAllQualificationMasters();
                if(!_res.IsSuccess)
                {
                    return new Result<List<QualificationMastersDto>>
                    {
                        ErrorMessage = _res.ErrorMessage,
                    };
                }

                var result=new List<QualificationMastersDto>();
                if(_res.Data?.Count>0)
                {
                    result=_mapper.Map<List<QualificationMastersDto>>(_res.Data);
                }
                _cache.Set(CacheKeys.QualificationList, result, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(3),
                    Priority = CacheItemPriority.High
                });

                return new Result<List<QualificationMastersDto>>
                {
                    Data = result
                };

            }
            catch (Exception ex)
            {
                return new Result<List<QualificationMastersDto>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }
    }
}
