using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.contracts.Dto
{
    public class AreaDto
    {
        public string? AreaID { get; set; }
        public string? AreaName { get; set; }
        public int? AreaPINCode { get; set; }
        public int? CityID { get; set; }
    }
}
