namespace CubeTimeAnalyzer.App.Client;

public class ClientHelper(HttpClient http)
{
    public async Task<TResponse?> Get<TResponse, TRequest>(string Endpoint, TRequest body)
    {
        try
        {
            var json = JsonContent.Create(body);
            var httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(http.BaseAddress + Endpoint),
                Content = json
            };

            var response = await http.SendAsync(httpRequest);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<TResponse>();

            return result != null
                ? result
                : throw new HttpRequestException("Get Request returned null");
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"An error occurred while Importing file: {ex.Message}");
            return default;
        }

    }
}