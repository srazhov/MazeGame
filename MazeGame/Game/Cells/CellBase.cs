namespace MazeGame.Game.Cells;

public abstract class CellBase
{
    public int X { get; set; }

    public int Y { get; set; }

    public char Symbol { get; protected set; }

    public virtual bool TryStep()
    {
        return true;
    }

    protected CellBase(int x, int y)
    {
        X = x;
        Y = y;
    }
}