
using System.Text;
using MazeGame.Game;

namespace MazeGame.Screens.Implementations;

public class MazeScreen : ScreenBase
{
    private IMaze Maze { get; }

    public MazeScreen(IMaze maze)
    {
        Maze = maze;
    }

    protected override string DrawScreenMain(ConsoleKey? pressedKey, out bool needsToRedrawScene)
    {
        if (FirstRenderFinished && !Maze.TryMovePlayer(pressedKey))
        {
            needsToRedrawScene = false;
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

        needsToRedrawScene = true;
        return sb.ToString();
    }
}