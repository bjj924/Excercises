using ExternalEndpointsCalls_HttpClient;
using System.Text;
using System.Text.Json;

var json = new Posts();

var url = new Uri("https://jsonplaceholder.typicode.com/posts");

var postData = new Posts
{
    body = "Test Body POST",
    title = "Test Title POST",
};

var jsonPostData = JsonSerializer.Serialize(postData);
var content = new StringContent(jsonPostData, Encoding.UTF8, "application/json");

using (HttpClient client = new HttpClient())
{
    var result = client.PostAsync(url, content).Result;

    if (result.IsSuccessStatusCode)
    {
        var responseContent =  result.Content.ReadAsStringAsync().Result;

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        json = JsonSerializer.Deserialize<Posts>(responseContent, options);

        Console.WriteLine("Post Created Succesfully:");
        Console.WriteLine($"Id: {json.id}, Tittle: {json.title} and Body: {json.body}");

    }
    else
    {
        Console.WriteLine($"Error {result.StatusCode}");
    }
}

var urlPUT = new Uri($"https://jsonplaceholder.typicode.com/posts/{json.id}");

var putData = new Posts
{
    body = "Test Body PUT",
    title = "Test Title PUT",
};

var jsonPUTData = JsonSerializer.Serialize(putData);
var contentPUT = new StringContent(jsonPUTData, Encoding.UTF8, "application/json");

using (HttpClient client2 = new HttpClient())
{
    var updateCall = client2.PutAsync(urlPUT, contentPUT).Result;

    if (updateCall.IsSuccessStatusCode)
    {
        var responseContent = updateCall.Content.ReadAsStringAsync().Result;

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var jsonPUT = JsonSerializer.Deserialize<Posts>(responseContent, options);

        Console.WriteLine("Post Created Succesfully:");
        Console.WriteLine($"Id: {jsonPUT.id}, Tittle: {jsonPUT.title} and Body: {jsonPUT.body}");

    }
    else
    {
        Console.WriteLine($"Error PUT: {updateCall.StatusCode}");
    }

}