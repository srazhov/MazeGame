namespace MazeGame.Game.Cells;

public abstract class CellBase
{
    public int X { get; set; }

    public int Y { get; set; }

    public char Symbol { get; protected set; }

    public abstract bool TryStep(IMaze maze);

    protected CellBase(int x, int y)
    {
        X = x;
        Y = y;
    }
}