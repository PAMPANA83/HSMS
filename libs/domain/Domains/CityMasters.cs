using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Domain.Domains
{
    public class CityMasters
    {
        public int? ID { get; set; }
        public string? CityID { get; set; }
        public string? CityName { get; set; }
        public int? DistrictID { get; set; }
        public int? CREATEUSERID { get; set; }
        public DateTime? CREATEDATE { get; set; }
        public string? CREATETERMINALID { get; set; }
        public int? EDITUSERID { get; set; }
        public DateTime? EDITDATE { get; set; }
        public string? EDITTERMINALID { get; set; }

        public CityMasters(int? iD, string? cityID, string? cityName, int? districtID, int? cREATEUSERID, DateTime? cREATEDATE, string? cREATETERMINALID, int? eDITUSERID, DateTime? eDITDATE, string? eDITTERMINALID)
        {
            ID = iD;
            CityID = cityID;
            CityName = cityName;
            DistrictID = districtID;
            CREATEUSERID = cREATEUSERID;
            CREATEDATE = cREATEDATE;
            CREATETERMINALID = cREATETERMINALID;
            EDITUSERID = eDITUSERID;
            EDITDATE = eDITDATE;
            EDITTERMINALID = eDITTERMINALID;
        }
    }
}
