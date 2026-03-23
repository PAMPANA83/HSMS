using HSMS.Application.IRepositories;

namespace HSMS.Application.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        public CountryMasterIRepositories _country { get; set; }
       
        public StateMasterIRepositories _state { get; set; }

        public DistrictMasterIRepositories _district { get; set; }

        public CityMasterIRepositories _city { get; set; }

        public CompanyMastersIRepositories _company { get; set; }

        public AreaMastersIRepositories _Area { get; set; }

        public BranchMastersIRepositories _branch { get; set; }

        public MainDepartmentMastersIRepositories _mainDepartment { get; set; }

        public DepartmentMastersIRepositories _department { get; set; }

        public DesignationsIRepositories _designations { get; set; }

        public QualificationMastersIRepositories _Qualification { get; set; }

        public UnitOfWork(CountryMasterIRepositories country, StateMasterIRepositories state,
            DistrictMasterIRepositories district, CityMasterIRepositories city, CompanyMastersIRepositories company, 
            AreaMastersIRepositories Area, BranchMastersIRepositories branch, MainDepartmentMastersIRepositories mainDepartment,
            DepartmentMastersIRepositories department, DesignationsIRepositories designations, QualificationMastersIRepositories qualification)
        {
            _country = country;
            _state = state;
            _district = district;
            _city = city;
            _company = company;
            _Area = Area;
            _branch = branch;
            _mainDepartment = mainDepartment;
            _department = department;
            _designations = designations;
            _Qualification = qualification;
        }
        public CountryMasterIRepositories country => _country;
        
        public StateMasterIRepositories state => _state;

        public DistrictMasterIRepositories district => _district;

        public CityMasterIRepositories city => _city;

        public CompanyMastersIRepositories company => _company;

        public AreaMastersIRepositories area => _Area;

        public BranchMastersIRepositories branch => _branch;

        public MainDepartmentMastersIRepositories mainDepartment => _mainDepartment;

        public DepartmentMastersIRepositories department => _department;

        public DesignationsIRepositories designations => _designations;

        public QualificationMastersIRepositories qualification => _Qualification;

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
