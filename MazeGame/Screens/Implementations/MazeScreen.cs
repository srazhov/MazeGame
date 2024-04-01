
using System.Text;

namespace MazeGame.Screens.Implementations;

public class MazeScreen : ScreenBase
{
    public override string DrawScreen(ConsoleKey? pressedKey)
    {
        base.DrawScreen(pressedKey);
        if (ScreenRemoved)
        {
            return string.Empty;
        }

        var sb = new StringBuilder(100);

        for (int i = 0; i < 10; i++)
        {
            for (int k = 0; k < 10; k++)
            {
                sb.Append('X');
            }

            sb.AppendLine();
        }

        return sb.ToString();
    }
}