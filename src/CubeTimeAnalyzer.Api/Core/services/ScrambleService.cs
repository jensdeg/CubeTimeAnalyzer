using CubeTimeAnalyzer.Api.Core.Entities;

namespace CubeTimeAnalyzer.Api.Core.services;

public class ScrambleService
{
    public Cube GetScrambledCube(string scramble)
    {
        var cube = new Cube(3);
        var moves = ParseScramble(scramble);
        foreach (var move in moves)
        {
            cube.MoveLayer(move);
        }
        return cube;
    }

    private static List<Move> ParseScramble(string scramble)
    {
        var moves = new List<Move>();
        var moveStrings = scramble.Split(' ');
        foreach (var moveStr in moveStrings)
        {
            moves.Add(new Move(moveStr));
        }
        return moves;
    }
}
