

using MauiPractice.Model;
namespace MauiPractice.Service;

public interface INetworkService
{
      Task<List<JsonInfo>> GetJsonDataAsync();
}