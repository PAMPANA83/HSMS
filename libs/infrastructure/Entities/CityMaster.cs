using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSMS.infrastructure.Entities
{
    [Table("tblCityMaster")]
    public class CityMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string? CityID { get; set; }
        public string? CityName { get; set; }
        public int? DistrictID { get; set; }
        public int? CREATEUSERID { get; set; }
        public DateTime? CREATEDATE { get; set; }
        public string? CREATETERMINALID { get; set; }
        public int? EDITUSERID { get; set; }
        public DateTime? EDITDATE { get; set; }
        public string? EDITTERMINALID { get; set; }
    }
}
