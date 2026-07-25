using CubeTimeAnalyzer.Api.Core.Helpers;
using CubeTimeAnalyzer.Api.Core.Shared;

namespace CubeTimeAnalyzer.Api.Core.Entities;

public class Cube
{
    public int Size { get; set; }

    public Piece[][][] Pieces { get; set; }

    public Cube(int size)
    {
        if (size < 2) throw new Exception("Not a possible cube");

        Size = size;

        Pieces = new Piece[size][][];

        for (int x = 0; x < size; x++)
        {
            Pieces[x] = new Piece[size][];
            for (int y = 0; y < size; y++)
            {
                Pieces[x][y] = new Piece[size];
                for (int z = 0; z < size; z++)
                {
                    Pieces[x][y][z] = new Piece();

                    if (x == 0) Pieces[x][y][z].Left = Color.Orange;
                    if (x == size - 1) Pieces[x][y][z].Right = Color.Red;

                    if (y == 0) Pieces[x][y][z].Back = Color.Blue;
                    if (y == size - 1) Pieces[x][y][z].Front = Color.Green;

                    if (z == 0) Pieces[x][y][z].Top = Color.White;
                    if (z == size - 1) Pieces[x][y][z].Bottom = Color.Yellow;
                }
            }
        }
    }

    public void MoveLayer(Move move)
    {
        switch (move.Side)
        {
            case Side.U: MoveHorizontal(0, move.Modifier); break;
            case Side.D: MoveHorizontal(Size - 1, move.Modifier); break;
            case Side.R: MoveVertical(Size - 1, move.Modifier); break;
            case Side.L: MoveVertical(0, move.Modifier); break;
        }
    }

    private void MoveHorizontal(int z, Modifier modifier)
    {
        var layer = this.GetLayerHorizontal(z);
        layer.RotateLayerHorizontal(Size, modifier);
        this.ReplaceLayerHorizontal(layer, z);
    }

    private void MoveVertical(int x, Modifier modifier)
    {
    }
}

public class Piece
{
    public Color Front { get; set; }
    public Color Back { get; set; }
    public Color Top { get; set; }
    public Color Bottom { get; set; }
    public Color Left { get; set; }
    public Color Right { get; set; }

    public Piece RotateHorizontal(bool prime)
    {
        if (!prime)
        {
            var buffer = Front;
            Front = Right;
            Right = Back;
            Back = Left;
            Left = buffer;
        }
        else
        {
            var buffer = Front;
            Front = Left;
            Left = Back;
            Back = Right;
            Right = buffer;
        }
        return this;
    }

    public bool IsEdge =>
         GetType().GetProperties()
        .Where(p => p.PropertyType == typeof(Color) && (Color)p.GetValue(this)! != Color.None)
        .Count() == 2;

    public override string ToString()
    {
        var colors = GetType().GetProperties()
            .Where(p => p.PropertyType == typeof(Color) &&
                  (Color)p.GetValue(this)! != Color.None);

        var pieceString = string.Empty;

        if (colors.Count() > 2) pieceString = "Corner: ";
        else pieceString = "Edge: ";

        foreach (var color in colors)
        {
            var value = (Color)color.GetValue(this)!;
            pieceString += Enum.GetName(value) + " ";
        }

        return pieceString;
    }
}
