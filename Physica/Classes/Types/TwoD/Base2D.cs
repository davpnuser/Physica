
// Base2D.cs

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Physica.Interfaces;

namespace Physica.Classes.Types.TwoD
{
    public abstract class Base2D : IRenderable2D
    {
        public string Name { get; set; }
        public Texture2D Texture { get; set; }
        public Color TintColor { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 OriginPoint { get; set; }
        public float Scale { get; set; }
        public float Rotation { get; set; }
        public float LayerDepth { get; set; }
        public bool SingleUse { get; set; }
    }
}
