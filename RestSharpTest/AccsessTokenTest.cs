using Newtonsoft.Json;
using Shouldly;
using simpleApp;
using simpleApp.Model;
using System.Net;

namespace RestSharpTest
{
    public class AccsessTokenTest
    {
        [Fact]
        public async void UserEmpty()
        {

            // Arrange
            var Http =  new Authenticator("https://192.168.88.51:44357", "", "Aa@123456");

            // Act
            var Request  = await Http.LogIn();
            
            var Respons = JsonConvert.DeserializeObject<ErrorMessage>(Request.Content);
            //Assert
            Respons.error_description.ShouldBe("The mandatory 'username' and/or 'password' parameters are missing.");
        }
        [Fact]
        public async void PasswordEmpty()
        {
            // Arrange
            var Http = new Authenticator("https://192.168.88.51:44357", "agent1", "");

            // Act
            var Request = await Http.LogIn();

            var Respons = JsonConvert.DeserializeObject<ErrorMessage>(Request.Content);
            //Assert
            Respons.error_description.ShouldBe("The mandatory 'username' and/or 'password' parameters are missing.");
        }
        [Fact]
        public async void UserNotFound()
        {
            var Http = new Authenticator("https://192.168.88.51:44357","test","Aa@123456");

            var Request = await Http.LogIn();

            var Respons = JsonConvert.DeserializeObject<ErrorMessage>(Request.Content);

            Respons.error_description.ShouldBe("Invalid username or password!");
        }
        [Fact]
        public async void ResponsTokenNotNull()
        {
            var Http = new Authenticator("https://192.168.88.51:44357", "agent1", "Aa@123456");

            var Request = await Http.LogIn();
            var Respons = JsonConvert.DeserializeObject<TokenResponse>(Request.Content);

            Respons.access_token.ShouldNotBeNull();
        }
        [Fact]
        public async void ResponsOfLogInRequestStatusCodShoudByOk()
        {
            var Http = new Authenticator("https://192.168.88.51:44357", "agent1", "Aa@123456");

            var Respons = await Http.LogIn();

            Respons.StatusCode.ShouldBe(HttpStatusCode.OK);
        }
    }
}