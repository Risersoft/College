using System;
using System.Collections.Generic;

namespace klts.app.mxform.admin
{
    public class CommitteeInfo
    {
        public Guid TenantID { get; set; }
        public int? CommitteeID { get; set; }
        public int? CompanyID { get; set; }
        public string Name { get; set; }
        public bool? IsManagement { get; set; }
        public DateTime? CommSdate { get; set; }
        public DateTime? CommEdate { get; set; }
        public string CommitteeCode { get; set; }
        public string DescriptionText { get; set; }
        public string DescriptionHTML { get; set; }
        public List<CommitteeMemberInfo> Members { get; set; }
    }

    public class CommitteeMemberInfo
    {
        public int CommitteeMemberID { get; set; }
        public Guid TenantID { get; set; }
        public int? CommitteeID { get; set; }
        public int? PersonID { get; set; }
        public int? Deptid { get; set; }
        public int? Rank { get; set; }
        public DateTime? Sdate { get; set; }
        public DateTime? Edate { get; set; }
        public string FullName { get; set; }
        public string Occupation { get; set; }
        public string CommDesig { get; set; }
        public string ImageUrl { get; set; }
    }
}