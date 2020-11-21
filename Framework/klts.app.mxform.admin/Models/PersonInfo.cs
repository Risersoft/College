using System;

namespace klts.app.mxform.admin
{
    public class PersonInfo
    {
        public int PersonID { get; set; }
        public Guid TenantID { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string MidName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        public string Sex { get; set; }
        public string MarStatus { get; set; }
        public bool? IsFemale { get; set; }
        public string Email { get; set; }
        public string CellNum { get; set; }
        public string Remark { get; set; }
        public string Education { get; set; }
        public string Profile { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? Anniversary { get; set; }
        public string PrAddress { get; set; }
        public string PrCity { get; set; }
        public string PrState { get; set; }
        public string PrCountry { get; set; }
        public string PrPinCode { get; set; }
        public string OfficeCountry { get; set; }
        public string OfficeArea { get; set; }
        public string OfficePhone { get; set; }
        public string PrPhCountry { get; set; }
        public string PrPhArea { get; set; }
        public string PrPhone { get; set; }
        public string PrGeoPoint { get; set; }
        public string Web { get; set; }
        public string PmAddress { get; set; }
        public string PmCity { get; set; }
        public string PmState { get; set; }
        public string PmCountry { get; set; }
        public string PmPinCode { get; set; }
        public string PmPhCountry { get; set; }
        public string PmPhArea { get; set; }
        public string PmPhone { get; set; }
        public string PmGeoPoint { get; set; }
        public byte[] PicPerson { get; set; }
        public byte[] FingerPrint { get; set; }
        public int? TempEmpID { get; set; }
        public string TopQual { get; set; }
        public decimal? OtherExp { get; set; }
        public string PrStateCode { get; set; }
        public string PrCountryCode { get; set; }
        public string PmStateCode { get; set; }
        public string PmCountryCode { get; set; }
        public string PrMailingAddress { get; set; }
        public string PmMailingAddress { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string ModifiedBy { get; set; }
        public int? DeptID { get; set; }
        public string Occupation { get; set; }
        public int? DeptRank { get; set; }
        public string Desig { get; set; }
        public Guid? UserID { get; set; }
        public string Fmode { get; set; }
        public DateTime? Sdate { get; set; }
        public DateTime? Edate { get; set; }
        public DateTime? CommSdate { get; set; }
        public DateTime? CommEdate { get; set; }
        public int? StaffMode { get; set; }
        public int? NonTechStaffRank { get; set; }
        public string NonTeacStaff { get; set; }
        public string StaffDept { get; set; }
        public string Committee { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? AgeYears { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public int? Aadhar { get; set; }
        public string AadharEnrollment { get; set; }
        public string Category { get; set; }
        public string Reservation { get; set; }
        public string EWS { get; set; }
        public string XthMarksSheetSerial { get; set; }
        public string XthPassYear { get; set; }
        public string XIIthRollNum { get; set; }
        public string EnrollmentNum { get; set; }
        public bool? IsStudent { get; set; }
        public string ImageUrl { get; set; }

        public string DeptName { get; set; }
    }
}