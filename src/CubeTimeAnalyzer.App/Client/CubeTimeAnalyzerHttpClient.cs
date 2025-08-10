using CubeTimeAnalyzer.App.models;  

namespace CubeTimeAnalyzer.App.Client
{
    public class CubeTimeAnalyzerHttpClient(HttpClient http)
    {
        private const string AveragesEndpoint = "Analyze/Averages";
        private const string ImportEndpoint = "Import";

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

        public async Task ImportTimes(IFormFile file)
        {
            try
            {
                await http.PostAsJsonAsync(ImportEndpoint, file);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred while Importing file: {ex.Message}");
            }

        }
    }
}
