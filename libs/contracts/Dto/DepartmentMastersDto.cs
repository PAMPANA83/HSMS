using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.contracts.Dto
{
    public class DepartmentMastersDto
    {
        public int? ID { get; set; }
        public string? DeptID { get; set; }
        public int? MainDeptID { get; set; }
        public string? MainDepartmentName {  get; set; }
        public string? DepartmentName { get; set; }
        public string? DepartmentType { get; set; }
        public string? Shortname { get; set; }
        public int? Incharge { get; set; }
        public int? BranchID { get; set; }
        public string? BranchName { get; set; }
        public int? CREATEUSERID { get; set; }
        public DateTime? CREATEDATE { get; set; }
        public string? CREATETERMINALID { get; set; }
        public int? EDITUSERID { get; set; }
        public DateTime? EDITDATE { get; set; }
        public string? EDITTERMINALID { get; set; }
    }
}
