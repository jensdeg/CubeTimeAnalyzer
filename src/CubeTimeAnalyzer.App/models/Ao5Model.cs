namespace CubeTimeAnalyzer.App.models
{
    public class Ao5Model
    {
        public double Average { get; set; }

        public TimeModel BestTime { get; set; }
        public TimeModel WorstTime { get; set; }
        public List<TimeModel> Times { get; set; }

        public bool DNF { get; set; } = false;
    }
}
