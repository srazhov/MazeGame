
using System.Text;
using MazeGame.Game;

namespace MazeGame.Screens.Implementations;

public class MazeScreen : ScreenBase
{
    private IMaze Maze { get; set; }

    public MazeScreen(IMaze maze)
    {
        Maze = maze;
    }

    public override string DrawScreen(ConsoleKey? pressedKey)
    {
        base.DrawScreen(pressedKey);
        if (ScreenRemoved)
        {
            return string.Empty;
        }

        var maze = Maze.GetCurrentMaze();

        var sb = new StringBuilder(maze.GetLength(0) * maze.GetLength(1));
        for (int i = 0; i < maze.GetLength(0); i++)
        {
            for (int k = 0; k < maze.GetLength(1); k++)
            {
                sb.Append(maze[i, k].Symbol);
            }

            sb.AppendLine();
        }

        return sb.ToString();
    }
}