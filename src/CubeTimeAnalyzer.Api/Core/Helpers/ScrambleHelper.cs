using CubeTimeAnalyzer.Api.Core.Entities;

namespace CubeTimeAnalyzer.Api.Core.Helpers;

public static class ScrambleHelper
{
    public static List<Piece> GetLayerHorizontal(this Cube cube, int z)
    {
        var pieces = new List<Piece>();
        for (var x = 0; x < cube.Size; x++)
        {
            for (var y = 0; y < cube.Size; y++)
            {
                pieces.Add(cube.Pieces[x][y][z]);
            }
        }
        return pieces;
    }

    public static void ReplaceLayerHorizontal(this Cube cube, List<Piece> layer, int z)
    {
        int i = 0;
        for (var x = 0; x < cube.Size; x++)
        {
            for (var y = 0; y < cube.Size; y++)
            {
                cube.Pieces[x][y][z] = layer[i];
                i++;
            }
        }
    }

    public static void RotateLayerHorizontal(this List<Piece> layer, int size, Modifier modifier)
    {
        if (modifier != Modifier.Prime)
        {
            // corners
            Shuffle(layer, 0, size - 1, layer.Count - 1, layer.Count - size);

            // edges
            for (var i = 1; i <= size - 2; i++)
            {
                Shuffle(layer, i, (size * (i + 1)) - 1, layer.Count - (1 + i), size * i);
            }
        }
        else if (modifier == Modifier.Prime)
        {
            // corners
            Shuffle(layer, 0, layer.Count - size, layer.Count - 1, size - 1);

            // edges
            for (var i = 1; i <= size - 2; i++)
            {
                Shuffle(layer, i, size * i, layer.Count - (1 + i), (size * (i + 1)) - 1);
            }
        }

        foreach (var piece in layer)
        {
            var prime = modifier == Modifier.Prime;
            piece.RotateHorizontal(prime);
        }
    }

    public static void Shuffle<T>(List<T> list, int firstIndex, int secondIndex, int thirdIndex, int fourthIndex)
    {
        var buffer = list[firstIndex];
        list[firstIndex] = list[secondIndex];
        list[secondIndex] = list[thirdIndex];
        list[thirdIndex] = list[fourthIndex];
        list[fourthIndex] = buffer;
    }
}
