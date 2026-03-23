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
    public class DesignationsService : DesignationsIService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        public DesignationsService(IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }
        public async Task<Result<string>> CreateDesignationAsync(DesigDto dto)
        {
            try
            {
                var res = new Designations(null, dto.DesigID, dto.DesignationName, dto.BranchID, 1, DateTimeHelper.Now(), GetIPAddress.GetLocalIpAddress(), null, null, null);
                var _res = await _unitOfWork.designations.CreateDesignation(res);
                if (!_res.IsSuccess)
                {
                    return new Result<string>
                    {
                        ErrorMessage = _res.ErrorMessage,
                    };
                }
                _cache.Remove(CacheKeys.DesignationList);

                return new Result<string>
                {
                    Data = "Designation Create successfully"
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

        public async Task<Result<string>> DeleteDesignationAsync(int id)
        {
            try
            {
                var desg = await _unitOfWork.designations.DeleteDesignation(id);
                if(!desg.IsSuccess)
                {
                    return new Result<string>
                    {
                        ErrorMessage = desg.ErrorMessage,
                    };
                }
                _cache.Remove(CacheKeys.DesignationList);

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

        public async Task<Result<List<DesignationsDto>>> GetDesignationsAsync()
        {
            try
            {
                if(_cache.TryGetValue(CacheKeys.DesignationList,out List<DesignationsDto> _desig))
                {
                    return new Result<List<DesignationsDto>>
                    {
                        Data = _desig
                    };
                }

                var _designation = await _unitOfWork.designations.GetAllDesignations();
                if(!_designation.IsSuccess)
                {
                    return new Result<List<DesignationsDto>>
                    {
                        ErrorMessage = _designation.ErrorMessage,
                    };
                }

                var _branch=_designation.Data?.Select(x=>x.BranchID).ToList();

                var branch = await _unitOfWork.branch.GetAllBranchMastersAsync(_branch);
                if (!branch.IsSuccess)
                {
                    return new Result<List<DesignationsDto>>
                    {
                        ErrorMessage = _designation.ErrorMessage,
                    };
                }

                var result = new List<DesignationsDto>();

                result = (from d in _designation.Data
                          join b in branch.Data on d.BranchID equals b.ID
                          select new DesignationsDto
                          {
                              ID=d.ID,
                              DesigID=d.DesigID,
                              DesignationName=d.DesignationName,
                              BranchID=d.BranchID,
                              BranchName=b.BranchName,
                              CREATEDATE=d.CREATEDATE,
                              CREATETERMINALID=d.CREATETERMINALID,
                              CREATEUSERID=d.CREATEUSERID,
                              EDITDATE=d.EDITDATE,
                              EDITTERMINALID=d.EDITTERMINALID,
                              EDITUSERID=d.EDITUSERID,
                          }

                        ).ToList();


                _cache.Set(CacheKeys.DesignationList, result, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(3),
                    Priority = CacheItemPriority.High
                });


                return new Result<List<DesignationsDto>>
                {
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new Result<List<DesignationsDto>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<List<DesignationsDto>>> GetDesignationsByBranchIdAsync(int Id)
        {
            try
            {
                if (_cache.TryGetValue(CacheKeys.DesignationList, out List<DesignationsDto> _desig))
                {
                    return new Result<List<DesignationsDto>>
                    {
                        Data = _desig?.Where(x=>x.BranchID==Id).ToList()
                    };
                }

                var _designation = await _unitOfWork.designations.GetAllDesignations();
                if (!_designation.IsSuccess)
                {
                    return new Result<List<DesignationsDto>>
                    {
                        ErrorMessage = _designation.ErrorMessage,
                    };
                }

                var _branch = _designation.Data?.Select(x => x.BranchID).ToList();

                var branch = await _unitOfWork.branch.GetAllBranchMastersAsync(_branch);
                if (!branch.IsSuccess)
                {
                    return new Result<List<DesignationsDto>>
                    {
                        ErrorMessage = _designation.ErrorMessage,
                    };
                }

                var result = new List<DesignationsDto>();

                result = (from d in _designation.Data
                          join b in branch.Data on d.BranchID equals b.ID
                          where d.BranchID== Id
                          select new DesignationsDto
                          {
                              ID = d.ID,
                              DesigID = d.DesigID,
                              DesignationName = d.DesignationName,
                              BranchID = d.BranchID,
                              BranchName = b.BranchName,
                              CREATEDATE = d.CREATEDATE,
                              CREATETERMINALID = d.CREATETERMINALID,
                              CREATEUSERID = d.CREATEUSERID,
                              EDITDATE = d.EDITDATE,
                              EDITTERMINALID = d.EDITTERMINALID,
                              EDITUSERID = d.EDITUSERID,
                          }

                        ).ToList();


                return new Result<List<DesignationsDto>>
                {
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new Result<List<DesignationsDto>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }
    }
}
