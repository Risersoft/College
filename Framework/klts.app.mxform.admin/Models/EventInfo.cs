using System;
using System.Collections.Generic;

namespace klts.app.mxform.admin
{
    public partial class EventInfo
    {
        public int EventID { get; set; }
        public Guid TenantID { get; set; }
        public int? CompanyID { get; set; }
        public int? DeptID { get; set; }
        public string EventName { get; set; }
        public DateTime? Sdate { get; set; }
        public string EventType { get; set; }
        public string PurposeHTML { get; set; }
        public string PurposeText { get; set; }
        public string Summary { get; set; }
        public string Place { get; set; }
        public string SaarthakYear { get; set; }
        public bool? IsSarthak { get; set; }
        public string SarthakText { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string Brochure { get; set; }
        public string DescriptionHTML { get; set; }
        public string DescriptionText { get; set; }
        public string OrganizedBy { get; set; }
        public string Descrip { get; set; }
        public string EventTypeDescrip { get; set; }
        public List<MediaInfo> Media { get; set; } = new List<MediaInfo>();
    }
}