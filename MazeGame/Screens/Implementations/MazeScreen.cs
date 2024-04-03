
using System.Text;
using MazeGame.Game;

namespace MazeGame.Screens.Implementations;

public class MazeScreen : ScreenBase
{
    private IMaze Maze { get; }
    private bool FirstRenderFinished { get; set; }

    public MazeScreen(IMaze maze)
    {
        Maze = maze;
        FirstRenderFinished = false;
    }

    public override string DrawScreen(ConsoleKey? pressedKey)
    {
        base.DrawScreen(pressedKey);
        if (ScreenRemoved)
        {
            return string.Empty;
        }

        if (FirstRenderFinished && !Maze.TryMovePlayer(pressedKey))
        {
            return string.Empty;
        }

        var sb = new StringBuilder(Maze.XSize() * Maze.YSize());
        for (int y = 0; y < Maze.YSize(); y++)
        {
            for (int x = 0; x < Maze.XSize(); x++)
            {
                sb.Append(Maze[x, y].Symbol);
            }

            sb.AppendLine();
        }

        FirstRenderFinished = true;
        return sb.ToString();
    }
}