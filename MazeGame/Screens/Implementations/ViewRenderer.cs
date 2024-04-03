namespace MazeGame.Screens.Implementations;

public class ViewRenderer : IViewRenderer
{
    private Stack<IScreen> Screens { get; set; }

    public ViewRenderer(IScreen screen)
    {
        Screens = new Stack<IScreen>();
        Screens.Push(screen);
    }

    private int counter = 0;

    public void Run()
    {
        ConsoleKey? lastPressedKey = null;
        while (Screens.Count > 0 && !Console.KeyAvailable)
        {
            var lastScreen = Screens.Peek();
            var screenTxt = lastScreen.DrawScreen(lastPressedKey, out var needsToRedraw);

            var newScreen = lastScreen.OnScreenAdded();
            if (newScreen != null)
            {
                Screens.Push(newScreen);
            }

            var screenRemoved = lastScreen.OnScreenRemoved();
            if (screenRemoved)
            {
                Screens.Pop();
            }

            if (newScreen == null && !screenRemoved)
            {
                if (needsToRedraw)
                {
                    counter++;
                    Console.Clear();
                    Console.WriteLine(screenTxt);
                    Console.WriteLine();
                    Console.WriteLine($"Screen updated times: {counter}");
                }

                lastPressedKey = Console.ReadKey(true).Key;
            }
            else
            {
                lastPressedKey = null;
            }
        }
    }
}