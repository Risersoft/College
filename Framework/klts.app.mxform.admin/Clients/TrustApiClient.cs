using System.Collections.Generic;
using global::System.Net;
using System.Threading.Tasks;
using global::risersoft.shared;

namespace klts.app.mxform.admin
{
    public class TrustApiClient
    {
        private WebApiClientToken client;

        public TrustApiClient(string ClientId, string ClientSecret, string LoginServiceHost, string RestServiceHost)
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

        public async Task<ResultInfo<List<CommitteeMemberInfo>, HttpStatusCode>> GetCommitteeMembers(string Code)
        {
            var params2 = new Dictionary<string, string>();
            params2.Add("Code", Code);
            using (var client = await InitApiClient())
            {
                client.PrepareQueryString(RestServiceHost + "/api/data/committee", params2);
                var _info2 = client.Get<ResultInfo<List<CommitteeMemberInfo>, HttpStatusCode>>();
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

        public async Task<ResultInfo<CollegeInfo, HttpStatusCode>> GetTrustInfo(string Code)
        {
            var params2 = new Dictionary<string, string>();
            params2.Add("Code", Code);
            using (var client = await InitApiClient())
            {
                client.PrepareQueryString(RestServiceHost + "/api/data/trust", params2);
                var _info2 = client.Get<ResultInfo<CollegeInfo, HttpStatusCode>>();
                return _info2;
            }
        }
    }
}