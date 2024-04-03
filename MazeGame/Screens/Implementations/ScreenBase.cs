
namespace MazeGame.Screens.Implementations;

public abstract class ScreenBase : IScreen
{
    protected IScreen? NextScreen = null;
    protected bool ScreenRemoved = false;
    protected bool FirstRenderFinished { get; private set; }

    public void AddNewScreen(IScreen screen)
    {
        NextScreen = screen;
    }

    public string DrawScreen(ConsoleKey? pressedKey, out bool needsToRedrawScene)
    {
        if (pressedKey == ConsoleKey.Escape)
        {
            ScreenRemoved = true;
            needsToRedrawScene = true;
            return string.Empty;
        }

        var result = DrawScreenMain(pressedKey, out needsToRedrawScene);
        FirstRenderFinished = true;
        return result;
    }

    public IScreen? OnScreenAdded()
    {
        if (NextScreen != null)
        {
            FirstRenderFinished = false;
        }

        var nextScreen = NextScreen;
        NextScreen = null;

        return nextScreen;
    }

    public bool OnScreenRemoved()
    {
        if (ScreenRemoved)
        {
            FirstRenderFinished = false;
        }

        var result = ScreenRemoved;
        ScreenRemoved = false;

        return result;
    }

    protected abstract string DrawScreenMain(ConsoleKey? pressedKey, out bool needsToRedrawScene);
}