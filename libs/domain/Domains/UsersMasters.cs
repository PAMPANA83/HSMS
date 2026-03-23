namespace HSMS.Domain.Domains
{
    public class UsersMasters
    {
        public int? ID { get; set; }
        public int? EmpId { get; set; }
        public int? UserID { get; set; }
        public string? Password { get; set; }
        public string? UCODE { get; set; }
        public int RoleID { get; set; }
        public int? ConcAmt { get; set; }
        public int? DUEPERC { get; set; }
        public string FPImage { get; set; }
        public string? Address { get; set; }
        public string? Mobile { get; set; }
        public string? EmailID { get; set; }
        public int? BranchID { get; set; }
        public int? CREATEUSERID { get; set; }
        public string? CREATEDATE { get; set; }
        public string? CREATETERMINALID { get; set; }
        public int? EDITUSERID { get; set; }
        public string? EDITDATE { get; set; }
        public string? EDITTERMINALID { get; set; }      

        public UsersMasters(int iD, int? userID, string? password, string? uCODE, int roleID, int? concAmt, int? dUEPERC, string fPImage, string? address, string? mobile, string? emailID, int? branchID, int? cREATEUSERID, string? cREATEDATE, string? cREATETERMINALID, int? eDITUSERID, string? eDITDATE, string? eDITTERMINALID)
        {
            ID = iD;
            UserID = userID;
            Password = password;
            UCODE = uCODE;
            RoleID = roleID;
            ConcAmt = concAmt;
            DUEPERC = dUEPERC;
            FPImage = fPImage;
            Address = address;
            Mobile = mobile;
            EmailID = emailID;
            BranchID = branchID;
            CREATEUSERID = cREATEUSERID;
            CREATEDATE = cREATEDATE;
            CREATETERMINALID = cREATETERMINALID;
            EDITUSERID = eDITUSERID;
            EDITDATE = eDITDATE;
            EDITTERMINALID = eDITTERMINALID;
        }
    }
}
