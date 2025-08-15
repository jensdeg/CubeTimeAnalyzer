using CubeTimeAnalyzer.App.models;

namespace CubeTimeAnalyzer.App.Components.Pages
{
    public partial class Averages
    {
        private Ao5Model[] _averages = [];

        protected override async Task OnInitializedAsync()
        {
            _averages = await httpClient.GetAo5sAsync();
        }
    }
}
