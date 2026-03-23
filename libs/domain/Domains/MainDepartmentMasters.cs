using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Domain.Domains
{
    public class MainDepartmentMasters
    {
        public int? ID { get; set; }
        public string? MainDeptID { get; set; }
        public string? MainDepartmentName { get; set; }
        public int? CREATEUSERID { get; set; }
        public DateTime? CREATEDATE { get; set; }
        public string? CREATETERMINALID { get; set; }
        public int? EDITUSERID { get; set; }
        public DateTime? EDITDATE { get; set; }
        public string? EDITTERMINALID { get; set; }

        public MainDepartmentMasters(int? iD, string? mainDeptID, string? mainDepartmentName, int? cREATEUSERID, DateTime? cREATEDATE, string? cREATETERMINALID, int? eDITUSERID, DateTime? eDITDATE, string? eDITTERMINALID)
        {
            ID = iD;
            MainDeptID = mainDeptID;
            MainDepartmentName = mainDepartmentName;
            CREATEUSERID = cREATEUSERID;
            CREATEDATE = cREATEDATE;
            CREATETERMINALID = cREATETERMINALID;
            EDITUSERID = eDITUSERID;
            EDITDATE = eDITDATE;
            EDITTERMINALID = eDITTERMINALID;
        }
    }
}
