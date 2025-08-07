using CubeTimeAnalyzer.App.models;  

namespace CubeTimeAnalyzer.App.Client
{
    public class CubeTimeAnalyzerHttpClient(HttpClient http)
    {
        private const string AveragesEndpoint = "Analyze/Averages";

        public async Task<Ao5Model[]> GetAo5sAsync()
        {
            try
            {
                return await http.GetFromJsonAsync<Ao5Model[]>(AveragesEndpoint) ?? [];
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred while fetching Ao5s: {ex.Message}");
                return [];
            }
        }
    }
}
