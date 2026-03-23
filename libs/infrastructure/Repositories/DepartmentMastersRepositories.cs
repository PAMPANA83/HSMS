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
    public class DepartmentMastersRepositories : DepartmentMastersIRepositories
    {
        private readonly ApplicationDbContext _dbBase;

        public DepartmentMastersRepositories(SqlserverConnHelper dbBase)
        {
            _dbBase = dbBase.CreateDbContext();

        }
        public async Task<Result<bool>> AddDepartmentMasters(DepartmentMasters departmentMasters)
        {
            try
            {
                var obj = new DepartmentMaster();
                obj.DeptID = departmentMasters.DeptID;
                obj.DepartmentName = departmentMasters.DepartmentName;
                obj.BranchID = departmentMasters.BranchID;          
                obj.CREATEUSERID = departmentMasters.CREATEUSERID;
                obj.CREATEDATE = departmentMasters.CREATEDATE;
                obj.BranchID= departmentMasters.BranchID;
                obj.MainDeptID= departmentMasters.MainDeptID;
                obj.Shortname= departmentMasters.Shortname;
                obj.Incharge= departmentMasters.Incharge;
                obj.CREATETERMINALID = departmentMasters.CREATETERMINALID;
                await _dbBase.DepartmentMaster.AddAsync(obj);
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

        public async Task<Result<bool>> DeleteDepartmentMasters(int id)
        {
            try
            {
                var obj = await _dbBase.DepartmentMaster.FindAsync(id);
                if (obj != null)
                {
                    _dbBase.DepartmentMaster.Remove(obj);
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
                            ErrorMessage = "Failed to delete DepartmentMasters.",
                        };
                    }
                }
                else
                {
                    return new Result<bool>
                    {
                        Data = false,
                        ErrorMessage = "DepartmentMasters not found.",
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

        public async Task<Result<List<DepartmentMasters>>> GetAllDepartmentMasters()
        {
          try
            {
                List<DepartmentMasters> lists = new List<DepartmentMasters>();
                var res = await _dbBase.DepartmentMaster.AsNoTracking().ToListAsync();
                if(res.Count>0)
                {
                    lists=res.Select(x=>new DepartmentMasters(x.ID,x.DeptID,x.MainDeptID,x.DepartmentName,x.DepartmentType,
                        x.Shortname,x.Incharge,x.BranchID,x.CREATEUSERID,x.CREATEDATE,x.CREATETERMINALID,x.EDITUSERID,
                        x.EDITDATE,x.EDITTERMINALID)).ToList();
                }
                return new Result<List<DepartmentMasters>>
                {
                    Data = lists,
                };
            }
            catch (Exception ex)
            {
                return new Result<List<DepartmentMasters>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<DepartmentMasters>> GetDepartmentMastersById(int id)
        {
            try
            {
               var res= await _dbBase.DepartmentMaster.AsNoTracking().FirstOrDefaultAsync(x=>x.ID==id);
                if(res!=null)
                {
                  
                    var _res1=new DepartmentMasters(res.ID,res.DeptID,res.MainDeptID,res.DepartmentName,res.DepartmentType,
                        res.Shortname,res.Incharge,res.BranchID,res.CREATEUSERID,res.CREATEDATE,res.CREATETERMINALID,
                        res.EDITUSERID,res.EDITDATE,res.EDITTERMINALID);
                    return new Result<DepartmentMasters>
                    {
                        Data = _res1,
                    };

                }
                else
                {
                    return new Result<DepartmentMasters>
                    {
                        Data = null,
                        ErrorMessage = "DepartmentMasters not found.",
                    };
                }
            }
            catch (Exception ex)
            {
                return new Result<DepartmentMasters>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public Task<Result<List<DepartmentMasters>>> GetDepartmentMastersByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<bool>> UpdateDepartmentMasters(DepartmentMasters departmentMasters)
        {
            try
            {
                var obj = await _dbBase.DepartmentMaster.FindAsync(departmentMasters.ID);
                if (obj != null)
                {
                    obj.DeptID = departmentMasters.DeptID;
                    obj.DepartmentName = departmentMasters.DepartmentName;
                    obj.BranchID = departmentMasters.BranchID;
                    obj.EDITUSERID = departmentMasters.EDITUSERID;
                    obj.EDITDATE = departmentMasters.EDITDATE;
                    obj.EDITTERMINALID = departmentMasters.EDITTERMINALID;
                    obj.MainDeptID = departmentMasters.MainDeptID;
                    obj.Shortname = departmentMasters.Shortname;
                    obj.Incharge = departmentMasters.Incharge;
                    _dbBase.DepartmentMaster.Update(obj);
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
                            ErrorMessage = "Failed to update DepartmentMasters.",
                        };
                    }
                }
                else
                {
                    return new Result<bool>
                    {
                        Data = false,
                        ErrorMessage = "DepartmentMasters not found.",
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
