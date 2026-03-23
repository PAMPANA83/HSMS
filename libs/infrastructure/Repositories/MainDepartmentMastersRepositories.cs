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
    public class MainDepartmentMastersRepositories : MainDepartmentMastersIRepositories
    {
        private readonly ApplicationDbContext _dbBase;

        public MainDepartmentMastersRepositories(SqlserverConnHelper dbBase)
        {
            _dbBase = dbBase.CreateDbContext();

        }
        public async Task<Result<bool>> CreateMainDepartmentMaster(MainDepartmentMasters dto)
        {
            try
            {
                var obj = new MainDepartmentMaster();
                obj.MainDeptID = dto.MainDeptID;
                obj.MainDepartmentName = dto.MainDepartmentName;
                obj.CREATEUSERID = dto.CREATEUSERID;
                obj.CREATEDATE = dto.CREATEDATE;
                obj.CREATETERMINALID = dto.CREATETERMINALID;
                await _dbBase.MainDepartmentMaster.AddAsync(obj);
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

        public async Task<Result<bool>> DeleteMainDepartmentMaster(int id)
        {
            try
            {
                var obj = await _dbBase.MainDepartmentMaster.FindAsync(id);
                if (obj != null)
                {
                    _dbBase.MainDepartmentMaster.Remove(obj);
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
                else
                {
                    return new Result<bool>
                    {
                        Data = false,
                        ErrorMessage = "Record not found",
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

        public async Task<Result<List<MainDepartmentMasters>>> GetAllMainDepartmentMasters()
        {
            try
            { List<MainDepartmentMasters> obj = new List<MainDepartmentMasters>();
                var res = await _dbBase.MainDepartmentMaster.AsNoTracking().ToListAsync();
                if(res!=null)
                {
                    obj=res.Select(x=> new MainDepartmentMasters(x.ID,x.MainDeptID,x.MainDepartmentName,x.CREATEUSERID,
                        x.CREATEDATE,x.CREATETERMINALID,x.EDITUSERID,x.EDITDATE,x.EDITTERMINALID)).ToList();
                }
                return new Result<List<MainDepartmentMasters>>
                {
                    Data = obj,
                };
            }
            catch (Exception ex)
            {
                return new Result<List<MainDepartmentMasters>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<MainDepartmentMasters>> GetMainDepartmentMasterById(int id)
        {
            try
            {
                var obj = await _dbBase.MainDepartmentMaster.AsNoTracking().FirstOrDefaultAsync(x => x.ID == id);
                if(obj != null)
                {
                    var res = new MainDepartmentMasters(obj.ID, obj.MainDeptID, obj.MainDepartmentName, obj.CREATEUSERID,
                        obj.CREATEDATE, obj.CREATETERMINALID, obj.EDITUSERID, obj.EDITDATE, obj.EDITTERMINALID);
                    return new Result<MainDepartmentMasters>
                    {
                        Data = res,
                    };
                }
                else
                {
                    return new Result<MainDepartmentMasters>
                    {
                        ErrorMessage = "Record not found",
                    };
                }
            }
            catch (Exception ex)
            {
                return new Result<MainDepartmentMasters>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<bool>> UpdateMainDepartmentMaster(MainDepartmentMasters dto)
        {

            try
            {
                var obj = await _dbBase.MainDepartmentMaster.FindAsync(dto.ID);
                if (obj != null)
                {
                    obj.MainDeptID = dto.MainDeptID;
                    obj.MainDepartmentName = dto.MainDepartmentName;
                    obj.EDITUSERID = dto.EDITUSERID;
                    obj.EDITDATE = dto.EDITDATE;
                    obj.EDITTERMINALID = dto.EDITTERMINALID;
                    _dbBase.MainDepartmentMaster.Update(obj);
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
                else
                {
                    return new Result<bool>
                    {
                        Data = false,
                        ErrorMessage = "Record not found",
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
