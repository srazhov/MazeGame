namespace MazeGame.Game.Settings;

public class MazeSettings
{
    public MazeSettings(int sizeX, int sizeY)
    {
        SizeX = sizeX;
        SizeY = sizeY;
        PlayerFirstCoordinates = new(0, 0);
        CoinsCount = 10;
    }

    public int SizeX { get; set; }
    public int SizeY { get; set; }
    public (int, int) PlayerFirstCoordinates { get; set; }
    public int CoinsCount { get; set; }
}
