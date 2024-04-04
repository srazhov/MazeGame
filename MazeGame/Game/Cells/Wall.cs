namespace MazeGame.Game.Cells;

public class Wall : CellBase
{
    public Wall(int x, int y) : base(x, y)
    {
        Symbol = '#';
    }

    public override bool TryStep(IMaze maze)
    {
        return false;
    }
}