using System;

namespace klts.app.mxform.admin
{
    public class SubjectInfo
    {
        public int SubjectID { get; set; }
        public Guid TenantID { get; set; }
        public int? DeptID { get; set; }
        public int? DegreeCourseID { get; set; }
        public string SubjectName { get; set; }
        public int? Semester { get; set; }
        public int? Year { get; set; }
        public string PaperCode { get; set; }
        public string Objective { get; set; }
        public string Syllabus { get; set; }
        public string RefBooks { get; set; }
        public string BedSubType { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string Language { get; set; }
        public string Category { get; set; }
    }
}