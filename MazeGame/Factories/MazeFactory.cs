using MazeGame.Game.Implementations;
using MazeGame.Game.Settings;
using MazeGame.Screens;
using MazeGame.Screens.Implementations;

namespace MazeGame.Factories;

public static class MazeFactory
{
    public static IScreen CreateMazeScreen(MazeSettings mazeSettings)
    {
        var mazeMiner = new MazeMiner(mazeSettings);

        var generatedMaze = mazeMiner.MakeMaze();

        var maze = new Maze(mazeSettings, generatedMaze);

        return new MazeScreen(maze);
    }
}
