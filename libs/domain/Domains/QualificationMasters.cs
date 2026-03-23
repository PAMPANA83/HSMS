using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.Domain.Domains
{
    public class QualificationMasters
    {

        public int? ID { get; set; }
        public string? QualificationID { get; set; }
        public string? QualificationName { get; set; }
        public int? CREATEUSERID { get; set; }
        public DateTime? CREATEDATE { get; set; }
        public string? CREATETERMINALID { get; set; }
        public string? EDITUSERID { get; set; }
        public DateTime? EDITDATE { get; set; }
        public string? EDITTERMINALID { get; set; }

        public QualificationMasters(int? id, string? qualificationID, string? qualificationName, int? cREATEUSERID, DateTime? cREATEDATE, string? cREATETERMINALID, string? eDITUSERID, DateTime? eDITDATE, string? eDITTERMINALID)
        {
            ID = id;
            QualificationID = qualificationID;
            QualificationName = qualificationName;
            CREATEUSERID = cREATEUSERID;
            CREATEDATE = cREATEDATE;
            CREATETERMINALID = cREATETERMINALID;
            EDITUSERID = eDITUSERID;
            EDITDATE = eDITDATE;
            EDITTERMINALID = eDITTERMINALID;
        }
    }
}
