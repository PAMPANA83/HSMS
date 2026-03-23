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
    public class MainDepartmentService : MainDepartmentIService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        public MainDepartmentService(IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }
        public async Task<Result<string>> CreateMainDepartmentAsync(MainDepartmentdto dto)
        {
            try
            {
                var _res = new MainDepartmentMasters(null, dto.MainDeptID, dto.MainDepartmentName,
                    1, DateTimeHelper.Now(),
                      GetIPAddress.GetLocalIpAddress(), null, null, null);

                var res=await _unitOfWork.mainDepartment.CreateMainDepartmentMaster(_res);
                if (!res.IsSuccess)
                {
                    return new Result<string>
                    {
                        ErrorMessage=res.ErrorMessage,
                    };
                }

                _cache.Remove(CacheKeys.MainDepartList);

                return new Result<string>
                {
                    Data= "Main Department Create successfully"
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

        public async Task<Result<string>> DeleteMainDepartmentAsync(int id)
        {
            try
            {
                var _res = await _unitOfWork.mainDepartment.DeleteMainDepartmentMaster(id);
                if(!_res.IsSuccess)
                {
                    return new Result<string>
                    {
                        ErrorMessage = _res.ErrorMessage,
                    };
                }
                _cache.Remove(CacheKeys.MainDepartList);

                return new Result<string>
                {
                    Data= "MainDepartment Delete successfully"
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

        public async Task<Result<List<MainDepartmentMastersDto>>> GetAllMainDepartmentAysnc()
        {
            try
            {
                if(_cache.TryGetValue(CacheKeys.MainDepartList, out List<MainDepartmentMastersDto> departdto))
                {
                    return new Result<List<MainDepartmentMastersDto>>
                    {
                        Data = departdto,
                    };
                }

                var maindepart=await _unitOfWork.mainDepartment.GetAllMainDepartmentMasters();
                if (!maindepart.IsSuccess)
                {
                    return new Result<List<MainDepartmentMastersDto>>
                    {
                        ErrorMessage = maindepart.ErrorMessage,
                    };
                }

                var result = new List<MainDepartmentMastersDto>();
                if (maindepart.Data != null)
                {
                    result=_mapper.Map<List<MainDepartmentMastersDto>>(maindepart.Data);
                }
                return new Result<List<MainDepartmentMastersDto>>
                {
                    Data = result
                };

            }
            catch (Exception ex)
            {
                return new Result<List<MainDepartmentMastersDto>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }
    }
}
