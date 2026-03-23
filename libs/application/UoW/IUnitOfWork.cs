using HSMS.Application.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Application.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        CountryMasterIRepositories country { get; }
        StateMasterIRepositories state { get; }
        DistrictMasterIRepositories district { get; }
        CityMasterIRepositories city { get; }

        AreaMastersIRepositories area { get; }

        BranchMastersIRepositories branch { get; }

        CompanyMastersIRepositories company { get; }

        MainDepartmentMastersIRepositories mainDepartment { get; }

        DepartmentMastersIRepositories department { get; }
        DesignationsIRepositories designations { get; }

        QualificationMastersIRepositories qualification { get; }

    }
}
