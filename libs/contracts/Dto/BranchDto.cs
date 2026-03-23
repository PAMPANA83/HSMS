using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.contracts.Dto
{
    public class BranchDto
    {
        public string? BranchID { get; set; }
        public string? BranchName { get; set; }
        public string? BranchHeader { get; set; }
        public string? RegisterName { get; set; }
        public string? LABHeader { get; set; }
        public int? CompanyID { get; set; }
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
