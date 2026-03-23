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
    public class DepartmentServices : DepartmentIServices
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        public DepartmentServices(IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }
        public async Task<Result<string>> CreateDepartmentAsync(Departmentdto dto)
        {
            try
            {
                var _res = new DepartmentMasters(null, dto.DeptID, dto.MainDeptID,dto.DepartmentName,dto.DepartmentType,dto.Shortname,
                    dto.Incharge,dto.BranchID,
                    1, DateTimeHelper.Now(),
                      GetIPAddress.GetLocalIpAddress(), null, null, null);

                var res = await _unitOfWork.department.AddDepartmentMasters(_res);
                if (!res.IsSuccess)
                {
                    return new Result<string>
                    {
                        ErrorMessage = res.ErrorMessage,
                    };
                }

                _cache.Remove(CacheKeys.MainDepartList);

                return new Result<string>
                {
                    Data = "Main Department Create successfully"
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

        public async Task<Result<string>> DeleteDepartmentAsync(int id)
        {
            try
            {
                var desg = await _unitOfWork.department.DeleteDepartmentMasters(id);
                if (!desg.IsSuccess)
                {
                    return new Result<string>
                    {
                        ErrorMessage = desg.ErrorMessage,
                    };
                }
                _cache.Remove(CacheKeys.DepartmentList);

                return new Result<string>
                {
                    Data = "Designation Delete successfully"
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

        public async Task<Result<List<DepartmentMastersDto>>> GetDepartmentsAsync()
        {
            try
            {
                if (_cache.TryGetValue(CacheKeys.DepartmentList, out List<DepartmentMastersDto> _desig))
                {
                    return new Result<List<DepartmentMastersDto>>
                    {
                        Data = _desig
                    };
                }
                List<DepartmentMastersDto> result=new List<DepartmentMastersDto>();

                _cache.Set(CacheKeys.DepartmentList, result, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(3),
                    Priority = CacheItemPriority.High
                });

                return new Result<List<DepartmentMastersDto>>
                {
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new Result<List<DepartmentMastersDto>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<List<DepartmentMastersDto>>> GetDepartmentsByBranchIdAsync(int id)
        {
            try
            {
                if (_cache.TryGetValue(CacheKeys.DepartmentList, out List<DepartmentMastersDto> _desig))
                {
                    return new Result<List<DepartmentMastersDto>>
                    {
                        Data = _desig?.Where(x => x.MainDeptID == id).ToList()
                    };
                }
                List<DepartmentMastersDto> result = new List<DepartmentMastersDto>();
                return new Result<List<DepartmentMastersDto>>
                {
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new Result<List<DepartmentMastersDto>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }
    }
}
