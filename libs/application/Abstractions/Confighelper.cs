using HSMS.contracts.Dto;
using Microsoft.Extensions.Options;

namespace HSMS.Application.Abstractions
{
    public class Confighelper
    {
        private readonly SqlServerDto _sqlServer;

        public Confighelper(IOptions<SqlServerDto> config)
        {
            _sqlServer = config.Value;
        }

        public SqlServerDto Config()
        {
            return _sqlServer;

        }
    }
}
