using System;

namespace klts.app.mxform.admin
{
    public class NoticeBoardInfo
    {
        public int NoticeBoardID { get; set; }
        public Guid TenantID { get; set; }
        public string Heading { get; set; }
        public DateTime? Dated { get; set; }
        public int? DeptID { get; set; }
        public string TextInternal { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public int? CompanyID { get; set; }
        public string DescripHTML { get; set; }
        public string DescripText { get; set; }
    }
}