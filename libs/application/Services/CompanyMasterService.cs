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
    public class CompanyMasterService : CompanyMasterIService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        public CompanyMasterService(IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }
        public Task<Result<string>> CreateCompanyMasterAysnc(CompanyDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<string>> DeleteCompnayMasterAsync(int id)
        {
            try
            {
              var res=await _unitOfWork.company.DeleteCompanyMaster(id);
                if(!res.IsSuccess)
                {
                    return new Result<string>
                    {
                        ErrorMessage = res.ErrorMessage
                    };
                }
                _cache.Remove(CacheKeys.CompanyList);
                return new Result<string>
                {
                    Data = "Company delete successfully"
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

        public async Task<Result<List<CompanyMastersDto>>> GetAllCompnayMasterAsync()
        {
            try
            {
                if(_cache.TryGetValue(CacheKeys.CompanyList, out List<CompanyMastersDto> company))
                {
                    return new Result<List<CompanyMastersDto>>
                    {
                        Data = company
                    };
                }

                var _com = await _unitOfWork.company.GetAllCompanyMasters();
                if(!_com.IsSuccess)
                {
                    return new Result<List<CompanyMastersDto>>
                    {
                        ErrorMessage = _com.ErrorMessage
                    };
                }

                var _state=_com.Data?.Select(x=>x.StateID).ToList();
                var _dist=_com.Data?.Select(x=>x.DistrictID).ToList();
                var _city=_com.Data?.Select(x=>x.CityID).ToList();
                var _Area=_com.Data?.Select(x=>x.AreaID).ToList();

                var states = await _unitOfWork.state.GetAllStateMasteByIDrAsync(_state);
                if(!states.IsSuccess)
                {
                    return new Result<List<CompanyMastersDto>>
                    {
                        ErrorMessage = _com.ErrorMessage
                    };
                }

                var dist=await _unitOfWork.district.GetAllDistrictMastersAsync(_dist);
                if (!dist.IsSuccess)
                {
                    return new Result<List<CompanyMastersDto>>
                    {
                        ErrorMessage = _com.ErrorMessage
                    };
                }

                var city = await _unitOfWork.city.GetAllCityMastersAsync(_city);
                if (!city.IsSuccess)
                {
                    return new Result<List<CompanyMastersDto>>
                    {
                        ErrorMessage = _com.ErrorMessage
                    };
                }

                




                return new Result<List<CompanyMastersDto>>
                {
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new Result<List<CompanyMastersDto>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }
    }
}
