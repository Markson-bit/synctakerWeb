using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using synctakerWeb.Models;
using System.Security.Cryptography;
using System.Text;

public class ProjectService
{
    private readonly HttpClient _httpClient;

    public ProjectService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ApiClient");
    }

    public async Task<bool> CreateProjectAsync(ProjectCreateRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("Project/create", request);
        return response.IsSuccessStatusCode;
    }
}