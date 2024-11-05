using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using synctakerWeb.Models;

public class UserService
{
    private readonly HttpClient _httpClient;

    public UserService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ApiClient");
    }

    public async Task<User> GetUserAsync()
    {
        return await _httpClient.GetFromJsonAsync<User>("User");
    }
}