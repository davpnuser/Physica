
// Program.cs

using System;
using System.Linq;
using System.Reflection;

using Microsoft.Xna.Framework.Graphics;

using Physica;
using Physica.Classes.Core;

#if DEBUG
[System.Runtime.InteropServices.DllImport("kernel32.dll")]
static extern bool AllocConsole();
AllocConsole();
string Timestamp = LinkerTimestamp.GetLinkerTimestampUtc(Assembly.GetExecutingAssembly()).ToString("yyyyMMddHHmmss");
Console.WriteLine($"Physica {DateTime.Now:yyyy}, All rights reserved.");
Console.WriteLine($"Build hash: {AlgorithmMD5.GetHashString(Timestamp)}");
Console.WriteLine("Physica is built with MonoGame. (https://monogame.net)");
Console.WriteLine("This is a debug build of Physica.");
#endif

var Game = new Main() { 
    IsMouseVisible = false,
    IsFixedTimeStep = false,
};
var uncapped = args.Contains("--uncap");
if (uncapped)
{
    Game._graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
    Game._graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
    Game._graphics.SynchronizeWithVerticalRetrace = !uncapped;
    Game._graphics.HardwareModeSwitch = uncapped;
    Game._graphics.IsFullScreen = uncapped;
    Game._graphics.ApplyChanges();
}
Game.Run();
if (!uncapped)
    Environment.Exit(0);
Console.WriteLine($"Peak FPS: {Game.PeakFPS}, Average FPS: {(int)Game._counter.AverageFramesPerSecond}");
Console.WriteLine("Press the enter key to exit the current application.");
Console.ReadLine();