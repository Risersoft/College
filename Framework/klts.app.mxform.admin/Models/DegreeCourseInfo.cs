using System;
using System.Collections.Generic;

namespace klts.app.mxform.admin
{
    public class DegreeCourseInfo
    {
        public int DegreeCourseID { get; set; }
        public Guid TenantID { get; set; }
        public string Course { get; set; }
        public bool? SemesterWise { get; set; }
        public string MinQual { get; set; }
        public string Seats { get; set; }
        public string Fees { get; set; }
        public string CourseType { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public int? DurationMonth { get; set; }
        public int? DurationYear { get; set; }
        public int? CompanyID { get; set; }
        public List<SubjectInfo> Subjects { get; set; }
    }

    public class FinYearsInfo
    {
        public int FinYearID { get; set; }
        public Guid TenantID { get; set; }
        public DateTime? StDate { get; set; }
        public DateTime? EnDate { get; set; }
        public string Descrip { get; set; }
    }
}