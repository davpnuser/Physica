using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Physica.Interfaces
{
    public interface IRenderable2D
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
