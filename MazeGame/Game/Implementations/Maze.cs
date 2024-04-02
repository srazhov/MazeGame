using MazeGame.Game.Cells;
using MazeGame.Game.Settings;

namespace MazeGame.Game.Implementations;

public class Maze : IMaze
{
    private MazeSettings Settings { get; set; }

    public CellBase[,] GetCurrentMaze()
    {
        throw new NotImplementedException();
    }

    public int GetScore()
    {
        throw new NotImplementedException();
    }

    public bool IsFinished()
    {
        throw new NotImplementedException();
    }

    public void MovePlayer(ConsoleKey key)
    {
        throw new NotImplementedException();
    }
}