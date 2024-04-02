using MazeGame.Screens;
using MazeGame.Screens.Implementations;
using MazeGame.StackedOptionsView;

namespace MazeGame.Factories;

public static class ViewRendererFactory
{
    public static IViewRenderer CreateView(IScreen mazeScreen, IScreen settingsScreen)
    {
        var options = new StackedOption[] {
            new("New Game", (screen) => screen.AddNewScreen(mazeScreen)),
            new("Settings", (screen) => screen.AddNewScreen(settingsScreen)),
        };

        var mainScreen = new StackedOptionsViewScreen(options);

        return new ViewRenderer(mainScreen);
    }
}