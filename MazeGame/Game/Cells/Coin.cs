namespace MazeGame.Game.Cells;

public class Coin : CellBase
{
    public Coin(int x, int y) : base(x, y)
    {
        Symbol = 'Ø';
    }

    public override bool TryStep(IMaze maze)
    {
        maze.ReplaceCell(X, Y, new Path(X, Y));
        maze.AddScore(1);
        return true;
    }
}