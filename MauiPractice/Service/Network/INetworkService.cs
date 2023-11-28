

using MauiPractice.Model;
namespace MauiPractice.Service.Network;

public interface INetworkService
{
      Task<List<JsonInfo>> GetJsonDataAsync();
}