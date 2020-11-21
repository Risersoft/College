using System;

namespace klts.app.mxform.admin
{
    public class NAACInfo
    {
        public int NaacID { get; set; }
        public Guid TenantID { get; set; }
        public int? CompanyID { get; set; }
        public string Session { get; set; }
        public string IQAC { get; set; }
        public string AQAR { get; set; }
        public string SSR { get; set; }
        public string AgendaMinutes { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string Descrip { get; set; }
    }
}