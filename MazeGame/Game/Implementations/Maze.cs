using MazeGame.Game.Cells;
using MazeGame.Game.Settings;

namespace MazeGame.Game.Implementations;

public class Maze : IMaze
{
    private MazeSettings Settings { get; }
    private Player Player { get; }
    private CellBase[,] CurrentMaze { get; set; }
    private int Score { get; set; }

    public Maze(MazeSettings settings, CellBase[,] generatedMaze)
    {
        Settings = settings;
        Player = new Player(settings.PlayerFirstCoordinates.Item1, settings.PlayerFirstCoordinates.Item2);
        CurrentMaze = generatedMaze;
        Score = 0;
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

    public void AddScore(int score)
    {
        Score += score;
    }

    public int GetScore()
    {
        return Score;
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
            case ConsoleKey.LeftArrow when newX > 0:
                newX--;
                break;
            case ConsoleKey.UpArrow when newY > 0:
                newY--;
                break;
            case ConsoleKey.DownArrow when newY + 1 < CurrentMaze.GetLength(0):
                newY++;
                break;
            case ConsoleKey.RightArrow when newX + 1 < CurrentMaze.GetLength(1):
                newX++;
                break;
            default:
                return false;
        }

        if (CurrentMaze[newY, newX].TryStep(this))
        {
            Player.MoveUser(newX, newY);
            return true;
        }

        return false;
    }

    public void ReplaceCell(int x, int y, CellBase newCell)
    {
        CurrentMaze[y, x] = newCell;
    }
}