
// IRenderable3D.cs

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Physica.Interfaces
{
    public interface IRenderable3D
    {
        public string Name { get; set; }
        public VertexPositionColorNormal VertexPositionColorNormal { get; set; }
        public IMaterial Material { get; set; }
        public Matrix World { get; set; }
        public int PrimitiveCount { get; set; }
        public bool SingleUse { get; set; }
    }
}
