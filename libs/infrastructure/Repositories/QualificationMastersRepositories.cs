using HSMS.Application.IRepositories;
using HSMS.Domain.Domains;
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
    public class QualificationMastersRepositories : QualificationMastersIRepositories
    {
        private readonly ApplicationDbContext _dbBase;

        public QualificationMastersRepositories(SqlserverConnHelper dbBase)
        {
            _dbBase = dbBase.CreateDbContext();

        }
        public Task<Result<bool>> CreateQualificationMaster(QualificationMasters dto)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<bool>> DeleteQualificationMaster(int id)
        {
            try
            {
                var obj = await _dbBase.QualificationMaster.Where(x => x.ID == id).FirstOrDefaultAsync();
                if (obj != null)
                {
                    _dbBase.QualificationMaster.Remove(obj);
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

        public async Task<Result<List<QualificationMasters>>> GetAllQualificationMasters()
        {
           try
            {
                List<QualificationMasters> res = new List<QualificationMasters>();
                var _res = await _dbBase.QualificationMaster.AsNoTracking().ToListAsync();
                if (_res != null && _res.Count > 0)
                {
                    res = _res.Select(x => new QualificationMasters(x.ID,x.QualificationID,x.QualificationName,
                                    x.CREATEUSERID,x.CREATEDATE,x.CREATETERMINALID,x.EDITUSERID,x.EDITDATE,x.EDITTERMINALID)).ToList();
                    return new Result<List<QualificationMasters>>
                    {
                        Data = res
                    };
                }
                return new Result<List<QualificationMasters>>
                {
                    Data = null
                };

            }
            catch (Exception ex)
            {
                return new Result<List<QualificationMasters>>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public async Task<Result<QualificationMasters>> GetQualificationMasterById(int id)
        {
            try
            {
                var _res = await _dbBase.QualificationMaster.Where(x => x.ID == id).AsNoTracking().FirstOrDefaultAsync();
                if (_res != null)
                {
                    var res = new QualificationMasters(_res.ID, _res.QualificationID, _res.QualificationName,
                        _res.CREATEUSERID, _res.CREATEDATE, _res.CREATETERMINALID, _res.EDITUSERID, _res.EDITDATE, _res.EDITTERMINALID);
                    return new Result<QualificationMasters>
                    {
                        Data = res
                    };
                }
                else
                {
                    return new Result<QualificationMasters>
                    {
                        Data = null,
                        ErrorMessage = "Record not found",
                    };
                }


            }
            catch (Exception ex)
            {
                return new Result<QualificationMasters>
                {
                    ErrorMessage = ex.Message,
                };
            }
        }

        public Task<Result<bool>> UpdateQualificationMaster(QualificationMasters dto)
        {
            throw new NotImplementedException();
        }
    }
}
