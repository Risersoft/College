using System;
using global::Newtonsoft.Json;

namespace klts.app.mxform.admin
{
    public class CollegeInfo
    {
        public int CompanyID { get; set; }
        public string EntityName { get; set; }
        public int EntityID { get; set; }
        public string CompName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PhNum { get; set; }
        public string Web { get; set; }
        public string Email { get; set; }
        public byte[] TCLogo { get; set; }
        [JsonIgnore]
        public string CollegePros { get; set; }
        [JsonIgnore]
        public string AcademicCalender { get; set; }
        public string CollegeProsURL { get; set; }
        public string AcademicCalendarURL { get; set; }
        public string PrincipalMessageHTML { get; set; }
    }

    public class ClsBlobFileInfo
    {
        public string Bloborgname { get; set; }
        public string Blobname { get; set; }
        public double Filesize { get; set; }
        public string Lastmodified { get; set; }
        public Uri BlobUrl { get; set; }
        public string UploadType { get; set; }
        public string Url { get; set; }
    }
}