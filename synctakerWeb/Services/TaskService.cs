using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using synctakerWeb.Models;
using System.Security.Cryptography;
using System.Text;

public class TaskService
{
    private readonly HttpClient _httpClient;

    public TaskService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ApiClient");
    }

    public async Task<List<TaskModel>> GetTasksAsync()
    {
        //var tasks = await _httpClient.GetFromJsonAsync<List<TaskModel>>("Task");
        return await _httpClient.GetFromJsonAsync<List<TaskModel>>("Task");
    }
}