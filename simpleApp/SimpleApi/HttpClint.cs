using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using simpleApp.RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace simpleApp.SimpleApi
{
    public class HttpClint
    {
        private readonly string Url = "https://192.168.88.51:44357/api/";
        private readonly string AuthUrl = "https://192.168.88.51:44357";
        private static string Token;
        public async Task<string> Login(string UserName, string Password)
        {
            var Request = await new Authenticator(AuthUrl, UserName, Password).LogIn();
            var Respons = JsonConvert.DeserializeObject<TokenResponse>(Request.Content);
            Token = Respons.access_token;
            return Token;
        }
        public async Task<T> Get<T>(string ModuleType, string controller, string option)
        {
            var authenticator = new JwtAuthenticator(Token);
            var Options = new RestClientOptions(Url + ModuleType + controller)
            {
                Authenticator = authenticator
            };
            Options.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
            {
                return true;
            };
            var Request = new RestRequest(option);
            using var client = new RestClient(Options);
            var Response = await client.ExecuteAsync<T>(Request);
            return Response.Data;
        }
        public async Task<T> GetById<T>(string ModuleType, string controller, string option, string Key, string Valu)
        {
            var Authenticator = new JwtAuthenticator(Token);
            var Options = new RestClientOptions(Url + ModuleType + controller)
            {
                Authenticator = Authenticator
            };
            Options.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
            {
                return true;
            };
            using var client = new RestClient(Options);
            var Request = new RestRequest(option).AddParameter(Key, Valu);
            var Response = await client.ExecuteAsync<T>(Request);
            return Response.Data;
        }
        public async Task<T> Post<T>(string ModuleType, params T[] Body)
        {
            var Options = new RestClient(Url + ModuleType);
            var Request = new RestRequest("create");
            Request.AddJsonBody(Body);
            var Response = await Options.PostAsync<T>(Request);
            return Response;
        }
        public async Task<T> Put<T>(string ModuleType, string Id, params T[] Body)
        {
            var Options = new RestClient(Url + ModuleType);
            var Request = new RestRequest("create").AddParameter("Id", Id);
            Request.AddJsonBody(Body);
            var Response = await Options.PostAsync<T>(Request);
            return Response;
        }
    }
}
