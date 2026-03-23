using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Domain.Domains
{
    public class AreaMasters
    {
        public int? ID { get; set; }
        public string? AreaID { get; set; }
        public string? AreaName { get; set; }
        public int? AreaPINCode { get; set; }
        public int? CityID { get; set; }
       
        public int? CREATEUSERID { get; set; }
        public DateTime? CREATEDATE { get; set; }
        public string? CREATETERMINALID { get; set; }
        public int? EDITUSERID { get; set; }
        public DateTime? EDITDATE { get; set; }
        public string? EDITTERMINALID { get; set; }
        public bool? Active { get; set; }

        public AreaMasters(int? iD, string? areaID, string? areaName, int? areaPINCode, int? cityID,  int? cREATEUSERID, DateTime? cREATEDATE, string? cREATETERMINALID, int? eDITUSERID, DateTime? eDITDATE, string? eDITTERMINALID, bool? active)
        {
            ID = iD;
            AreaID = areaID;
            AreaName = areaName;
            AreaPINCode = areaPINCode;
            CityID = cityID;           
            CREATEUSERID = cREATEUSERID;
            CREATEDATE = cREATEDATE;
            CREATETERMINALID = cREATETERMINALID;
            EDITUSERID = eDITUSERID;
            EDITDATE = eDITDATE;
            EDITTERMINALID = eDITTERMINALID;
            Active = active;
        }
    }
}
