using CubeTimeAnalyzer.Api.Shared;
using CubeTimeAnalyzer.App.models;
using Microsoft.AspNetCore.Components.Forms;

namespace CubeTimeAnalyzer.App.Client;

public class CubeTimeAnalyzerHttpClient(HttpClient http)
{
    private const string AveragesEndpoint = "Analyze/Averages";
    private const string ImportEndpoint = "Import";

    public async Task<List<AverageViewModel>> GetAveragesAsync(GetAverageRequest request)
    {
        try
        {
            var json = JsonContent.Create(request);
            var httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(http.BaseAddress + AveragesEndpoint),
                Content = json
            };

            var response = await http.SendAsync(httpRequest);

            response.EnsureSuccessStatusCode();

            var averagesResponse = await response.Content.ReadFromJsonAsync<GetAverageResponse>();

            return averagesResponse?.Averages.Select(avg => avg.ToViewModel()).ToList()
                ?? [];
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"An error occurred while fetching Ao5s: {ex.Message}");
            return [];
        }
    }

    public async Task<bool> ImportTimes(IBrowserFile file)
    {
        try
        {
            using var content = new MultipartFormDataContent();
            using var streamContent = new StreamContent(file.OpenReadStream(maxAllowedSize: 1024 * 1024));
            content.Add(streamContent, "file", file.Name);
            var result = await http.PostAsync(ImportEndpoint, content);
            return result.IsSuccessStatusCode;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"An error occurred while Importing file: {ex.Message}");
            return false;
        }
    }
}
