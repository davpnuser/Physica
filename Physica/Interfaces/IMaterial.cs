
// IMaterial.cs

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Physica.Interfaces
{
    public interface IMaterial
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public Texture2D Texture { get; set; }
        public float Shininess { get; set; }
        public bool UseLighting { get; set; }
    }
}
