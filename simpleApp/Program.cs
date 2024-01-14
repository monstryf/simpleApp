using RestSharp;
using RestSharp.Authenticators;
using simpleApi.Model.DTOs;
using simpleApp;
using System;
//var http = new Authenticator("https://api.twitter.com", "AgentApp", "password", "agent1", "Aa@123456");

/*
var options = new RestClientOptions()
{
    Authenticator = new Authenticator("https://192.168.88.51:44355", "AgentApp", "password", "agent1", "Aa@123456")
};
var client = new RestClient(options);
var request = new RestRequest("https://192.168.88.51:44355");
//request.AddParameter("client_id", "AgentApp");
//request.AddParameter("grant_type", "password");
*//*request.AddParameter("username", "agent1");
request.AddParameter("password", "Aa@123456");*//*
var response = await client.ExecuteAsync(request);*/
//Console.WriteLine(response.Content);
var options = new RestClientOptions("https://192.168.88.51:44355")
{
    MaxTimeout = -1,
};
var client = new RestClient(options);
var request = new RestRequest("/auth/connect/token", Method.Post);

request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
request.AddHeader("Cookie", ".AspNetCore.Antiforgery.37GpyJUkrrc=CfDJ8B2_SAJHrtdKsMClS69ufbkLvGOiJdExm7vUguqqyF35RTI29KCGzIocAf5ZwvMOIlq8koqrgiuNeOLn3Ldev6Twi5FpcZcpC7lbIAHYA6AlHJ-YQZe8HLMbTE7dg-LyOtTyiVkt82zTD_1Ke7jszeU; XSRF-TOKEN=CfDJ8B2_SAJHrtdKsMClS69ufblYouGzzE5wuNa0Jj1jnGSnTK9qKZrjfhSU1fSXjKEsI8tI54lnpDqpL9Op-rtRqt-l0SWYjXGZ9meWjHVTBVfbDjFDS-RrsFWzjnChUigrQ9XrlkY730fq-vo5J4tqu7Q");
request.AddParameter("client_id", "AgentApp");
request.AddParameter("grant_type", "password");
request.AddParameter("username", "agent1");
request.AddParameter("password", "Aa@123456");
RestResponse response = await client.PostAsync(request);
Console.WriteLine(response.Content);