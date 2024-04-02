namespace MazeGame.Game.Cells;

public abstract class CellBase
{
    public int X { get; set; }

    public int Y { get; set; }

    public char Symbol { get; private set; }

    public virtual bool TryStep()
    {
        return true;
    }

    protected CellBase(int x, int y, char symbol)
    {
        X = x;
        Y = y;
        Symbol = symbol;
    }
}