using CubeTimeAnalyzer.Api.Core.Entities;
using CubeTimeAnalyzer.Api.Core.Shared;

namespace CubeTimeAnalyzer.Api.Core.services;

public static partial class Parser
{
    public static List<Time> Parse(string content, string filename)
    {
        var times = new List<Time>();
        var lines = content.Split('\n').Skip(1).ToList();

        foreach (var l in lines)
        {
            if (string.IsNullOrWhiteSpace(l)) continue;
            var line = l.Replace('"'.ToString(), string.Empty);
            var parts = line.Split(';').ToList();
            var time = double.Parse(parts[2]) / 1000;
            var cubeType = ParseCubeType(parts[0]);
            var category = parts[1];
            var date = ParseDateTime(parts[3]);
            var scramble = parts[4];
            var penalty = (Penalty)int.Parse(parts[5]);
            var comment = string.IsNullOrEmpty(parts[6]) ? null : parts[6];

            times.Add(new Time
            {
                Value = time,
                Scramble = scramble,
                Category = category,
                CubeType = cubeType,
                Date = date,
                Penalty = penalty,
                Comment = comment
            });
        }
        return times;
    }

    private static DateTimeOffset ParseDateTime(string time)
    {
        var timeMs = long.Parse(time);
        return DateTimeOffset.FromUnixTimeMilliseconds(timeMs);
    }

    private static CubeType ParseCubeType(string cubeType)
    {
        if (cubeType == "222")
            return CubeType.Cube2x2;
        if (cubeType == "333")
            return CubeType.Cube3x3;
        if (cubeType == "444")
            return CubeType.Cube4x4;
        if (cubeType == "555")
            return CubeType.Cube5x5;
        if (cubeType == "666")
            return CubeType.Cube6x6;
        if (cubeType == "777")
            return CubeType.Cube7x7;
        if (cubeType == "pyraminx")
            return CubeType.Pyraminx;
        if (cubeType == "megaminx")
            return CubeType.Megaminx;
        if (cubeType == "skewb")
            return CubeType.Skewb;
        if (cubeType == "clock")
            return CubeType.Clock;
        throw new ArgumentException("Could not determine cube type from filename");
    }
}
