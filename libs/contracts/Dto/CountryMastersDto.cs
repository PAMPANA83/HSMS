using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.contracts.Dto
{
    public class CountryMastersDto
    {
        public int? Id { get; set; }
        public string? CountryCode { get; set; }
        public string? CountryName { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateTerminalId { get; set; }
        public int? EditUserId { get; set; }
        public DateTime? EditDate { get; set; }
        public string? EditTerminalId { get; set; }
    }
}
