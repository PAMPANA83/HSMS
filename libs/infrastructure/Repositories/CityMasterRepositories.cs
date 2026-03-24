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
    public class CityMasterRepositories : CityMasterIRepositories
    {
        private readonly ApplicationDbContext _dbBase;

        public CityMasterRepositories(SqlserverConnHelper dbBase)
        {
            _dbBase = dbBase.CreateDbContext();

        }
        public async Task<Result<bool>> AddCityMaster(CityMasters cityMaster)
        {
            try
            {
                var objs=new CityMaster();
                objs.CityID = cityMaster.CityID;
                objs.CityName = cityMaster.CityName;
                objs.DistrictID = cityMaster.DistrictID;
                objs.CREATEUSERID = cityMaster.CREATEUSERID;
                objs.CREATEDATE = cityMaster.CREATEDATE;
                objs.CREATETERMINALID = cityMaster.CREATETERMINALID;
                await _dbBase.CityMaster.AddAsync(objs);
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

        public async Task<Result<bool>> DeleteCityMaster(int id)
        {
            try
            {
                var _res = await _dbBase.CityMaster.FindAsync(id);
                if (_res == null)
                {
                    return new Result<bool>
                    {
                        ErrorMessage = "City not found",
                    };
                }
                _dbBase.CityMaster.Remove(_res);
                var _res1 = await _dbBase.SaveChangesAsync();
                _dbBase.Dispose();
                if (_res1 > 0)
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

        public async Task<Result<List<CityMasters>>> GetAllCityMasters()
        {
            try
            {
                List<CityMasters> result = new List<CityMasters>();
                var _res = await _dbBase.CityMaster.AsNoTracking().ToListAsync();
                if (_res == null || _res.Count == 0)
                {
                    return new Result<List<CityMasters>>
                    {
                        ErrorMessage = "No cities found",
                    };
                }
                else
                {
                    result = _res.Select(x => new CityMasters(x.ID,x.CityID,x.CityName,x.DistrictID,x.CREATEUSERID,
                        x.CREATEDATE,x.CREATETERMINALID,x.EDITUSERID,x.EDITDATE,x.EDITTERMINALID)).ToList();
                }
               return new Result<List<CityMasters>>
               {
                    Data = result,
               };

            }
            catch (Exception ex)
            {
                return new Result<List<CityMasters>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<List<CityMasters>>> GetAllCityMastersAsync(List<int?> id)
        {
            try
            {
                List<CityMasters> result = new List<CityMasters>();
                var _res = await _dbBase.CityMaster.Where(x=>id.Contains(x.ID)).ToListAsync();
                if (_res == null || _res.Count == 0)
                {
                    return new Result<List<CityMasters>>
                    {
                        ErrorMessage = "No cities found",
                    };
                }
                else
                {
                    result = _res.Select(x => new CityMasters(x.ID, x.CityID, x.CityName, x.DistrictID, x.CREATEUSERID,
                        x.CREATEDATE, x.CREATETERMINALID, x.EDITUSERID, x.EDITDATE, x.EDITTERMINALID)).ToList();
                }
                return new Result<List<CityMasters>>
                {
                    Data = result,
                };

            }
            catch (Exception ex)
            {
                return new Result<List<CityMasters>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<CityMasters>> GetCityMasterById(int id)
        {
            try
            {

                var _res = await _dbBase.CityMaster.FindAsync(id);
                if (_res == null)
                {
                    return new Result<CityMasters>
                    {
                        ErrorMessage = "City not found",
                    };
                }
                var result = new CityMasters(_res.ID, _res.CityID, _res.CityName, _res.DistrictID, _res.CREATEUSERID,
                    _res.CREATEDATE, _res.CREATETERMINALID, _res.EDITUSERID, _res.EDITDATE, _res.EDITTERMINALID);
                _dbBase.Dispose();
                return new Result<CityMasters>
                {
                    Data = result,
                };
            }
            catch (Exception ex)
            {
                return new Result<CityMasters>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<bool>> UpdateCityMaster(CityMasters cityMaster)
        {
            try
            {
                var _res = await _dbBase.CityMaster.FindAsync(cityMaster.ID);
                if (_res == null)
                {
                    return new Result<bool>
                    {
                        ErrorMessage = "City not found",
                    };
                }
                _res.CityID = cityMaster.CityID;
                _res.CityName = cityMaster.CityName;
                _res.DistrictID = cityMaster.DistrictID;
                _res.EDITUSERID = cityMaster.EDITUSERID;
                _res.EDITDATE = cityMaster.EDITDATE;
                _res.EDITTERMINALID = cityMaster.EDITTERMINALID;
                var _res1 = await _dbBase.SaveChangesAsync();
                _dbBase.Dispose();
                if (_res1 > 0)
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
