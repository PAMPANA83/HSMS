using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.contracts.Dto
{
    public class Departmentdto
    {
        public string? DeptID { get; set; }
        public int? MainDeptID { get; set; }
        public string? DepartmentName { get; set; }
        public string? DepartmentType { get; set; }
        public string? Shortname { get; set; }
        public int? Incharge { get; set; }
        public int? BranchID { get; set; }
    }
}
