namespace CubeTimeAnalyzer.Api.Core.Entities;

public class Move(string move)
{
    public Side Side { get; set; } = move.ToSide();
    public Modifier Modifier { get; set; } = move.ToModifier();
    public BigCubeModifier BigCubeModifier { get; set; } = move.ToBigCubeModifier();
}

public enum Side
{
    R, L, U, D, F, B
}

public enum Modifier
{
    None,
    Prime,
    Double
}

public enum BigCubeModifier
{
    None,
    Wide,
    ThreeWide
}

public static class MoveMapper
{
    public static Side ToSide(this string move)
    {
        if (move.Contains('U')) return Side.U;
        if (move.Contains('D')) return Side.D;
        if (move.Contains('R')) return Side.R;
        if (move.Contains('L')) return Side.L;
        if (move.Contains('F')) return Side.F;
        if (move.Contains('B')) return Side.B;
        throw new NotSupportedException();
    }

    public static Modifier ToModifier(this string move)
    {
        if (move.Contains('\'')) return Modifier.Prime;
        if (move.Contains('2')) return Modifier.Double;
        return Modifier.None;
    }

    public static BigCubeModifier ToBigCubeModifier(this string move)
    {
        if (move.Contains('w')) return BigCubeModifier.Wide;
        if (move.Contains('3')) return BigCubeModifier.ThreeWide;
        return BigCubeModifier.None;
    }
}
