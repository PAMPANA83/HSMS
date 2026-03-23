using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.contracts.Dto
{
    public class MainDepartmentMastersDto
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
    }
}
