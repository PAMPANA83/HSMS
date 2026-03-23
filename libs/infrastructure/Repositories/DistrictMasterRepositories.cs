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
    public class DistrictMasterRepositories: DistrictMasterIRepositories
    {
        private readonly ApplicationDbContext _dbBase;

        public DistrictMasterRepositories(SqlserverConnHelper dbBase)
        {
            _dbBase = dbBase.CreateDbContext();
        }

        public async Task<Result<bool>> CreateDistrictMasterAsync(DistrictMasters dto)
        {
            try
            {
                var obj = new DistrictMaster();               
                obj.StateID = (int)dto.StateID;
                obj.DistrictID = dto.DistrictID;
                obj.DistrictName = dto.DistrictName ?? string.Empty;
                obj.CREATEDATE = dto.CREATEDATE;
                obj.CREATETERMINALID = dto.CREATETERMINALID;
                obj.CREATEUSERID = dto.CREATEUSERID;
                await _dbBase.DistrictMaster.AddAsync(obj);
                var _res = await _dbBase.SaveChangesAsync();
                _dbBase.Dispose();
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

        public async Task<Result<bool>> DeleteDistrictMasterAsync(int id)
        {
            try
            {
                var _res = await _dbBase.DistrictMaster.FindAsync(id);
                if (_res == null)
                {
                    return new Result<bool>
                    {
                        ErrorMessage = "District not found",
                    };
                }
                _dbBase.DistrictMaster.Remove(_res);
                var _result = await _dbBase.SaveChangesAsync();
                if (_result > 0)
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
            catch(Exception ex)
            {
                return new Result<bool>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<List<DistrictMasters>>> GetAllDistrictMasterAsync()
        {
            try
            {
                List<DistrictMasters> lists = new List<DistrictMasters>();
                var _res = await _dbBase.DistrictMaster.AsNoTracking().ToListAsync();
                if(_res != null && _res.Count > 0)
                {
                    lists = _res.Select(x => new DistrictMasters
                    (
                        x.ID,
                        x.DistrictID,
                        x.DistrictName,
                        x.StateID,
                        x.CREATEUSERID,
                        x.CREATEDATE,
                        x.CREATETERMINALID,
                        x.EDITUSERID,
                        x.EDITDATE,
                        x.EDITTERMINALID
                    )).ToList();
                }
           
                return new Result<List<DistrictMasters>>
                {
                    Data = lists
                };
            }
            catch (Exception ex)
            {
                return new Result<List<DistrictMasters>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<List<DistrictMasters>>> GetAllDistrictMastersAsync(List<int?> id)
        {
            try
            {
                List<DistrictMasters> lists = new List<DistrictMasters>();
                var _res = await _dbBase.DistrictMaster.Where(x=>id.Contains(x.ID)).ToListAsync();
                if (_res != null && _res.Count > 0)
                {
                    lists = _res.Select(x => new DistrictMasters
                    (
                        x.ID,
                        x.DistrictID,
                        x.DistrictName,
                        x.StateID,
                        x.CREATEUSERID,
                        x.CREATEDATE,
                        x.CREATETERMINALID,
                        x.EDITUSERID,
                        x.EDITDATE,
                        x.EDITTERMINALID
                    )).ToList();
                }

                return new Result<List<DistrictMasters>>
                {
                    Data = lists
                };
            }
            catch (Exception ex)
            {
                return new Result<List<DistrictMasters>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<bool>> UpdateDistrictMasterAsync(DistrictMasters dto)
        {
            try
            {
                var _res = await _dbBase.DistrictMaster.FindAsync(dto.ID);
                if (_res == null)
                {
                    return new Result<bool>
                    {
                        ErrorMessage = "District not found",
                    };
                }
                _res.DistrictID = dto.DistrictID;
                _res.DistrictName = dto.DistrictName ?? string.Empty;
                _res.StateID = (int)dto.StateID;
                _res.EDITUSERID = dto.EDITUSERID;
                _res.EDITDATE = dto.EDITDATE;
                _res.EDITTERMINALID = dto.EDITTERMINALID;

                _dbBase.DistrictMaster.Update(_res);
                var _result = await _dbBase.SaveChangesAsync();
                if (_result > 0)
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
    }
}
