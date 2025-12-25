using CubeTimeAnalyzer.Api.Core.Shared;
using CubeTimeAnalyzer.App.models;

namespace CubeTimeAnalyzer.App.Components.Pages;

public partial class Averages
{
    private List<AverageViewModel> _averages = [];
    private CubeType SelectedType = CubeType.Cube3x3;

    protected override async Task OnInitializedAsync()
    {
        var request = new GetAverageRequest
        {
            AverageOf = 5,
            ExcludingAmount = 2,
            CubeType = SelectedType
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
