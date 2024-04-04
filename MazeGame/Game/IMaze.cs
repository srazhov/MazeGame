using System.Security.Cryptography.X509Certificates;
using MazeGame.Game.Cells;

namespace MazeGame.Game;

public interface IMaze
{
    int XSize();
    int YSize();

    CellBase this[int x, int y] { get; }

    bool TryMovePlayer(ConsoleKey? key);

    void ReplaceCell(int x, int y, CellBase newCell);

    bool IsFinished();

    void AddScore(int score);

    int GetScore();
}
