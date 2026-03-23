using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.contracts.Dto
{
    public class StateDto
    {
        public string? stateID { get; set; }
        public string? StateName { get; set; }
        public int? StateCode { get; set; }
        public int? CountryID { get; set; }
    }
}
