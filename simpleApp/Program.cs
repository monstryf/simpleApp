using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using simpleApi.Model.DTOs;
using simpleApp;
using simpleApp.Model;
var Http = new HttpClint();
var Login = await Http.Login("agent1", "Aa@123456");
var res = Login;
var ProductsLookup = await Http.Get<ListModel<Products>>("billpayment/", "payments/", "product-lookup");
var Articles = await Http.GetById<List<Articles>>("billpayment/", "payments/", "articles-lookup", "productCode", "Sabafon.PrePaid.TopUp");
Articles.ForEach(x =>
{
    Console.WriteLine(x);
});
var Heid = false;
if (Heid)
{
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
}
