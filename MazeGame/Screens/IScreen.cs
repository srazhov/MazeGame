namespace MazeGame.Screens;

public interface IScreen
{
    string DrawScreen(ConsoleKey? pressedKey);

    void AddNewScreen(IScreen screen);

    IScreen? OnScreenAdded();

    bool OnScreenRemoved();
}