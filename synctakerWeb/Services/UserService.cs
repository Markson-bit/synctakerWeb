using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using synctakerWeb.Models;
using System.Security.Cryptography;
using System.Text;

public class UserService
{
    private readonly HttpClient _httpClient;

    public UserService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ApiClient");
    }

    public async Task<User> AuthenticateUserAsync(string username, string hashPassword)
    {
        var loginData = new { email = username, password = hashPassword };

        var response = await _httpClient.PostAsJsonAsync("/User/authenticate", loginData);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<User>();
        }

        return null;
    }

    public string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            var builder = new StringBuilder();
            foreach (var b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }

    public async Task<List<User>> GetUsersAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<User>>("/User/users");
    }

    public async Task<bool> CreateUserAsync(UserCreateRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("/User/create", request);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteUserAsync(int userId)
    {
        var response = await _httpClient.DeleteAsync($"/User/{userId}");
        return response.IsSuccessStatusCode;
    }

    public User CurrentUser { get; set; } // Stores logged User
}