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
    public class AreaMastersRepositories : AreaMastersIRepositories
    {
        private readonly ApplicationDbContext _dbBase;

        public AreaMastersRepositories(SqlserverConnHelper dbBase)
        {
            _dbBase = dbBase.CreateDbContext();

        }
        public async Task<Result<bool>> AddAreaMaster(AreaMasters areaMaster)
        {
            try
            {
                var obj = new AreaMaster();
                obj.AreaID = areaMaster.AreaID;
                obj.AreaName = areaMaster.AreaName;
                obj.AreaPINCode = areaMaster.AreaPINCode;
                obj.CityID = areaMaster.CityID;               
                obj.CREATEUSERID = areaMaster.CREATEUSERID;
                obj.CREATEDATE = areaMaster.CREATEDATE;
                obj.CREATETERMINALID = areaMaster.CREATETERMINALID;
                await _dbBase.AreaMaster.AddAsync(obj);
                var _res = await _dbBase.SaveChangesAsync();
                if(_res > 0)
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

        public async Task<Result<bool>> DeleteAreaMaster(int id)
        {
            try
            {
              var _res = await _dbBase.AreaMaster.FindAsync(id);
                if (_res == null)
                {
                    return new Result<bool>
                    {
                        ErrorMessage = "Area not found",
                    };
                }
                _dbBase.AreaMaster.Remove(_res);
                var result = await _dbBase.SaveChangesAsync();
                if(result > 0)
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

        public async Task<Result<List<AreaMasters>>> GetAllAreaMasters()
        {
            try
            {
                List<AreaMasters> result = new List<AreaMasters>();
                var _res = await _dbBase.AreaMaster.AsNoTracking().ToListAsync();
                if (_res != null && _res.Count > 0)
                {
                    result= _res.Select(x => new AreaMasters(x.ID,x.AreaID,x.AreaName,x.AreaPINCode,x.CityID,
                        x.CREATEUSERID,x.CREATEDATE,x.CREATETERMINALID,x.EDITUSERID,x.EDITDATE,x.EDITTERMINALID,x.Active)).ToList();
                }

                return new Result<List<AreaMasters>>
                { Data = result };
            }
            catch (Exception ex)
            {
                return new Result<List<AreaMasters>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<List<AreaMasters>>> GetAllAreaMastersAsync(List<int?> id)
        {
            try
            {
                List<AreaMasters> result = new List<AreaMasters>();
                var _res = await _dbBase.AreaMaster.Where(x=>id.Contains(x.ID)).ToListAsync();
                if (_res != null && _res.Count > 0)
                {
                    result = _res.Select(x => new AreaMasters(x.ID, x.AreaID, x.AreaName, x.AreaPINCode, x.CityID,
                        x.CREATEUSERID, x.CREATEDATE, x.CREATETERMINALID, x.EDITUSERID, x.EDITDATE, x.EDITTERMINALID, x.Active)).ToList();
                }

                return new Result<List<AreaMasters>>
                { Data = result };
            }
            catch (Exception ex)
            {
                return new Result<List<AreaMasters>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<AreaMasters>> GetAreaMasterById(int id)
        {
            try
            {
                var _res = await _dbBase.AreaMaster.AsNoTracking().FirstOrDefaultAsync(x => x.ID == id);
                if (_res == null)
                {
                    return new Result<AreaMasters>
                    {
                        ErrorMessage = "Area not found",
                    };
                }
                else
                {
                    var result = new AreaMasters(_res.ID, _res.AreaID, _res.AreaName, _res.AreaPINCode, _res.CityID, 
                        _res.CREATEUSERID, _res.CREATEDATE, _res.CREATETERMINALID, _res.EDITUSERID, _res.EDITDATE, _res.EDITTERMINALID, _res.Active);
                    return new Result<AreaMasters>
                    {
                        Data = result,
                    };
                }
            }
            catch (Exception ex)
            {
                return new Result<AreaMasters>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<bool>> UpdateAreaMaster(AreaMasters areaMaster)
        {
            try
            {
                var _res = await _dbBase.AreaMaster.FindAsync(areaMaster.ID);
                if (_res == null)
                {
                    return new Result<bool>
                    {
                        ErrorMessage = "Area not found",
                    };
                }
                _res.AreaID = areaMaster.AreaID;
                _res.AreaName = areaMaster.AreaName;
                _res.AreaPINCode = areaMaster.AreaPINCode;
                _res.CityID = areaMaster.CityID;            
                _res.EDITUSERID = areaMaster.EDITUSERID;
                _res.EDITDATE = areaMaster.EDITDATE;
                _res.EDITTERMINALID = areaMaster.EDITTERMINALID;
                _dbBase.AreaMaster.Update(_res);
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
