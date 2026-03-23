using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.contracts.Dto
{
    public class CompanyDto
    {
        public string? CompanyID { get; set; }
        public string? CompanyName { get; set; }
        public int? CompanyCode { get; set; }
        public DateTime? InstallationDate { get; set; }
        public string? Address { get; set; }
        public int? StateID { get; set; }
        public int? DistrictID { get; set; }
        public int? CityID { get; set; }
        public int? AreaID { get; set; }
        public string? Mobile1 { get; set; }
        public string? Mobile2 { get; set; }
        public string? Phone { get; set; }
        public string? ContactPerson { get; set; }
    }
}
