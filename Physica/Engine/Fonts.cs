
// Fonts.cs

using System.Collections.Generic;
using System.IO;

using FontStashSharp;

namespace Physica.Engine
{
    public class Fonts
    {
        // Variables
        private static readonly Dictionary<string, FontSystem> _fontSystems = [];
        public static string FontsPath { get; set; } = "Content/Assets/Fonts/";


        // Methods
        public static void RegisterFont(string FontName)
        {
            FontSystem fontSystem = new();
            string FilePath = FontsPath + FontName;
            byte[] FileBytes = File.ReadAllBytes(FilePath);
            fontSystem.AddFont(FileBytes);
            _fontSystems.Add(FontName, fontSystem);
        }

        public static FontSystem GetFont(string FontName)
        {
            FontSystem fontSystem = _fontSystems[FontName];
            return fontSystem;
        }
    }
}
