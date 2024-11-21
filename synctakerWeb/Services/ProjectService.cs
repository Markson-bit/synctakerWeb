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

    public async Task<List<Project>> GetProjectsAsync()
    {
        var projects = await _httpClient.GetFromJsonAsync<List<Project>>("Project");
        return await _httpClient.GetFromJsonAsync<List<Project>>("Project");
    }

    public async Task<bool> DeleteProjectAsync(int projectId)
    {
        var response = await _httpClient.DeleteAsync($"Project/{projectId}");
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateProjectAsync(int projectId, ProjectCreateRequest request)
    {
        var response = await _httpClient.PutAsJsonAsync($"Project/update/{projectId}", request);
        return response.IsSuccessStatusCode;
    }
}