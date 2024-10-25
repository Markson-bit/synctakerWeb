using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using synctakerWeb.Models;

public class WeatherForecastService
{
    private readonly HttpClient _httpClient;

    public WeatherForecastService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("WeatherApi");
    }

    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<WeatherForecast>>("WeatherForecast");
    }
}