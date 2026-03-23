using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.contracts.Dto
{
    public class DistrictMasterdto
    {
        public int? ID { get; set; }
        public string? DistrictID { get; set; }
        public string? DistrictName { get; set; }
        public int? StateID { get; set; }
        public string? StateName { get; set; }  
        public int? CREATEUSERID { get; set; }
        public DateTime? CREATEDATE { get; set; }
        public string? CREATETERMINALID { get; set; }
        public int? EDITUSERID { get; set; }
        public DateTime? EDITDATE { get; set; }
        public string? EDITTERMINALID { get; set; }

    }
}
