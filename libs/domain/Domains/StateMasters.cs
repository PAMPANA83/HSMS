using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Domain.Domains
{
    public class StateMasters
    {

        public int? ID { get; set; }
        public string? stateID { get; set; }
        public string? StateName { get; set; }
        public int? StateCode { get; set; }
        public int? CountryID { get; set; }
        public int? CREATEUSERID { get; set; }
        public DateTime? CREATEDATE { get; set; }
        public string? CREATETERMINALID { get; set; }
        public int? EDITUSERID { get; set; }
        public DateTime? EDITDATE { get; set; }
        public string? EDITTERMINALID { get; set; }

        public StateMasters(int? id, string? stateId, string? statename, int? statecode, int? countryid,
                           int? userid, DateTime? createdate, string? cTerminalid, int? eUserid, DateTime? edatetime,
                           string? eTerminalid)
        {
            ID = id;
            stateID = stateId;
            StateName = statename;
            StateCode = statecode;
            CountryID = countryid;
            CREATEUSERID = userid;
            CREATEDATE = createdate;
            CREATETERMINALID = cTerminalid;
            EDITUSERID = eUserid;
            EDITDATE = edatetime;
            EDITTERMINALID = eTerminalid;

        }
    }
}
