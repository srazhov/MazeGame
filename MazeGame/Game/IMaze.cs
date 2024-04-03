using MazeGame.Game.Cells;

namespace MazeGame.Game;

public interface IMaze
{
    int XSize();
    int YSize();

    CellBase this[int x, int y] { get; }

    bool TryMovePlayer(ConsoleKey? key);

    bool IsFinished();

    int GetScore();
}
