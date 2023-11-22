
namespace MauiPractice;
using System.Net.Http.Json;


public class NetworkService {

    private readonly HttpClient client;

    public NetworkService(HttpClient client) {
        this.client = client;
    }

   public async Task<List<JsonInfo>> GetJsonData()
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