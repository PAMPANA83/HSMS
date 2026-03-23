using AutoMapper;
using HSMS.Application.IServices;
using HSMS.Application.UoW;
using HSMS.contracts.Dto;
using HSMS.shared.Helpers;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Application.Services
{
    public class BranchMasterService : BranchMasterIService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        public BranchMasterService(IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }
        public async Task<Result<string>> CreateBranchMasterAsync(BranchDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<string>> DeleteBranchMaster(int id)
        {

            try
            {
                var _res = await _unitOfWork.branch.DeleteBranchMasters(id);
                if(!_res.IsSuccess)
                {
                    return new Result<string>
                    {
                        ErrorMessage = _res.ErrorMessage,
                    };
                }
                _cache.Remove(CacheKeys.BranchList);
                return new Result<string>
                {
                    Data= "Branch delete successfully"
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

        public async Task<Result<List<BranchMastersdto>>> GetAllBranchMasterAync()
        {
            try
            {
                if(_cache.TryGetValue(CacheKeys.BranchList,out List<BranchMastersdto> _branch))
                {
                    return new Result<List<BranchMastersdto>>
                    {
                        Data = _branch
                    };
                }

                var branch=await _unitOfWork.branch.GetAllBranchMasters();
                if(!branch.IsSuccess)
                {
                    return new Result<List<BranchMastersdto>>
                    {
                        ErrorMessage = branch.ErrorMessage
                    };
                }

           

                var states = await _unitOfWork.state.GetAllStateMasterAsync();
                if(!states.IsSuccess)
                {
                    return new Result<List<BranchMastersdto>>
                    {
                        ErrorMessage = states.ErrorMessage
                    };
                }

                var district=await _unitOfWork.district.GetAllDistrictMasterAsync();
                if (!district.IsSuccess)
                {
                    return new Result<List<BranchMastersdto>>
                    {
                        ErrorMessage = district.ErrorMessage
                    };
                }

                var citys=await _unitOfWork.city.GetAllCityMasters();
                if (!citys.IsSuccess)
                {
                    return new Result<List<BranchMastersdto>>
                    {
                        ErrorMessage = citys.ErrorMessage
                    };
                }

                var areas = await _unitOfWork.area.GetAllAreaMasters();
                if (!areas.IsSuccess)
                {
                    return new Result<List<BranchMastersdto>>
                    {
                        ErrorMessage = areas.ErrorMessage
                    };
                }

                var company = await _unitOfWork.company.GetAllCompanyMasters();
                if (!company.IsSuccess)
                {
                    return new Result<List<BranchMastersdto>> { ErrorMessage = company.ErrorMessage };
                }


                List < BranchMastersdto > result=(from b in branch.Data 
                                                  join c in company.Data on b.CompanyID equals c.ID
                                                  join s in states.Data on  b.StateID equals s.ID
                                                  join d in district.Data on b.DistrictID equals d.ID 
                                                  join ci in citys.Data on b.CityID equals ci.ID
                                                  join a in areas.Data on b.AreaID equals a.ID
                                                  select new BranchMastersdto
                                                  {
                                                      ID = b.ID,
                                                      BranchHeader = b.BranchHeader,
                                                      BranchID = b.BranchID,
                                                      BranchName = b.BranchName,
                                                      LABHeader = b.LABHeader,
                                                      Address = b.Address,
                                                      AreaID = b.AreaID,
                                                      CompanyID = b.CompanyID,
                                                      CompanyName=c.CompanyName,
                                                      StateID = b.StateID,
                                                      StateName=s.StateName,
                                                      DistrictID = b.DistrictID,
                                                      DistrictName=d.DistrictName,
                                                      CityID = b.CityID,
                                                      CityName=ci.CityName,
                                                      AreaName=a.AreaName,
                                                      ContactPerson=b.ContactPerson,
                                                      CREATEDATE=b.CREATEDATE,
                                                      CREATETERMINALID=b.CREATETERMINALID,
                                                      CREATEUSERID=b.CREATEUSERID,
                                                      EDITDATE=b.EDITDATE,
                                                      EDITTERMINALID=b.EDITTERMINALID,
                                                      EDITUSERID=b.EDITUSERID,
                                                      Mobile1=b.Mobile1,
                                                      Mobile2 = b.Mobile2,
                                                      Phone=b.Phone,
                                                      RegisterName=b.RegisterName,
                                                  }
                                                  ).ToList();

                _cache.Set(CacheKeys.BranchList, result, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(3),
                    Priority = CacheItemPriority.High
                });



                return new Result<List<BranchMastersdto>>
                {
                    Data = result
                };

            }
            catch (Exception ex)
            {
                return new Result<List<BranchMastersdto>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<List<BranchMastersdto>>> GetAllBranchMasterByIdAync(int Id)
        {
            try
            {
                if (_cache.TryGetValue(CacheKeys.BranchList, out List<BranchMastersdto> _branch))
                {
                    return new Result<List<BranchMastersdto>>
                    {
                        Data = _branch?.Where(x=>x.AreaID==Id).ToList()
                    };
                }

                var branch = await _unitOfWork.branch.GetAllBranchMasters();
                if (!branch.IsSuccess)
                {
                    return new Result<List<BranchMastersdto>>
                    {
                        ErrorMessage = branch.ErrorMessage
                    };
                }



                var states = await _unitOfWork.state.GetAllStateMasterAsync();
                if (!states.IsSuccess)
                {
                    return new Result<List<BranchMastersdto>>
                    {
                        ErrorMessage = states.ErrorMessage
                    };
                }

                var district = await _unitOfWork.district.GetAllDistrictMasterAsync();
                if (!district.IsSuccess)
                {
                    return new Result<List<BranchMastersdto>>
                    {
                        ErrorMessage = district.ErrorMessage
                    };
                }

                var citys = await _unitOfWork.city.GetAllCityMasters();
                if (!citys.IsSuccess)
                {
                    return new Result<List<BranchMastersdto>>
                    {
                        ErrorMessage = citys.ErrorMessage
                    };
                }

                var areas = await _unitOfWork.area.GetAllAreaMasters();
                if (!areas.IsSuccess)
                {
                    return new Result<List<BranchMastersdto>>
                    {
                        ErrorMessage = areas.ErrorMessage
                    };
                }

                var company = await _unitOfWork.company.GetAllCompanyMasters();
                if (!company.IsSuccess)
                {
                    return new Result<List<BranchMastersdto>> { ErrorMessage = company.ErrorMessage };
                }


                List<BranchMastersdto> result = (from b in branch.Data
                                                 join c in company.Data on b.CompanyID equals c.ID
                                                 join s in states.Data on b.StateID equals s.ID
                                                 join d in district.Data on b.DistrictID equals d.ID
                                                 join ci in citys.Data on b.CityID equals ci.ID
                                                 join a in areas.Data on b.AreaID equals a.ID
                                                 where b.AreaID == Id
                                                 select new BranchMastersdto
                                                 {
                                                     ID = b.ID,
                                                     BranchHeader = b.BranchHeader,
                                                     BranchID = b.BranchID,
                                                     BranchName = b.BranchName,
                                                     LABHeader = b.LABHeader,
                                                     Address = b.Address,
                                                     AreaID = b.AreaID,
                                                     CompanyID = b.CompanyID,
                                                     CompanyName = c.CompanyName,
                                                     StateID = b.StateID,
                                                     StateName = s.StateName,
                                                     DistrictID = b.DistrictID,
                                                     DistrictName = d.DistrictName,
                                                     CityID = b.CityID,
                                                     CityName = ci.CityName,
                                                     AreaName = a.AreaName,
                                                     ContactPerson = b.ContactPerson,
                                                     CREATEDATE = b.CREATEDATE,
                                                     CREATETERMINALID = b.CREATETERMINALID,
                                                     CREATEUSERID = b.CREATEUSERID,
                                                     EDITDATE = b.EDITDATE,
                                                     EDITTERMINALID = b.EDITTERMINALID,
                                                     EDITUSERID = b.EDITUSERID,
                                                     Mobile1 = b.Mobile1,
                                                     Mobile2 = b.Mobile2,
                                                     Phone = b.Phone,
                                                     RegisterName = b.RegisterName,
                                                 }
                                                  ).ToList();    

                return new Result<List<BranchMastersdto>>
                {
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new Result<List<BranchMastersdto>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }
    }
}
