
using System.ComponentModel;
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

    public override string DrawScreen(ConsoleKey? pressedKey)
    {
        base.DrawScreen(pressedKey);
        if (ScreenRemoved)
        {
            return string.Empty;
        }

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

        return sb.ToString();
    }
}