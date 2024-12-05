using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using synctakerWeb.Models;
using System.Security.Cryptography;
using System.Text;

public class StatusService
{
    private readonly HttpClient _httpClient;

    public StatusService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ApiClient");
    }

    public async Task<List<Status>> GetStatusesAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Status>>("Status");
    }
}