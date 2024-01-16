using simpleApp;
using simpleApp.Model;

namespace RestSharpTest
{
    public class AccsessTokenTest
    {
        [Fact]
        public async void UserEmpty()
        {
            // Arrange
            var http =  new Authenticator("https://192.168.88.51:44357", "", "Aa@123456");

            // Act
            var resolte  = await http.LogIn<ErrorMessage>();
            //Assert
            Assert.True(resolte.error_description.Equals("The mandatory 'username' and/or 'password' parameters are missing."));
        }
        [Fact]
        public async void PasswordEmpty()
        {
            // Arrange
            var http = new Authenticator("https://192.168.88.51:44357", "agent1", "");

            // Act
            var resolt = await http.LogIn<ErrorMessage>();
            //Assert
            Assert.True(resolt.error_description.Equals("The mandatory 'username' and/or 'password' parameters are missing."));
        }
        [Fact]
        public async void UserNotFound()
        {

        }
    }
}