using HSMS.Application.IRepositories;
using HSMS.Domain.Domains;
using HSMS.infrastructure.Entities;
using HSMS.infrastructure.Persistence;
using HSMS.shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace HSMS.infrastructure.Repositories
{
    public class StateMasterRepositories:StateMasterIRepositories
    {
        private readonly ApplicationDbContext _dbBase;

        public StateMasterRepositories(SqlserverConnHelper dbBase)
        {
            _dbBase = dbBase.CreateDbContext();

        }

        public async Task<Result<bool>> CreateStateMasterAsync(StateMasters dto)
        {
            
            try
            {
                    var obj = new StateMaster();
                    obj.CountryID = (int)dto.CountryID;
                    obj.StateCode = (int)dto.StateCode;
                    obj.StateName = dto.StateName?? string.Empty;
                    obj.stateID = dto.stateID?? string.Empty;
                    obj.CREATEDATE = dto.CREATEDATE;
                    obj.CREATETERMINALID = dto.CREATETERMINALID;
                    obj.CREATEUSERID = dto.CREATEUSERID;
                    await _dbBase.StateMaster.AddAsync(obj);
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

        public async Task<Result<bool>> DeleteStateMasterAsync(int id)
        {
            try
            {
                var _res = await _dbBase.StateMaster.FindAsync(id);
                if (_res == null)
                {
                    return new Result<bool>
                    {
                        ErrorMessage = "State not found",
                    };
                }
                _dbBase.StateMaster.Remove(_res);
                var _res1 = await _dbBase.SaveChangesAsync();
                
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

        public async Task<Result<List<StateMasters>>> GetAllStateMasteByIDrAsync(List<int?> id)
        {
            try
            {
                List<StateMasters> obj = new List<StateMasters>();
                var _res = await _dbBase.StateMaster.Where(x=>id.Contains(x.ID) ).ToListAsync();
                if (_res == null || _res.Count == 0)
                {
                    return new Result<List<StateMasters>>
                    {
                        ErrorMessage = "No states found",
                    };
                }
                else
                {
                    obj = _res.Select(x => new StateMasters(x.ID, x.stateID, x.StateName, x.StateCode, x.CountryID, x.CREATEUSERID,
                        x.CREATEDATE, x.CREATETERMINALID, x.EDITUSERID, x.EDITDATE, x.EDITTERMINALID)).ToList();
                }
                return new Result<List<StateMasters>>
                {
                    Data = obj,
                };
            }

            catch (Exception ex)
            {
                return new Result<List<StateMasters>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<List<StateMasters>>> GetAllStateMasterAsync()
        {
            try
            {
                List<StateMasters> obj = new List<StateMasters>();
                var _res = await _dbBase.StateMaster.ToListAsync();
                if (_res == null || _res.Count == 0)
                {
                    return new Result<List<StateMasters>>
                    {
                        ErrorMessage = "No states found",
                    };
                }
                else
                {
                    obj = _res.Select(x => new StateMasters(x.ID, x.stateID, x.StateName, x.StateCode, x.CountryID, x.CREATEUSERID,
                        x.CREATEDATE, x.CREATETERMINALID, x.EDITUSERID, x.EDITDATE, x.EDITTERMINALID)).ToList();
                }
                return new Result<List<StateMasters>>
                {
                    Data = obj,
                };
            }

            catch (Exception ex)
            {
                return new Result<List<StateMasters>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<bool>> UpdateStateMasterAsync(StateMasters dto)
        {
            try
            {

               var _res = await _dbBase.StateMaster.FindAsync(dto.ID);
                if (_res == null)
                {
                    return new Result<bool>
                    {
                        ErrorMessage = "State not found",
                    };
                }
                _res.StateName = dto.StateName?? string.Empty;
                _res.StateCode = (int)dto.StateCode;
                _res.CountryID = (int)dto.CountryID;
                _res.EDITUSERID =(int) dto.EDITUSERID;
                _res.EDITDATE = dto.EDITDATE;
                _res.EDITTERMINALID = dto.EDITTERMINALID;
                 _dbBase.StateMaster.Update(_res);
                var _res1 = await _dbBase.SaveChangesAsync();
               
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
