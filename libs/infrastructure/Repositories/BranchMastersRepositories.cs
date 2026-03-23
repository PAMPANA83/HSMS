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
    public class BranchMastersRepositories : BranchMastersIRepositories
    {
        private readonly ApplicationDbContext _dbBase;

        public BranchMastersRepositories(SqlserverConnHelper dbBase)
        {
            _dbBase = dbBase.CreateDbContext();

        }

        public async Task<Result<bool>> AddBranchMasters(BranchMasters branchMasters)
        {
            try
            {
                var obj=new BranchMaster();
                obj.BranchID = branchMasters.BranchID;
                obj.BranchName = branchMasters.BranchName;
                obj.BranchHeader = branchMasters.BranchHeader;
                obj.RegisterName = branchMasters.RegisterName;
                obj.LABHeader = branchMasters.LABHeader;
                obj.CompanyID = branchMasters.CompanyID;
                obj.Address = branchMasters.Address;
                obj.StateID = branchMasters.StateID;
                obj.DistrictID = branchMasters.DistrictID;
                obj.CityID = branchMasters.CityID;
                obj.AreaID = branchMasters.AreaID;
                obj.Mobile1 = branchMasters.Mobile1;
                obj.Mobile2 = branchMasters.Mobile2;
                obj.Phone = branchMasters.Phone;
                obj.ContactPerson = branchMasters.ContactPerson;
                obj.CREATEUSERID = branchMasters.CREATEUSERID;
                obj.CREATEDATE = branchMasters.CREATEDATE;
                obj.CREATETERMINALID = branchMasters.CREATETERMINALID;

                await _dbBase.BranchMaster.AddAsync(obj);
                var res = await _dbBase.SaveChangesAsync();
                if (res > 0)
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
                        ErrorMessage = "Failed to add BranchMasters.",
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

        public async Task<Result<bool>> DeleteBranchMasters(int id)
        {
            try
            {
                var obj = await _dbBase.BranchMaster.FindAsync(id);
                if (obj != null)
                {
                    _dbBase.BranchMaster.Remove(obj);
                    var res = await _dbBase.SaveChangesAsync();
                    if (res > 0)
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
                            ErrorMessage = "Failed to delete BranchMasters.",
                        };
                    }
                }
                else
                {
                    return new Result<bool>
                    {
                        Data = false,
                        ErrorMessage = "BranchMasters not found.",
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

        public async Task<Result<List<BranchMasters>>> GetAllBranchMasters()
        {
            try
            {
                List<BranchMasters> lists = new List<BranchMasters>();
                var res = await _dbBase.BranchMaster.AsNoTracking().ToListAsync();
                if(res != null && res.Count > 0)
                {
                  lists=res.Select(x=> new BranchMasters(x.ID,x.BranchID,x.BranchName,x.BranchHeader,x.RegisterName,
                      x.LABHeader,x.CompanyID,x.Address,x.StateID,x.DistrictID,x.CityID,x.AreaID,x.Mobile1,x.Mobile2,x.Phone,
                      x.ContactPerson,x.CREATEUSERID,x.CREATEDATE,x.CREATETERMINALID,x.EDITUSERID,x.EDITDATE,
                      x.EDITTERMINALID)).ToList();
                }            

                return new Result<List<BranchMasters>>
                {
                    Data = lists,
                };

            }
            catch (Exception ex)
            {
                return new Result<List<BranchMasters>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<List<BranchMasters>>> GetAllBranchMastersAsync(List<int?> id)
        {
            try
            {
                List<BranchMasters> lists = new List<BranchMasters>();
                var res = await _dbBase.BranchMaster.Where(x=>id.Contains(x.ID)).ToListAsync();
                if (res != null && res.Count > 0)
                {
                    lists = res.Select(x => new BranchMasters(x.ID, x.BranchID, x.BranchName, x.BranchHeader, x.RegisterName,
                        x.LABHeader, x.CompanyID, x.Address, x.StateID, x.DistrictID, x.CityID, x.AreaID, x.Mobile1, x.Mobile2, x.Phone,
                        x.ContactPerson, x.CREATEUSERID, x.CREATEDATE, x.CREATETERMINALID, x.EDITUSERID, x.EDITDATE,
                        x.EDITTERMINALID)).ToList();
                }

                return new Result<List<BranchMasters>>
                {
                    Data = lists,
                };

            }
            catch (Exception ex)
            {
                return new Result<List<BranchMasters>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<BranchMasters>> GetBranchMastersById(int id)
        {
            try
            {
                var _res = await _dbBase.BranchMaster.AsNoTracking().FirstOrDefaultAsync(x => x.ID == id);
                if(_res == null)
                {
                    return new Result<BranchMasters>
                    {
                        Data = null,
                        ErrorMessage = "BranchMasters not found.",
                    };
                }
                var result = new BranchMasters(_res.ID, _res.BranchID, _res.BranchName, _res.BranchHeader, _res.RegisterName,
                    _res.LABHeader, _res.CompanyID, _res.Address, _res.StateID, _res.DistrictID, _res.CityID, _res.AreaID,
                    _res.Mobile1, _res.Mobile2, _res.Phone, _res.ContactPerson, _res.CREATEUSERID, _res.CREATEDATE,
                    _res.CREATETERMINALID, _res.EDITUSERID, _res.EDITDATE, _res.EDITTERMINALID);

                return new Result<BranchMasters>
                {
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new Result<BranchMasters>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<bool>> UpdateBranchMasters(BranchMasters branchMasters)
        {
            try
            {
                var _res = await _dbBase.BranchMaster.FindAsync(branchMasters.ID);
                if (_res == null)
                {
                    return new Result<bool>
                    {
                        Data = false,
                        ErrorMessage = "BranchMasters not found.",
                    };
                }
                _res.BranchID = branchMasters.BranchID;
                _res.BranchName = branchMasters.BranchName;
                _res.BranchHeader = branchMasters.BranchHeader;
                _res.RegisterName = branchMasters.RegisterName; 
                _res.LABHeader = branchMasters.LABHeader;
                _res.CompanyID = branchMasters.CompanyID;
                _res.Address = branchMasters.Address;
                _res.StateID = branchMasters.StateID;
                _res.DistrictID = branchMasters.DistrictID;
                _res.CityID = branchMasters.CityID;
                _res.AreaID = branchMasters.AreaID;
                _res.Mobile1 = branchMasters.Mobile1;
                _res.Mobile2 = branchMasters.Mobile2;
                _res.Phone = branchMasters.Phone;
                _res.ContactPerson = branchMasters.ContactPerson;
                _res.CREATEUSERID= branchMasters.CREATEUSERID;
                _res.CREATEDATE = branchMasters.CREATEDATE;
                _res.CREATETERMINALID = branchMasters.CREATETERMINALID;

                await _dbBase.BranchMaster.AddAsync(_res);
                var res = await _dbBase.SaveChangesAsync();
                if (res > 0)
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
                        ErrorMessage = "Failed to update BranchMasters.",
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
