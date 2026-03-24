using HSMS.Application.IRepositories;
using HSMS.Domain.Domains;
using HSMS.infrastructure.Entities;
using HSMS.infrastructure.Persistence;
using HSMS.shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HSMS.infrastructure.Repositories
{
    public class CountryMasterRepositories : CountryMasterIRepositories
    {
        private readonly ApplicationDbContext _dbBase;

        public CountryMasterRepositories(SqlserverConnHelper dbBase)
        {
            _dbBase = dbBase.CreateDbContext();

        }
        public async Task<Result<CountryMasters>> CreateCountryMastersAsync(CountryMasters dto)
        {
            try
            {
                var obj = new CountryMaster();
                obj.CREATEDATE = dto.CreateDate;
                obj.CountryID = dto.CountryCode ?? string.Empty;
                obj.CountryName = dto.CountryName;
                obj.CREATETERMINALID = dto.CreateTerminalId;
                obj.CREATEUSERID = dto.CreateUserId;
                await _dbBase.CountryMasters.AddAsync(obj);
                var _res = await _dbBase.SaveChangesAsync();
                var result = new CountryMasters(obj.ID, obj.CountryID, obj.CountryName, obj.CREATEUSERID,
                    obj.CREATEDATE, obj.CREATETERMINALID, obj.EDITUSERID, obj.EDITDATE, obj.EDITTERMINALID);
                
                return new Result<CountryMasters>
                {
                    Data = result,
                };
            }
            catch (Exception ex)
            {
                return new Result<CountryMasters>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<bool>> DeleteCountryMasterAsync(int id)
        {
           try
            {
                var _res = await _dbBase.CountryMasters.FindAsync(id);
                if (_res == null)
                {
                    return new Result<bool>
                    {
                        ErrorMessage = "Country not found",
                    };
                }
                _dbBase.CountryMasters.Remove(_res);
                var res = await _dbBase.SaveChangesAsync();
                if(res > 0)
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
                        ErrorMessage = "Failed to delete country",
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

        public async Task<Result<List<CountryMasters>>> GetAllCountryMasterAsync(int[] ids)
        {
            try
            {
                List<CountryMasters> obj = new List<CountryMasters>();
              

                var _res = await _dbBase.CountryMasters
                    .Where(x => ids.Contains(x.ID))
                    .AsNoTracking()
                    .ToListAsync();


                if (_res != null)
                {
                    obj = _res.Select(x => new CountryMasters(x.ID, x.CountryID, x.CountryName, x.CREATEUSERID,
                        x.CREATEDATE, x.CREATETERMINALID, x.EDITUSERID, x.EDITDATE, x.EDITTERMINALID)
                          ).ToList();
                }

                return new Result<List<CountryMasters>>
                {
                    Data = obj
                };
            }
            catch (Exception ex)
            {
                return new Result<List<CountryMasters>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<List<CountryMasters>>> GetAllCountryMastersAsync()
        {
            try 
            {
                List<CountryMasters> obj = new List<CountryMasters>();
                var _res = await _dbBase.CountryMasters.ToListAsync();
                
                if (_res != null)
                {
                    obj = _res.Select(x => new CountryMasters(x.ID, x.CountryID, x.CountryName, x.CREATEUSERID,
                        x.CREATEDATE, x.CREATETERMINALID, x.EDITUSERID, x.EDITDATE, x.EDITTERMINALID)
                          ).ToList();
                }
               
                return new Result<List<CountryMasters>>
                {
                    Data = obj
                };
            }
            catch (Exception ex)
            {
                return new Result<List<CountryMasters>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }
    }
}
