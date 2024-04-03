using MazeGame.Game.Cells;
using MazeGame.Game.Settings;

namespace MazeGame.Game.Implementations;

public class Maze : IMaze
{
    private MazeSettings Settings { get; }
    private Player Player { get; }
    private CellBase[,] CurrentMaze { get; set; }

    public Maze(MazeSettings settings)
    {
        Settings = settings;
        Player = new Player(0, 0);
        CurrentMaze = new CellBase[Settings.SizeY, Settings.SizeX];

        for (int y = 0; y < Settings.SizeY; y++)
        {
            for (int x = 0; x < Settings.SizeX; x++)
            {
                CurrentMaze[y, x] = new Cells.Path(x, y);
            }
        }
    }

    public int XSize()
    {
        return Settings.SizeX;
    }

    public int YSize()
    {
        return Settings.SizeY;
    }

    public CellBase this[int x, int y]
    {
        get
        {
            if (Player.X == x && Player.Y == y)
            {
                return Player;
            }

            return CurrentMaze[y, x];
        }
    }

    public int GetScore()
    {
        throw new NotImplementedException();
    }

    public bool IsFinished()
    {
        throw new NotImplementedException();
    }

    public bool TryMovePlayer(ConsoleKey? key)
    {
        int newX = Player.X;
        int newY = Player.Y;
        switch (key)
        {
            case ConsoleKey.LeftArrow when Player.X > 0:
                newX--;
                break;
            case ConsoleKey.UpArrow when Player.Y > 0:
                newY--;
                break;
            case ConsoleKey.DownArrow when Player.Y < CurrentMaze.GetLength(0):
                newY++;
                break;
            case ConsoleKey.RightArrow when Player.X < CurrentMaze.GetLength(1):
                newX++;
                break;
            default:
                return false;
        }

        if (CurrentMaze[newY, newX].TryStep())
        {
            Player.MoveUser(newX, newY);
            return true;
        }

        return false;
    }
}