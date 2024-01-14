using RestSharp;
using simpleApi.Model.DTOs;
using simpleApp;

namespace simpleApi.Model.DTOs
{
    internal class UserDTOS
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual AddressDTOs? Address { get; set; } = default!;
    }
}

/*HttpClint httpClint = new HttpClint();

//var respons = httpClint.LogIn("AgentApp", "password", "agent1", "Aa@123456");
var option = new RestClientOptions("https://192.168.88.51:44355");
using var client = new RestClient(option);

var requests = new RestRequest("/auth/connect/token", Method.Post);
requests.AddParameter("client_id", "AgentApp");
requests.AddParameter("grant_type", "password");
requests.AddParameter("username", "agent1");
requests.AddParameter("password", "Aa@123456");
RestResponse responses = await client.ExecuteAsync(requests);
Console.WriteLine(responses);
var user = new UserDTOS();
var address = new AddressDTOs();
var options = new RestClient("http://localhost:5274/api/user");
var request = new RestRequest("get_all");
var response = await options.GetAsync(request);
Console.WriteLine(response.Content);
Console.Write("Do you want create New User? y/n ");
var q = Console.ReadLine();
if (q.Equals("n"))
{
    return;
}
Console.Write("name: ");
user.Name = Console.ReadLine();
Console.Write("userName: ");
user.UserName = Console.ReadLine();
Console.Write("email: ");
user.Email = Console.ReadLine();
Console.Write("password: ");
user.Password = Console.ReadLine();
Console.Write("add Address? y/n: ");
var addAdress = Console.ReadLine();
if (addAdress.Equals("y"))
{
    Console.Write("location: ");
    address.Location = Console.ReadLine();
    Console.Write("location: ");
    address.Location = Console.ReadLine();
    Console.Write("Description: ");
    address.Description = Console.ReadLine();
    Console.Write("Latitude: ");
    address.Latitude = Int16.Parse(Console.ReadLine());
    Console.Write("Longitude: ");
    address.Longitude = Int16.Parse(Console.ReadLine());
}
Console.Write("submet ? y/n: ");
var submet = Console.ReadLine();
if (submet.Equals("n"))
{
    return;
}
request = new RestRequest("create");
request.AddJsonBody(user);
response = options.Post(request);
Console.WriteLine(response.Content);
Console.ReadKey();

*/