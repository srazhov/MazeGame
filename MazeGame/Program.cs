using MazeGame.Factories;
using MazeGame.Game.Settings;

var settings = new MazeSettings(10, 10);

var maze = MazeFactory.CreateMaze(settings);

var view = ViewRendererFactory.CreateView();
view.Run();

Console.WriteLine("Application exit performed by a user");
