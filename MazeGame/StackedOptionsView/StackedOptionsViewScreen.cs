
using System.Text;
using MazeGame.Screens.Implementations;

namespace MazeGame.StackedOptionsView;

public class StackedOptionsViewScreen : ScreenBase
{
    private StackedOption[] Options { get; set; }
    private int SelectedScreenIndex { get; set; }

    public StackedOptionsViewScreen(StackedOption[] options)
    {
        Options = options;
        SelectedScreenIndex = 0;
    }

    protected override string DrawScreenMain(ConsoleKey? pressedKey, out bool needsToRedrawScene)
    {
        switch (pressedKey)
        {
            case ConsoleKey.UpArrow when SelectedScreenIndex > 0:
                SelectedScreenIndex--;
                break;
            case ConsoleKey.DownArrow when SelectedScreenIndex < Options.Length - 1:
                SelectedScreenIndex++;
                break;
            case ConsoleKey.Enter:
                Options[SelectedScreenIndex].OnOptionSelected(this);
                break;
            default:
                if (FirstRenderFinished)
                {
                    needsToRedrawScene = false;
                    return string.Empty;
                }
                break;
        }

        var sb = new StringBuilder();

        for (int i = 0; i < Options.Length; i++)
        {
            if (SelectedScreenIndex != i)
            {
                sb.AppendLine($" --- {Options[i].Text} --- \n");
            }
            else
            {
                sb.AppendLine($" >>> {Options[i].Text} <<< \n");
            }
        }

        needsToRedrawScene = true;
        return sb.ToString();
    }
}