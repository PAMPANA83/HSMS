using HSMS.Application.IRepositories;
using HSMS.Domain.Domains;
using HSMS.infrastructure.Entities;
using HSMS.infrastructure.Persistence;
using HSMS.shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.infrastructure.Repositories
{
    public class CompanyMastersRepositories : CompanyMastersIRepositories
    {
        private readonly ApplicationDbContext _dbBase;

        public CompanyMastersRepositories(SqlserverConnHelper dbBase)
        {
            _dbBase = dbBase.CreateDbContext();

        }
        public async Task<Result<bool>> CreateCompanyMaster(CompanyMasters companyMaster)
        {
            try
            {
                var obj= new CompanyMaster();
                obj.CompanyID = companyMaster.CompanyID;
                obj.CompanyName = companyMaster.CompanyName;
                obj.CompanyCode = companyMaster.CompanyCode;
                obj.InstallationDate = companyMaster.InstallationDate;
                obj.Address = companyMaster.Address;
                obj.StateID = companyMaster.StateID;
                obj.DistrictID = companyMaster.DistrictID;
                obj.CityID = companyMaster.CityID;
                obj.AreaID = companyMaster.AreaID;
                obj.Mobile1 = companyMaster.Mobile1;
                obj.Mobile2 = companyMaster.Mobile2;
                obj.Phone = companyMaster.Phone;
                obj.ContactPerson = companyMaster.ContactPerson;
                obj.CREATEUSERID = companyMaster.CREATEUSERID;
                obj.CREATEDATE = companyMaster.CREATEDATE;
                obj.CREATETERMINALID = companyMaster.CREATETERMINALID;
                await _dbBase.CompanyMaster.AddAsync(obj);
                var _res = await _dbBase.SaveChangesAsync();
                if (_res > 0)
                {
                    return new Result<bool>
                    {
                        Data = true,
                    };
                }
                else
                {
                    return new Result<bool>
                    {
                        Data = false,
                    };
                }

            }
            catch (Exception ex)
            {
                return new Result<bool>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<bool>> DeleteCompanyMaster(int id)
        {
            try
            {
                var res = await _dbBase.CompanyMaster.FirstOrDefaultAsync(x => x.ID == id);
                if (res != null)
                {
                    _dbBase.CompanyMaster.Remove(res);
                    var result = await _dbBase.SaveChangesAsync();
                    if (result > 0)
                    {
                        return new Result<bool>
                        {
                            Data = true,
                        };
                    }
                    else
                    {
                        return new Result<bool>
                        {
                            Data = false,
                        };
                    }
                }
                else
                {
                    return new Result<bool>
                    {
                        ErrorMessage = "Company Master not found",
                    };
                }
            }
            catch (Exception ex)
            {
                return new Result<bool>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<List<CompanyMasters>>> GetAllCompanyMasters()
        {
            try
            {
                List<CompanyMasters> res = new List<CompanyMasters>();
                var _res = await _dbBase.CompanyMaster.AsNoTracking().ToListAsync();
                if (_res.Count > 0)
                {
                    res = _res.Select(x => new CompanyMasters(x.ID, x.CompanyID, x.CompanyName, x.CompanyCode, x.InstallationDate,
                        x.Address, x.StateID, x.DistrictID, x.CityID, x.AreaID, x.Mobile1, x.Mobile2, x.Phone, x.ContactPerson, x.CREATEUSERID,
                        x.CREATEDATE, x.CREATETERMINALID, x.EDITUSERID, x.EDITDATE, x.EDITTERMINALID)).ToList();
                }
                return new Result<List<CompanyMasters>>
                {
                    Data = res,
                };
            }
            catch (Exception ex)
            {
                return new Result<List<CompanyMasters>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<List<CompanyMasters>>> GetAllCompanyMastersAsync(List<int?> id)
        {
            try
            {
                List<CompanyMasters> res = new List<CompanyMasters>();
                var _res = await _dbBase.CompanyMaster.Where(x=>id.Contains(x.ID)).ToListAsync();
                if (_res.Count > 0)
                {
                    res = _res.Select(x => new CompanyMasters(x.ID, x.CompanyID, x.CompanyName, x.CompanyCode, x.InstallationDate,
                        x.Address, x.StateID, x.DistrictID, x.CityID, x.AreaID, x.Mobile1, x.Mobile2, x.Phone, x.ContactPerson, x.CREATEUSERID,
                        x.CREATEDATE, x.CREATETERMINALID, x.EDITUSERID, x.EDITDATE, x.EDITTERMINALID)).ToList();
                }
                return new Result<List<CompanyMasters>>
                {
                    Data = res,
                };
            }
            catch (Exception ex)
            {
                return new Result<List<CompanyMasters>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<CompanyMasters>> GetCompanyMasterById(int id)
        {
           try
            {
                var res = await _dbBase.CompanyMaster.AsNoTracking().FirstOrDefaultAsync(x => x.ID == id);
                if (res != null)
                {
                    var _res = new CompanyMasters(res.ID, res.CompanyID, res.CompanyName, res.CompanyCode, res.InstallationDate,
                        res.Address, res.StateID, res.DistrictID, res.CityID, res.AreaID, res.Mobile1, res.Mobile2, res.Phone,
                        res.ContactPerson, res.CREATEUSERID, res.CREATEDATE, res.CREATETERMINALID, res.EDITUSERID, res.EDITDATE,
                        res.EDITTERMINALID);
                    return new Result<CompanyMasters>
                    {
                        Data = _res,
                    };
                }
                else
                {
                    return new Result<CompanyMasters>
                    {
                        ErrorMessage = "Company Master not found",
                    };
                }
            }
            catch (Exception ex)
            {
                return new Result<CompanyMasters>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<bool>> UpdateCompanyMaster(CompanyMasters companyMaster)
        {
            try
            {
                var res = await _dbBase.CompanyMaster.FirstOrDefaultAsync(x => x.ID == companyMaster.ID);
                if (res != null)
                {
                    res.CompanyID = companyMaster.CompanyID;
                    res.CompanyName = companyMaster.CompanyName;
                    res.CompanyCode = companyMaster.CompanyCode;
                    res.InstallationDate = companyMaster.InstallationDate;
                    res.Address = companyMaster.Address;
                    res.StateID = companyMaster.StateID;
                    res.DistrictID = companyMaster.DistrictID;
                    res.CityID = companyMaster.CityID;
                    res.AreaID = companyMaster.AreaID;
                    res.Mobile1 = companyMaster.Mobile1;
                    res.Mobile2 = companyMaster.Mobile2;
                    res.Phone = companyMaster.Phone;
                    res.ContactPerson = companyMaster.ContactPerson;
                    res.EDITUSERID = companyMaster.EDITUSERID;
                    res.EDITDATE = companyMaster.EDITDATE;
                    res.EDITTERMINALID = companyMaster.EDITTERMINALID;
                    _dbBase.CompanyMaster.Update(res);
                    var result = await _dbBase.SaveChangesAsync();
                    if (result > 0)
                    {
                        return new Result<bool>
                        {
                            Data = true,
                        };
                    }
                    else
                    {
                        return new Result<bool>
                        {
                            Data = false,
                        };
                    }
                }
                else
                {
                    return new Result<bool>
                    {
                        ErrorMessage = "Company Master not found",
                    };
                }
            }
            catch (Exception ex)
            {
                return new Result<bool>
                {
                    ErrorMessage = ex.Message,
                };

            }
        }
    }
}
