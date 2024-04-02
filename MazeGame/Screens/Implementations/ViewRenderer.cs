namespace MazeGame.Screens.Implementations;

public class ViewRenderer : IViewRenderer
{
    private Stack<IScreen> Screens { get; set; }

    public ViewRenderer(IScreen screen)
    {
        Screens = new Stack<IScreen>();
        Screens.Push(screen);
    }

    public void Run()
    {
        ConsoleKey? lastPressedKey = null;
        while (Screens.Count > 0 && !Console.KeyAvailable)
        {
            Console.Clear();

            var screenTxt = Screens.Peek().DrawScreen(lastPressedKey);

            var newScreen = Screens.Peek().OnScreenAdded();
            if (newScreen != null)
            {
                Screens.Push(newScreen);
            }

            if (Screens.Peek().OnScreenRemoved())
            {
                Screens.Pop();
            }

            if (newScreen == null && !string.IsNullOrEmpty(screenTxt))
            {
                Console.WriteLine(screenTxt);
                lastPressedKey = Console.ReadKey(true).Key;
            }
            else
            {
                lastPressedKey = null;
            }
        }
    }
}