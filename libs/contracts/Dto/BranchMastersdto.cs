using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.contracts.Dto
{
    public class BranchMastersdto
    {
        public int? ID { get; set; }
        public string? BranchID { get; set; }
        public string? BranchName { get; set; }
        public string? BranchHeader { get; set; }
        public string? RegisterName { get; set; }
        public string? LABHeader { get; set; }
        public int? CompanyID { get; set; }

        public string? CompanyName { get; set; }
        public string? Address { get; set; }
        public int? StateID { get; set; }

        public string? StateName {  get; set; }
        public int? DistrictID { get; set; }

        public string? DistrictName { get; set; }   
        public int? CityID { get; set; }
        public string? CityName { get; set; }
        public int? AreaID { get; set; }
        public string? AreaName { get; set; }
        public string? Mobile1 { get; set; }
        public string? Mobile2 { get; set; }
        public string? Phone { get; set; }
        public string? ContactPerson { get; set; }
        public int? CREATEUSERID { get; set; }
        public DateTime? CREATEDATE { get; set; }
        public string? CREATETERMINALID { get; set; }
        public int? EDITUSERID { get; set; }
        public DateTime? EDITDATE { get; set; }
        public string? EDITTERMINALID { get; set; }
    }
}
