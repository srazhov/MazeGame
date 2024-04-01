
namespace MazeGame.Screens.Implementations;

public abstract class ScreenBase : IScreen
{
    protected IScreen? NextScreen = null;
    protected bool ScreenRemoved = false;

    public void AddNewScreen(IScreen screen)
    {
        NextScreen = screen;
    }

    public virtual string DrawScreen(ConsoleKey? pressedKey)
    {
        if (pressedKey == ConsoleKey.Escape)
        {
            ScreenRemoved = true;
        }

        return string.Empty;
    }

    public IScreen? OnScreenAdded()
    {
        var nextScreen = NextScreen;
        NextScreen = null;

        return nextScreen;
    }

    public bool OnScreenRemoved()
    {
        var result = ScreenRemoved;
        ScreenRemoved = false;

        return result;
    }
}