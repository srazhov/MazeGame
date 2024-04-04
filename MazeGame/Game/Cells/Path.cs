namespace MazeGame.Game.Cells;

public class Path : CellBase
{
    public Path(int x, int y) : base(x, y)
    {
        Symbol = '_';
    }

    public override bool TryStep()
    {
        return true;
    }
}