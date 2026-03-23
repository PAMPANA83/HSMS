using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Domain.Domains
{
    public class CompanyMasters
    {
        public int? ID { get; set; }
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
        public int? CREATEUSERID { get; set; }
        public DateTime? CREATEDATE { get; set; }
        public string? CREATETERMINALID { get; set; }
        public int? EDITUSERID { get; set; }
        public DateTime? EDITDATE { get; set; }
        public string? EDITTERMINALID { get; set; }
        
        public CompanyMasters(int? id, string? companyID, string? companyName, int? companyCode, DateTime? installationDate, string? address, int? stateID, int? districtID, int? cityID, int? areaID, string? mobile1, string? mobile2, string? phone, string? contactPerson, int? cREATEUSERID, DateTime? cREATEDATE, string? cREATETERMINALID, int? eDITUSERID, DateTime? eDITDATE, string? eDITTERMINALID)
        {
            ID = id;
            CompanyID = companyID;
            CompanyName = companyName;
            CompanyCode = companyCode;
            InstallationDate = installationDate;
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
