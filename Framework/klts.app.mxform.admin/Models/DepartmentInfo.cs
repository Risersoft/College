using System;
using System.Collections.Generic;

namespace klts.app.mxform.admin
{
    public class DepartmentInfo
    {
        public int DeptID { get; set; }
        public Guid TenantID { get; set; }
        public int? CompanyID { get; set; }
        public string DeptName { get; set; }
        public int? HODPersonID { get; set; }
        public int? EstabYear { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string HODName { get; set; }
        public List<PersonInfo> Persons { get; set; } = new List<PersonInfo>();
    }
}