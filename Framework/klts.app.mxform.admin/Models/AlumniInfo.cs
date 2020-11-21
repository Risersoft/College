using System;

namespace klts.app.mxform.admin
{
    public class AlumniInfo
    {
        public int AlumniID { get; set; }
        public Guid TenantID { get; set; }
        public int? CompanyID { get; set; }
        public int? FinYearID { get; set; }
        public int? DegreeCourseID { get; set; }
        public string Subject1 { get; set; }
        public string Subject2 { get; set; }
        public string Subject3 { get; set; }
        public string JobProfile { get; set; }
        public string JobProfileDetail { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string StudentVoice { get; set; }
        public string PicAlumni { get; set; }
        public byte[] bPicAlumni { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsApproved { get; set; }
        public string Course { get; set; }
    }
}