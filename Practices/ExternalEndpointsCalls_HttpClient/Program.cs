// See https://aka.ms/new-console-template for more information
using ExternalEndpointsCalls_HttpClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System.Xml.Linq;

Console.WriteLine("Let call an external API from https://jsonplaceholder.typicode.com/!");

Console.WriteLine("The options that we have are: ");
Console.WriteLine("For a GET to all the post, write 'posts'");
Console.WriteLine("For a GET to one post, write '/posts/numberOfThePost' for example 'posts/1'");
Console.WriteLine("For a GET all the comments from a post, write 'posts/numberOfThePost/comments' for example '/posts/1/comments'");
Console.WriteLine();
Console.WriteLine("Write the value Bellow:");
Console.WriteLine();
var value = Console.ReadLine();


var url = new Uri($"https://jsonplaceholder.typicode.com/{value}");

List<Posts> responseList = new();

using (HttpClient httpClient = new HttpClient())
{
    var response = httpClient.GetAsync(url).Result;

    if (response.IsSuccessStatusCode)
    {
        var responseContent = response.Content.ReadAsStringAsync().Result;

        if (value.Contains("posts/"))
        {
            var singleResponse = System.Text.Json.JsonSerializer.Deserialize<Posts>(responseContent);
            Console.WriteLine();
            Console.WriteLine($"Id: {singleResponse.id}");
            Console.WriteLine($"UserId: {singleResponse.userId}");
            Console.WriteLine($"Title: {singleResponse.title}");
            Console.WriteLine($"Body: {singleResponse.body}");
            Console.WriteLine($"--------------------------------------------------------------------------------");
        }
        else
        {
            responseList = System.Text.Json.JsonSerializer.Deserialize<List<Posts>>(responseContent);
        }
        
    }
    else
    {
        Console.WriteLine("Error: " + response.StatusCode);
    }
}

if (responseList.Count > 0)
{
    Console.WriteLine("List of the reponse");

    foreach (var item in responseList)
    {
        Console.WriteLine();
        Console.WriteLine($"Id: {item.id}");
        Console.WriteLine($"UserId: {item.userId}");
        Console.WriteLine($"Title: {item.title}");
        Console.WriteLine($"Body: {item.body}");
        Console.WriteLine($"--------------------------------------------------------------------------------");
    }

}


Console.WriteLine("Get successful!");
Console.ReadKey();