using MazeGame.Game.Cells;

namespace MazeGame.Game;

public interface IMaze
{
    CellBase[,] GetCurrentMaze();

    void MovePlayer(ConsoleKey key);

    bool IsFinished();

    int GetScore();
}
