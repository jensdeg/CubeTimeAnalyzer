using Azure.Core;
using CubeTimeAnalyzer.Api.Core.Shared;
using CubeTimeAnalyzer.App.models;
using Microsoft.AspNetCore.Components.Forms;

namespace CubeTimeAnalyzer.App.Client;

public class CubeTimeAnalyzerHttpClient(HttpClient http)
{
    private const string AveragesEndpoint = "Analyze/Averages";
    private const string ImportEndpoint = "Import";
    private const string ScrambleEndpoint = "Scramble";

    private readonly ClientHelper Client = new(http);

    public async Task<List<AverageViewModel>> GetAveragesAsync(GetAverageRequest request)
    {
        var response = await Client
            .Get<GetAverageResponse, GetAverageRequest>(AveragesEndpoint, request);

        return response?.Averages.Select(avg => avg.ToViewModel()).ToList()
            ?? [];
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

    public async Task<CubeModel?> GetScrambledCube(string scramble)
    {
        return await Client.Get<CubeModel, string>(ScrambleEndpoint, scramble);
    }
}
