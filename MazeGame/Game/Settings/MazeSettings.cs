namespace MazeGame.Game.Settings;

public class MazeSettings
{
    public MazeSettings(int sizeX, int sizeY)
    {
        SizeX = sizeX;
        SizeY = sizeY;
    }

    public int SizeX { get; private set; }
    public int SizeY { get; private set; }

}
