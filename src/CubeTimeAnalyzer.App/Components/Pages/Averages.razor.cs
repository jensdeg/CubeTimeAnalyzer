using CubeTimeAnalyzer.Api.Core.Shared;
using CubeTimeAnalyzer.App.models;

namespace CubeTimeAnalyzer.App.Components.Pages;

public partial class Averages
{
    private List<AverageViewModel> _averages = [];

    protected override async Task OnInitializedAsync()
    {
        await GetAverages(CubeType.Cube3x3);
    }

    private async Task GetAverages(CubeType cubetype)
    {
        var request = new GetAverageRequest
        {
            AverageOf = 5,
            ExcludingAmount = 2,
            CubeType = cubetype
        };
        _averages = await httpClient.GetAveragesAsync(request);
    }

    private static string ParseTime(double time)
    {
        if (time < 60)
            return time.ToString();

        return TimeSpan.FromSeconds(time).ToString(@"mm\:ss\.ff");
    }
}
