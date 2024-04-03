namespace MazeGame.Screens;

public interface IScreen
{
    string DrawScreen(ConsoleKey? pressedKey, out bool needsToRedrawScene);

    void AddNewScreen(IScreen screen);

    IScreen? OnScreenAdded();

    bool OnScreenRemoved();
}