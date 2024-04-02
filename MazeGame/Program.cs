using MazeGame.Factories;
using MazeGame.Game.Settings;

var settings = new MazeSettings(10, 10);

var mazeScreen = MazeFactory.CreateMazeScreen(settings);

var mazeSettingsScreen = SettingsViewFactory.CreateSettingsView(settings);

var view = ViewRendererFactory.CreateView(mazeScreen, mazeSettingsScreen);
view.Run();

Console.WriteLine("Application exit was performed by a user");
