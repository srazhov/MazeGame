using MazeGame.Game.Implementations;
using MazeGame.Game.Settings;
using MazeGame.Screens;
using MazeGame.Screens.Implementations;

namespace MazeGame.Factories;

public static class MazeFactory
{
    public static IScreen CreateMazeScreen(MazeSettings mazeSettings)
    {
        var maze = new Maze();

        return new MazeScreen(maze);
    }
}
