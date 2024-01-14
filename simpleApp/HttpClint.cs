using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleApp
{
    internal class HttpClint
    {
        private readonly string Url = "https://192.168.88.51:44355";
        public async Task<RestResponse> LogIn(string ClientId, string GrantType, string UserName, string Password)
        {
            var options = new RestClientOptions(Url)
            {
            Authenticator = new HttpBasicAuthenticator(ClientId, GrantType),
            };
            using var client = new RestClient(options);

            var request = new RestRequest("/auth/connect/token", Method.Post);
          /*  request.AddParameter("client_id", "AgentApp");
            request.AddParameter("grant_type", "password");*/
            request.AddParameter("username", "agent1");
            request.AddParameter("password", "Aa@123456");
            RestResponse response = await client.ExecuteAsync(request);
            var dataTest = response;
            return response;
        }
    public async Task<T> Get<T>(string moduleType)
        {
            var options = new RestClient(Url+moduleType);
            var request = new RestRequest("get_all");
            var response = await options.GetAsync<T>(request);
            return response;
        }
        public async Task<T> GetById<T>(string ModuleType,string Id)
        {
            var options = new RestClient(Url+ModuleType);
            var request = new RestRequest("get_by_id").AddParameter("Id", Id);
            var response = await options.GetAsync<T>(request);
            return response;
        }
        public async Task<T> Post<T>(string ModuleType, params T[] body)
        {
            var options = new RestClient(Url+ModuleType);
           var request = new RestRequest("create");
            request.AddJsonBody(body);
           var response = await options.PostAsync<T>(request);
            return response;
        }
        public async Task<T> Put<T>(string ModuleType, string Id, params T[] body)
        {
            var options = new RestClient(Url + ModuleType);
            var request = new RestRequest("create").AddParameter("Id", Id);
            request.AddJsonBody(body);
            var response = await options.PostAsync<T>(request);
            return response;
        }
    }
}
