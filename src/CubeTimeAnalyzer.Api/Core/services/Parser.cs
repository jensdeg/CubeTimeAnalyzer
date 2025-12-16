using CubeTimeAnalyzer.Api.Core.Entities;

namespace CubeTimeAnalyzer.Api.Core.services;

public static class Parser
{
    public static List<Time> Parse(string content, string filename)
    {
        var times = new List<Time>();
        var lines = content.Split('\n');
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            var parts = line.Split(';');

            double timeValue = double.Parse(parts[0].Trim('"').Replace('.', ','));
            string scramble = parts[1].Trim('"');
            string dateString = parts[2].Trim('"');

            var time = new Time(timeValue,
                scramble,
                DateTimeOffset.Parse(dateString),
                ParseFileNameToCubeType(filename));

            if (parts.Length > 3) // dnf is stored after the date, so if there are more than 3 parts, it's a DNF
            {
                time.DNF = true;
            }
            times.Add(time);
        }
        return times;
    }

    private static CubeType ParseFileNameToCubeType(string filename)
    {
        if (filename.Contains("222"))
            return CubeType.Cube2x2;
        if (filename.Contains("333"))
            return CubeType.Cube3x3;
        if (filename.Contains("444"))
            return CubeType.Cube4x4;
        if (filename.Contains("555"))
            return CubeType.Cube5x5;
        if (filename.Contains("666"))
            return CubeType.Cube6x6;
        if (filename.Contains("777"))
            return CubeType.Cube7x7;
        if (filename.Contains("Pyraminx"))
            return CubeType.Pyraminx;
        if (filename.Contains("Megaminx"))
            return CubeType.Megaminx;
        if (filename.Contains("Skewb"))
            return CubeType.Skewb;
        throw new ArgumentException("Could not determine cube type from filename");
    }
}
