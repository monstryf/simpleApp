using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;

using simpleApp;
using simpleApp.GenericsType;
using simpleApp.Model;
using simpleApp.SimpleApi;
var Heid = false;
/// restSharp
if (Heid)
{
var Http = new HttpClint();
var Login = await Http.Login("agent1", "Aa@123456");
var res = Login;
var ProductsLookup = await Http.Get<ListModel<Products>>("billpayment/", "payments/", "product-lookup");
var Articles = await Http.GetById<List<Articles>>("billpayment/", "payments/", "articles-lookup", "productCode", "Sabafon.PrePaid.TopUp");
Articles.ForEach(x =>
{
    Console.WriteLine(x);
});
}
/// SimpleApi
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
/// GenericsType 

// Implement The BetterList class Type Int
BetterList<int> intList = new();
// Add item to the list of type int
intList.AddToList(1);
// Implement The BetterList class Type PersonRecord
BetterList<PersonRecord> people = new();
// Add item to the list of type PersonRecord
people.AddToList(new("John", "Doe"));

// Implement The SampleClass class Type Person and int
SampleClass<PersonModel, int> sample;
// Implement The MoreSampleClass class Type  int
MathOperations<int> intMath = new();
// Add two numbers of type int
Console.WriteLine(intMath.Add(1, 4));
// Implement The MoreSampleClass class Type  double
MathOperations<double> doubleMath = new();
// Add two numbers of type double
Console.WriteLine(doubleMath.Add(1.5, 4.3));
class PersonModel
{
    public int Id { get; set; }
    public PersonModel()
    {

    }
    public PersonModel(int startingId)
    {

    }
}
record PersonRecord(string FirstName, string LastName);