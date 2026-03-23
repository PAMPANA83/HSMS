using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Domain.Domains
{
    public class BranchMasters
    {
        public int? ID { get; set; }
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
        public int? CREATEUSERID { get; set; }
        public DateTime? CREATEDATE { get; set; }
        public string? CREATETERMINALID { get; set; }
        public int? EDITUSERID { get; set; }
        public DateTime? EDITDATE { get; set; }
        public string? EDITTERMINALID { get; set; }

        public BranchMasters(int? iD, string? branchID, string? branchName, string? branchHeader, string? registerName, string? lABHeader, int? companyID, string? address, int? stateID, int? districtID, int? cityID, int? areaID, string? mobile1, string? mobile2, string? phone, string? contactPerson, int? cREATEUSERID, DateTime? cREATEDATE, string? cREATETERMINALID, int? eDITUSERID, DateTime? eDITDATE, string? eDITTERMINALID)
        {
            ID = iD;
            BranchID = branchID;
            BranchName = branchName;
            BranchHeader = branchHeader;
            RegisterName = registerName;
            LABHeader = lABHeader;
            CompanyID = companyID;
            Address = address;
            StateID = stateID;
            DistrictID = districtID;
            CityID = cityID;
            AreaID = areaID;
            Mobile1 = mobile1;
            Mobile2 = mobile2;
            Phone = phone;
            ContactPerson = contactPerson;
            CREATEUSERID = cREATEUSERID;
            CREATEDATE = cREATEDATE;
            CREATETERMINALID = cREATETERMINALID;
            EDITUSERID = eDITUSERID;
            EDITDATE = eDITDATE;
            EDITTERMINALID = eDITTERMINALID;
        }
    }
}
