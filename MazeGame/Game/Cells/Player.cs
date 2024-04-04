namespace MazeGame.Game.Cells;

public class Player : CellBase
{
    public Player(int x, int y) : base(x, y)
    {
        Symbol = 'P';
    }

    public void MoveUser(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override bool TryStep(IMaze maze)
    {
        throw new NotSupportedException("A player cannot step on itself");
    }
}