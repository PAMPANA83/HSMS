using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Domain.Domains
{
   
    public class DepartmentMasters
    {
        public int? ID { get; set; }
        public string? DeptID { get; set; }
        public int? MainDeptID { get; set; }
        public string? DepartmentName { get; set; }
        public string? DepartmentType { get; set; }
        public string? Shortname { get; set; }
        public int? Incharge { get; set; }
        public int? BranchID { get; set; }
        public int? CREATEUSERID { get; set; }
        public DateTime? CREATEDATE { get; set; }
        public string? CREATETERMINALID { get; set; }
        public int? EDITUSERID { get; set; }
        public DateTime? EDITDATE { get; set; }
        public string? EDITTERMINALID { get; set; }

        public DepartmentMasters(int? iD, string? deptID, int? mainDeptID, string? departmentName, string? departmentType, string? shortname, int? incharge, int? branchID, int? cREATEUSERID, DateTime? cREATEDATE, string? cREATETERMINALID, int? eDITUSERID, DateTime? eDITDATE, string? eDITTERMINALID)
        {
            ID = iD;
            DeptID = deptID;
            MainDeptID = mainDeptID;
            DepartmentName = departmentName;
            DepartmentType = departmentType;
            Shortname = shortname;
            Incharge = incharge;
            BranchID = branchID;
            CREATEUSERID = cREATEUSERID;
            CREATEDATE = cREATEDATE;
            CREATETERMINALID = cREATETERMINALID;
            EDITUSERID = eDITUSERID;
            EDITDATE = eDITDATE;
            EDITTERMINALID = eDITTERMINALID;
        }

    }
}
