using RestSharp.Authenticators;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleApp
{
    public class Authenticator : AuthenticatorBase
    {
        readonly string _baseUrl;
        readonly string _clientId;
        readonly string _grantType;
        readonly string _userName;
        readonly string _password;

        public Authenticator(string baseUrl, string clientId, string GrantType,string UserName,string Password) : base("")
        {
            _baseUrl = baseUrl;
            _clientId = clientId;
            _grantType = GrantType;
            _userName = UserName;
            _password = Password;
        }

        protected override async ValueTask<Parameter> GetAuthenticationParameter(string accessToken)
        {
            Token = string.IsNullOrEmpty(Token) ? await GetToken() : Token;
            return new HeaderParameter(KnownHeaders.Authorization, Token);
        }
       async Task<string> GetToken()
        { 
            var options = new RestClientOptions(_baseUrl);
            using var client = new RestClient(options);
            var request = new RestRequest("/auth/connect/token");
            request.AddParameter("client_id", "AgentApp");
            request.AddParameter("grant_type", "password");
            request.AddParameter("username", _userName);
            request.AddParameter("password", _password);
            var response = await client.PostAsync(request);
            return response.Content;
}
    }
}
