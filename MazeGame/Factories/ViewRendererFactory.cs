using MazeGame.Screens;
using MazeGame.Screens.Implementations;
using MazeGame.StackedOptionsView;

namespace MazeGame.Factories;

public static class ViewRendererFactory
{
    public static IViewRenderer CreateView()
    {
        var mazeScreen = new MazeScreen();

        var options = new StackedOption[] {
            new("New Game", (screen) => screen.AddNewScreen(mazeScreen)),
            new("Settings", (screen) => {}),
        };

        var mainScreen = new StackedOptionsViewScreen(options);

        return new ViewRenderer(mainScreen);
    }
}