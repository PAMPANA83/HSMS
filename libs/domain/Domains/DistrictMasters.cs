using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Domain.Domains
{
    public class DistrictMasters
    {
        public int? ID { get; set; }
        public string? DistrictID { get; set; }
        public string? DistrictName { get; set; }
        public int? StateID { get; set; }
        public int? CREATEUSERID { get; set; }
        public DateTime? CREATEDATE { get; set; }
        public string? CREATETERMINALID { get; set; }
        public int? EDITUSERID { get; set; }
        public DateTime? EDITDATE { get; set; }
        public string? EDITTERMINALID { get; set; }

        public DistrictMasters(int? id, string? districtId, string? districtName, int? stateId, int? createUserId,
                               DateTime? createDate, string? createTerminalId, int? editUserId, DateTime? editDate,
                               string? editTerminalId)
        {
            ID = id;
            DistrictID = districtId;
            DistrictName = districtName;
            StateID = stateId;
            CREATEUSERID = createUserId;
            CREATEDATE = createDate;
            CREATETERMINALID = createTerminalId;
            EDITUSERID = editUserId;
            EDITDATE = editDate;
            EDITTERMINALID = editTerminalId;
        }
    }
}
