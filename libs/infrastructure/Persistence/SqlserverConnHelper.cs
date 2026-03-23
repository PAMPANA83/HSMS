using HSMS.Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace HSMS.infrastructure.Persistence
{
    public class SqlserverConnHelper
    {
        private readonly Confighelper _configs;

        public SqlserverConnHelper(Confighelper config)
        {
            _configs = config;
        }

        public ApplicationDbContext CreateDbContext()
        {
            var connsql = _configs.Config();
            string connString = $"Server={connsql.server};Database={connsql.database};User Id={connsql.userID};Password={connsql.password};Trusted_Connection=true;MultipleActiveResultSets=True;TrustServerCertificate=True;";
            // Create DbContext options
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connString);

            // Create DbContext manually
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
