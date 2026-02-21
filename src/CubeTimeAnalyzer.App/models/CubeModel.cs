using CubeTimeAnalyzer.Api.Core.Shared;

namespace CubeTimeAnalyzer.App.models;

public class CubeModel
{
    public uint Size { get; set; }
    public PieceModel[][][] Pieces { get; set; }
}

public class PieceModel
{
    public Color Front { get; set; }
    public Color Back { get; set; }
    public Color Top { get; set; }
    public Color Bottom { get; set; }
    public Color Left { get; set; }
    public Color Right { get; set; }
}
