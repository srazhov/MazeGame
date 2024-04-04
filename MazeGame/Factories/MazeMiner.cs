using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using MazeGame.Game.Cells;
using MazeGame.Game.Settings;

namespace MazeGame.Factories;

public class MazeMiner
{

    private MazeSettings MazeSettings { get; }
    private CellBase[,] GeneratedMaze { get; set; }
    private Random Rand { get; set; }

    public MazeMiner(MazeSettings mazeSettings)
    {
        MazeSettings = mazeSettings;
        GeneratedMaze = new CellBase[0, 0];
        Rand = new Random();
    }

    public CellBase[,] MakeMaze()
    {
        GeneratedMaze = GenerateMazeFullOfWalls(MazeSettings.SizeX, MazeSettings.SizeY);

        MineMaze(MazeSettings.PlayerFirstCoordinates.Item1, MazeSettings.PlayerFirstCoordinates.Item2);

        return GeneratedMaze;
    }

    private void MineMaze(int minerX, int minerY)
    {
        var cellsAllowedToBreak = new List<CellBase>();

        do
        {
            BreakWall(minerX, minerY);
            var brokenWall = cellsAllowedToBreak.FirstOrDefault(wall => wall.X == minerX && wall.Y == minerY);
            if (brokenWall != null)
            {
                cellsAllowedToBreak.Remove(brokenWall);
            }

            cellsAllowedToBreak.AddRange(GetNearCells<Wall>(minerX, minerY));
            cellsAllowedToBreak = cellsAllowedToBreak
                .Where(wall => GetNearCells<Wall>(wall.X, wall.Y).Count() > 1)
                .Distinct().ToList();

            var nextCell = GetRandomCell(cellsAllowedToBreak);
            minerX = nextCell?.X ?? 0;
            minerY = nextCell?.Y ?? 0;
        }
        while (cellsAllowedToBreak.Any());
    }

    private IEnumerable<CellBase> GetNearCells<T>(int x, int y) where T : CellBase
    {
        return new CellBase[]{
            (y > 0) ?
                GeneratedMaze[y - 1, x] : null!,
            (y + 1 < MazeSettings.SizeY) ?
                GeneratedMaze[y + 1, x] : null!,
            (x > 0) ?
                GeneratedMaze[y, x - 1] : null!,
            (x + 1 < MazeSettings.SizeX) ?
                GeneratedMaze[y, x + 1] : null!,
        }.Where(x => x != null).OfType<T>();
    }

    private CellBase? GetRandomCell(List<CellBase> cells)
    {
        if (cells.Count == 0)
        {
            return null;
        }

        var randomIndex = Rand.Next(0, cells.Count);
        return cells[randomIndex];
    }

    private void BreakWall(int x, int y)
    {
        GeneratedMaze[y, x] = new Game.Cells.Path(x, y);
    }

    private static CellBase[,] GenerateMazeFullOfWalls(int sizeX, int sizeY)
    {
        var maze = new CellBase[sizeY, sizeX];
        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                maze[y, x] = new Wall(x, y);
            }
        }

        return maze;
    }
}
