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
    public class DesignationsRepositories : DesignationsIRepositories
    {
        private readonly ApplicationDbContext _dbBase;

        public DesignationsRepositories(SqlserverConnHelper dbBase)
        {
            _dbBase = dbBase.CreateDbContext();
        }
        public async Task<Result<bool>> CreateDesignation(Designations designation)
        {
           try
            {
                var obj = new Designation();
                obj.DesigID = designation.DesigID;
                obj.DesignationName = designation.DesignationName;
                obj.BranchID = designation.BranchID;
                obj.CREATEUSERID = designation.CREATEUSERID;
                obj.CREATEDATE = designation.CREATEDATE;
                obj.CREATETERMINALID = designation.CREATETERMINALID;
                await _dbBase.DesignationMaster.AddAsync(obj);
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

        public async Task<Result<bool>> DeleteDesignation(int id)
        {
            try
            {
                var obj = await _dbBase.DesignationMaster.FindAsync(id);
                if (obj!= null)
                {
                    _dbBase.DesignationMaster.Remove(obj);
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
                        };
                    }
                }
                else
                {
                    return new Result<bool>
                    {
                        Data = false,
                        ErrorMessage = "Designation not found",
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

        public async Task<Result<List<Designations>>> GetAllDesignations()
        {
            try
            {
                List<Designations> des=new List<Designations>();
                var res = await _dbBase.DesignationMaster.AsNoTracking().ToListAsync();
                if(res.Count > 0)
                {
                 des=res.Select(x=> new Designations(x.ID, x.DesigID, x.DesignationName,x.BranchID,
                     x.CREATEUSERID,x.CREATEDATE,x.CREATETERMINALID,x.EDITUSERID,x.EDITDATE,x.EDITTERMINALID)).ToList();
                }

                return new Result<List<Designations>>
                {
                    Data = des,
                };

            }
            catch (Exception ex)
            {
             return new Result<List<Designations>>
             {
                 ErrorMessage = ex.Message,
             };
            }
        }

        public async Task<Result<Designations>> GetDesignationById(int id)
        {
            try
            {
              var res = await _dbBase.DesignationMaster.AsNoTracking().FirstOrDefaultAsync(x=> x.ID == id);
                if (res != null)
                {
                    var des = new Designations(res.ID, res.DesigID, res.DesignationName, res.BranchID,
                     res.CREATEUSERID, res.CREATEDATE, res.CREATETERMINALID, res.EDITUSERID, res.EDITDATE, res.EDITTERMINALID);
                    return new Result<Designations>
                    {
                        Data = des,
                    };
                }
                else
                {
                    return new Result<Designations>
                    {
                        Data = null,
                        ErrorMessage = "Designation not found",
                    };
                }
            }
            catch (Exception ex)
            {
                return new Result<Designations>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<bool>> UpdateDesignation(Designations designation)
        {
            try
            {
                var obj = await _dbBase.DesignationMaster.FindAsync(designation.ID);
                if(obj != null)
                {
                    obj.DesigID = designation.DesigID;
                    obj.DesignationName = designation.DesignationName;
                    obj.BranchID = designation.BranchID;
                    obj.EDITUSERID = designation.EDITUSERID;
                    obj.EDITDATE = designation.EDITDATE;
                    obj.EDITTERMINALID = designation.EDITTERMINALID;
                    _dbBase.DesignationMaster.Update(obj);
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
                        };
                    }
                }
                else
                {
                    return new Result<bool>
                    {
                        Data = false,
                        ErrorMessage = "Designation not found",
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
