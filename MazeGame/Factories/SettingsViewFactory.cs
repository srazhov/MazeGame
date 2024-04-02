using MazeGame.Game.Settings;
using MazeGame.Screens;
using MazeGame.StackedOptionsView;

namespace MazeGame.Factories;

public static class SettingsViewFactory
{
    public static IScreen CreateSettingsView(MazeSettings defaultSettings)
    {
        var settOptions = new StackedOption[] {
            new("Width: ", (screen) => {}),
            new("Height: ", (screen) => {}),
        };

        return new StackedOptionsViewScreen(settOptions);
    }
}