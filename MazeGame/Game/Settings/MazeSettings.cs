namespace MazeGame.Game.Settings;

public class MazeSettings
{
    public MazeSettings(int sizeX, int sizeY)
    {
        SizeX = sizeX;
        SizeY = sizeY;
        PlayerFirstCoordinates = new(0, 0);
        ProbabilitiesOfCellSpan = new Dictionary<Type, double>();
    }

    public int SizeX { get; private set; }
    public int SizeY { get; private set; }
    public (int, int) PlayerFirstCoordinates { get; private set; }
    public Dictionary<Type, double> ProbabilitiesOfCellSpan { get; private set; }
}
