using Physica;
using System;

#if DEBUG
[System.Runtime.InteropServices.DllImport("kernel32.dll")]
static extern bool AllocConsole();
AllocConsole();
#endif

Console.WriteLine($"Physica, {DateTime.Now.ToString("yyyy")}. All rights reserved.\n" +
    "Physica is considered a \"Source-Available\" software for community trust, not \"Open-Source\" software that you can edit\nand redistribute yourself.\n" +
    "Keep that in mind as I own all rights to physica's code.");

var Game = new Main() { 
    IsMouseVisible = false,
};
Game.Run();