using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using synctakerWeb.Models;
using System.Security.Cryptography;
using System.Text;
using synctakerWeb.Components.Pages.Tasks;

public class TaskService
{
    private readonly HttpClient _httpClient;

    public enum TaskSpecifiedStatus
    {
        Assigned,
        Realization,
        Review,
        Testing
    }

    public TaskService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ApiClient");
    }

    public async Task<List<TaskModel>> GetTasksAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<TaskModel>>("Task");
    }

    public async Task<List<TaskModel>> GetSpecifiedTasksAsync(TaskSpecifiedStatus taskSpecifiedStatus, int userId)
    {
        string endpoint = $"Task/status/{userId}?status={taskSpecifiedStatus}";

        return await _httpClient.GetFromJsonAsync<List<TaskModel>>(endpoint);
    }

    public async Task<TaskModel> GetTaskByIdAsync(int taskId)
    {
        return await _httpClient.GetFromJsonAsync<TaskModel>($"Task/task/{taskId}");
    }

    public async Task<int> SaveTaskAsync(TaskSaveRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("Task/save", request);
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadFromJsonAsync<SaveTaskResponse>();

        return responseBody?.TaskId ?? 0;
    }

    public class SaveTaskResponse
    {
        public int TaskId { get; set; }
    }
}