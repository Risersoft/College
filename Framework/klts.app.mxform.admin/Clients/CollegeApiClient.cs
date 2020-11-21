using System.Collections.Generic;
using global::System.Net;
using System.Threading.Tasks;
using global::risersoft.shared;

namespace klts.app.mxform.admin
{
    public class CollegeApiClient
    {
        private WebApiClientToken client;

        public CollegeApiClient(string ClientId, string ClientSecret, string LoginServiceHost, string RestServiceHost)
        {
            this.ClientId = ClientId;
            this.ClientSecret = ClientSecret;
            this.LoginServiceHost = LoginServiceHost;
            this.RestServiceHost = RestServiceHost;
        }

        protected internal virtual string ClientId { get; set; } = "";
        protected internal virtual string ClientSecret { get; set; }
        protected internal virtual string RestServiceHost { get; set; }
        protected internal virtual string LoginServiceHost { get; set; }

        protected internal async Task<WebApiClientToken> InitApiClient()
        {
            if (client is null)
            {
                var provider = new clsClientCredTokenProvider(ClientId, ClientSecret, LoginServiceHost, true);
                var token = await provider.AuthenticateAsync();
                client = new WebApiClientToken(provider.ClientId, provider.TokenResponse.AccessToken);
            }

            return client;
        }

        public async Task<ResultInfo<List<CommitteeInfo>, HttpStatusCode>> GetCommitteeMembers(string Code)
        {
            var params2 = new Dictionary<string, string>();
            params2.Add("Code", Code);
            using (var client = await InitApiClient())
            {
                client.PrepareQueryString(RestServiceHost + "/api/data/committee", params2);
                var _info2 = client.Get<ResultInfo<List<CommitteeInfo>, HttpStatusCode>>();
                return _info2;
            }
        }

        public async Task<ResultInfo<List<DegreeCourseInfo>, HttpStatusCode>> GetDegreeCourses(string Code)
        {
            var params2 = new Dictionary<string, string>();
            params2.Add("Code", Code);
            using (var client = await InitApiClient())
            {
                client.PrepareQueryString(RestServiceHost + "/api/data/courses", params2);
                var _info2 = client.Get<ResultInfo<List<DegreeCourseInfo>, HttpStatusCode>>();
                return _info2;
            }
        }

        public async Task<ResultInfo<List<SubjectInfo>, HttpStatusCode>> GetSubjects(string CollegeCode, string CourseCode)
        {
            var params2 = new Dictionary<string, string>();
            params2.Add("CollegeCode", CollegeCode);
            params2.Add("CourseCode", CourseCode);
            using (var client = await InitApiClient())
            {
                client.PrepareQueryString(RestServiceHost + "/api/data/subjects", params2);
                var _info2 = client.Get<ResultInfo<List<SubjectInfo>, HttpStatusCode>>();
                return _info2;
            }
        }

        public async Task<ResultInfo<List<DepartmentInfo>, HttpStatusCode>> GetDeps(string Code)
        {
            var params2 = new Dictionary<string, string>();
            params2.Add("Code", Code);
            using (var client = await InitApiClient())
            {
                client.PrepareQueryString(RestServiceHost + "/api/data/deps", params2);
                var _info2 = client.Get<ResultInfo<List<DepartmentInfo>, HttpStatusCode>>();
                return _info2;
            }
        }

        public async Task<ResultInfo<DepartmentInfo, HttpStatusCode>> GetDeptStaff(string CollegeCode, string DepCode)
        {
            var params2 = new Dictionary<string, string>();
            params2.Add("CollegeCode", CollegeCode);
            params2.Add("DepCode", DepCode);
            using (var client = await InitApiClient())
            {
                client.PrepareQueryString(RestServiceHost + "/api/data/deptstaff", params2);
                var _info2 = client.Get<ResultInfo<DepartmentInfo, HttpStatusCode>>();
                return _info2;
            }
        }

        public async Task<ResultInfo<List<PersonInfo>, HttpStatusCode>> GetNonTeachingStaff(string Code)
        {
            var params2 = new Dictionary<string, string>();
            params2.Add("Code", Code);
            using (var client = await InitApiClient())
            {
                client.PrepareQueryString(RestServiceHost + "/api/data/nonteachingstaff", params2);
                var _info2 = client.Get<ResultInfo<List<PersonInfo>, HttpStatusCode>>();
                return _info2;
            }
        }





        public async Task<ResultInfo<List<PersonInfo>, HttpStatusCode>> GetTeachingStaff(string Code)
        {
            var params2 = new Dictionary<string, string>();
            params2.Add("Code", Code);
            using (var client = await InitApiClient())
            {
                client.PrepareQueryString(RestServiceHost + "/api/data/teachingstaff", params2);
                var _info2 = client.Get<ResultInfo<List<PersonInfo>, HttpStatusCode>>();
                return _info2;
            }
        }

        public async Task<ResultInfo<List<EventInfo>, HttpStatusCode>> GetEvents(string Code, string EventType)
        {
            var params2 = new Dictionary<string, string>();
            params2.Add("Code", Code);
            params2.Add("EventType", EventType);
            using (var client = await InitApiClient())
            {
                client.PrepareQueryString(RestServiceHost + "/api/data/events", params2);
                var _info2 = client.Get<ResultInfo<List<EventInfo>, HttpStatusCode>>();
                return _info2;
            }
        }

        public async Task<ResultInfo<EventInfo, HttpStatusCode>> GetEvent(int Id)
        {
            var params2 = new Dictionary<string, string>();
            params2.Add("Id", Id.ToString());
            using (var client = await InitApiClient())
            {
                client.PrepareQueryString(RestServiceHost + "/api/data/event", params2);
                var _info2 = client.Get<ResultInfo<EventInfo, HttpStatusCode>>();
                return _info2;
            }
        }
        // Return top 100
        public async Task<ResultInfo<List<ActivityInfo>, HttpStatusCode>> GetActivities(string Code)
        {
            var params2 = new Dictionary<string, string>();
            params2.Add("Code", Code);
            using (var client = await InitApiClient())
            {
                client.PrepareQueryString(RestServiceHost + "/api/data/Activities", params2);
                var _info2 = client.Get<ResultInfo<List<ActivityInfo>, HttpStatusCode>>();
                return _info2;
            }
        }

        public async Task<ResultInfo<ActivityInfo, HttpStatusCode>> GetActivity(int Id)
        {
            var params2 = new Dictionary<string, string>();
            params2.Add("Id", Id.ToString());
            using (var client = await InitApiClient())
            {
                client.PrepareQueryString(RestServiceHost + "/api/data/Activity", params2);
                var _info2 = client.Get<ResultInfo<ActivityInfo, HttpStatusCode>>();
                return _info2;
            }
        }

        public async Task<ResultInfo<List<NoticeBoardInfo>, HttpStatusCode>> GetNoticeboard(string Code)
        {
            var params2 = new Dictionary<string, string>();
            params2.Add("Code", Code);
            using (var client = await InitApiClient())
            {
                client.PrepareQueryString(RestServiceHost + "/api/data/noticeboard", params2);
                var _info2 = client.Get<ResultInfo<List<NoticeBoardInfo>, HttpStatusCode>>();
                return _info2;
            }
        }

        public async Task<ResultInfo<NoticeBoardInfo, HttpStatusCode>> GetNotice(int Id)
        {
            var params2 = new Dictionary<string, string>();
            params2.Add("Id", Id.ToString());
            using (var client = await InitApiClient())
            {
                client.PrepareQueryString(RestServiceHost + "/api/data/notice", params2);
                var _info2 = client.Get<ResultInfo<NoticeBoardInfo, HttpStatusCode>>();
                return _info2;
            }
        }

        public async Task<ResultInfo<int, HttpStatusCode>> PostAlumni(AlumniInfo info)
        {
            var params2 = new Dictionary<string, string>();
            using (var client = await InitApiClient())
            {
                client.PrepareQueryString(RestServiceHost + "/api/data/alumni", params2);
                var _info2 = client.Post<AlumniInfo, ResultInfo<int, HttpStatusCode>>(info);
                return _info2;
            }
        }

        // Return top 100
        public async Task<ResultInfo<List<AlumniInfo>, HttpStatusCode>> GetAlumni(string Code)
        {
            var params2 = new Dictionary<string, string>();
            params2.Add("Code", Code);
            using (var client = await InitApiClient())
            {
                client.PrepareQueryString(RestServiceHost + "/api/data/alumni", params2);
                var _info2 = client.Get<ResultInfo<List<AlumniInfo>, HttpStatusCode>>();
                return _info2;
            }
        }
        // Return top 100

        public async Task<ResultInfo<List<NAACInfo>, HttpStatusCode>> GetNAAC(string Code)
        {
            var params2 = new Dictionary<string, string>();
            params2.Add("Code", Code);
            using (var client = await InitApiClient())
            {
                client.PrepareQueryString(RestServiceHost + "/api/data/naac", params2);
                var _info2 = client.Get<ResultInfo<List<NAACInfo>, HttpStatusCode>>();
                return _info2;
            }
        }

        public async Task<ResultInfo<CollegeInfo, HttpStatusCode>> GetCollegeInfo(string Code)
        {
            var params2 = new Dictionary<string, string>();
            params2.Add("Code", Code);
            using (var client = await InitApiClient())
            {
                client.PrepareQueryString(RestServiceHost + "/api/data/college", params2);
                var _info2 = client.Get<ResultInfo<CollegeInfo, HttpStatusCode>>();
                return _info2;
            }
        }

        public async Task<ResultInfo<List<FinYearsInfo>, HttpStatusCode>> GetFinYears()
        {
            var params2 = new Dictionary<string, string>();
            using (var client = await InitApiClient())
            {
                client.PrepareQueryString(RestServiceHost + "/api/data/fy", params2);
                var _info2 = client.Get<ResultInfo<List<FinYearsInfo>, HttpStatusCode>>();
                return _info2;
            }
        }
    }
}