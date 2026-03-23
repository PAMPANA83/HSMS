using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.contracts.Dto
{
    public class AreaMastersDto
    {
        public int? ID { get; set; }
        public string? AreaID { get; set; }
        public string? AreaName { get; set; }
        public int? AreaPINCode { get; set; }
        public int? CityID { get; set; }
        public string?  CityName { get; set; }
        public int? CREATEUSERID { get; set; }
        public DateTime? CREATEDATE { get; set; }
        public string? CREATETERMINALID { get; set; }
        public int? EDITUSERID { get; set; }
        public DateTime? EDITDATE { get; set; }
        public string? EDITTERMINALID { get; set; }
        public bool? Active { get; set; }
    }
}
