using System;

namespace klts.app.mxform.admin
{
    public partial class MediaInfo
    {
        public int MediaDetailID { get; set; }
        public Guid TenantID { get; set; }
        public int? ActivityID { get; set; }
        public int? EventID { get; set; }
        public string UploadType { get; set; }
        public string Url { get; set; }
    }
}