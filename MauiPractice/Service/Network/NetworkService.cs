
using MauiPractice.Model;
using System.Net.Http.Json;
namespace MauiPractice.Service.Network;
public class NetworkService : INetworkService {
   private readonly HttpClient client = new HttpClient();
   public async Task<List<JsonInfo>> GetJsonDataAsync()
    {
        try
        {
            string url = "https://jsonplaceholder.typicode.com/posts";
            List<JsonInfo> items = await client.GetFromJsonAsync<List<JsonInfo>>(url);

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            return items;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return new List<JsonInfo>(); 
        }
    }
}    