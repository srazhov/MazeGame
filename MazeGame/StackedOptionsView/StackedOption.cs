using MazeGame.Screens;

namespace MazeGame.StackedOptionsView;

public class StackedOption
{
    public string Text { get; set; }
    public Action<IScreen> OnOptionSelected { get; set; }

    public StackedOption(string text, Action<IScreen> onOptionSelected)
    {
        Text = text;
        OnOptionSelected = onOptionSelected;
    }
}