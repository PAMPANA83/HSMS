using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.contracts.Dto
{
    public class StateMasterDto
    {
        public int ID { get; set; }
        public string? stateID { get; set; }
        public string? StateName { get; set; }
        public int? StateCode { get; set; }
        public int? CountryID { get; set; }
        public string? CountryName { get; set; }
        public int? CREATEUSERID { get; set; }
        public DateTime? CREATEDATE { get; set; }
        public string? CREATETERMINALID { get; set; }
        public int? EDITUSERID { get; set; }
        public DateTime? EDITDATE { get; set; }
        public string? EDITTERMINALID { get; set; }
    }
}
