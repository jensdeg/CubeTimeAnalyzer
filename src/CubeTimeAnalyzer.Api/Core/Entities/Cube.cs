using CubeTimeAnalyzer.Api.Core.Shared;

namespace CubeTimeAnalyzer.Api.Core.Entities;

public class Cube
{
    public uint Size { get; set; }

    public Piece[][][] Pieces { get; set; }

    public Cube(uint size)
    {
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
}

public class Piece
{
    public Color Front { get; set; }
    public Color Back { get; set; }
    public Color Top { get; set; }
    public Color Bottom { get; set; }
    public Color Left { get; set; }
    public Color Right { get; set; }
}
