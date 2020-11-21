using System;
using System.Collections.Generic;

namespace klts.app.mxform.admin
{
    public partial class ActivityInfo
    {
        public int ActivityID { get; set; }
        public Guid TenantID { get; set; }
        public string Name { get; set; }
        public string Nature { get; set; }
        public int? DeptID { get; set; }
        public DateTime? Dated { get; set; }
        public string PurposeHTML { get; set; }
        public string PurposeText { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? CompanyID { get; set; }
        public string DescriptionHTML { get; set; }
        public string DescriptionText { get; set; }
        public string Descrip { get; set; }
        public string OrganizedBy { get; set; }
        public string Place { get; set; }
        public string NatureDescrip { get; set; }
        public List<MediaInfo> Media { get; set; } = new List<MediaInfo>();
    }
}