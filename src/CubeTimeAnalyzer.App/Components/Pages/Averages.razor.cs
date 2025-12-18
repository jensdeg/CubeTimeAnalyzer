using CubeTimeAnalyzer.Api.Core.Shared;
using CubeTimeAnalyzer.App.models;

namespace CubeTimeAnalyzer.App.Components.Pages;

public partial class Averages
{
    private List<AverageViewModel> _averages = [];

    protected override async Task OnInitializedAsync()
    {
        var request = new GetAverageRequest
        {
            AverageOf = 5,
            ExcludingAmount = 2,
            CubeType = CubeType.Cube3x3
        };
        _averages = await httpClient.GetAveragesAsync(request);
    }
}
