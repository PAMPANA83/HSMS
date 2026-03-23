namespace HSMS.Domain.Domains
{
    public class CountryMasters
    {
        public int? Id { get; set; }

        public string? CountryCode { get; set; }

        public string? CountryName { get; set; }

        public int? CreateUserId { get; set; }

        public DateTime? CreateDate { get; set; }

        public string? CreateTerminalId { get; set; }

        public int? EditUserId { get; set; }

        public DateTime? EditDate { get; set; }

        public string? EditTerminalId { get; set; }
        public int? ID { get; set; }

        public CountryMasters(int? id, string? countryCode, string? name, int? createUserId, DateTime? createDate, string? createTerminalId, int? editUserId, DateTime? editDate, string? editTerminalId)
        {
            Id = id;
            CountryCode = countryCode;
            CountryName = name;
            CreateUserId = createUserId;
            CreateDate = createDate;
            CreateTerminalId = createTerminalId;
            EditUserId = editUserId;
            EditDate = editDate;
            EditTerminalId = editTerminalId;
        }
    }
}
