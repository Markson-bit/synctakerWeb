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
}