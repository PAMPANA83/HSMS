using HSMS.infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace HSMS.infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        // DbSet represents a table in the database
        public DbSet<CountryMaster> CountryMasters { get; set; }

        public DbSet<StateMaster> StateMaster { get; set; }

        public DbSet<DistrictMaster> DistrictMaster { get; set; }

        public DbSet<CityMaster> CityMaster { get; set; }

        public DbSet<AreaMaster> AreaMaster { get; set; }

        public DbSet<BranchMaster> BranchMaster { get; set; }

        public DbSet<DepartmentMaster> DepartmentMaster { get; set; }

        public DbSet<CompanyMaster> CompanyMaster { get; set; }

        public DbSet<Designation> DesignationMaster { get; set; }

        public DbSet<MainDepartmentMaster> MainDepartmentMaster { get; set; }

        public DbSet<QualificationMaster> QualificationMaster { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
