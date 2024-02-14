using RestSharp.Authenticators;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace simpleApp.RestSharp
{
    /// <summary>
    /// it is for Authentication User 
    /// </summary>
    public class Authenticator : AuthenticatorBase
    {
        readonly string BaseUrl;
        readonly string ClientId;
        readonly string GrantType;
        readonly string UserName;
        readonly string Password;


        static Authenticator()
        {

        }
        public Authenticator(string baseUrl, string UserName, string Password) : base("")
        {
            BaseUrl = baseUrl;
            ClientId = "AgentApp";
            GrantType = "password";
            this.UserName = UserName;
            this.Password = Password;

        }

        /// <summary>
        /// Get Token For LogIn Request
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        protected override async ValueTask<Parameter> GetAuthenticationParameter(string AccessToken)
        {
            var respons = await LogIn();
            var Token = JsonConvert.DeserializeObject<TokenResponse>(respons.Content);

            return new HeaderParameter(KnownHeaders.Authorization, Token.access_token);
        }
        /// <summary>
        /// Use To LogIn
        /// </summary>
        /// <returns></returns>
        public async Task<RestResponse> LogIn()
        {
            var Options = new RestClientOptions(BaseUrl);
            //For Angora The SSl 
            Options.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
            {
                return true;
            };
            // get Client Secret
            var Request = new RestRequest("/auth/connect/token", Method.Post);
            var Hmac = HMAC(Request.Method.ToString(), Request.Resource);
            using var Client = new RestClient(Options);
            Request.AddHeader("X-HMAC", Hmac);
            Request.AddParameter("client_id", ClientId);
            Request.AddParameter("grant_type", GrantType);
            Request.AddParameter("username", UserName);
            Request.AddParameter("password", Password);
            Request.AddParameter("scope", "profile roles email phone AgentAppServices");
            var response = await Client.ExecuteAsync(Request);
            return response;
        }
        /// <summary>
        /// Use For Generate Client Secret
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="userName"></param>
        /// <param name="_password"></param>
        /// <returns></returns>
        private string HMAC(string Method, string GetPath)
        {

            string AppId = "4dfe3e50c45240e8901cf0b3e3cc3a3a";
            string AppSecret = "AgOmASinx7My06IfEiAXkc6apFmyUSp84q7s2Hs3aik=";
            long ReqDate = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            string Nonce = Guid.NewGuid().ToString();

            // Check if client_secret is required and construct bodyRaw
            string BodyRaw = $"{ClientId}{UserName}{Password}";
            var Data = $"{ReqDate}\n{BodyRaw}\n{Method}\n{GetPath}\n{string.Empty}".ToLower();
            byte[] SignBytes = new HMACSHA256(Encoding.ASCII.GetBytes(AppSecret)).ComputeHash(Encoding.ASCII.GetBytes(Data));
            string SignString = Convert.ToBase64String(SignBytes);
            string HmacValue = $"{AppId}:{SignString}:{ReqDate}:{Nonce}";
            return HmacValue;
        }
    }
}
