
// IRenderableUI.cs

using Microsoft.Xna.Framework.Graphics;

namespace Physica.Interfaces
{
    public interface IRenderableUI
    {
        public string Name { get; set; }
        public int ZIndex { get; set; }
        public void Draw(SpriteBatch batch);
    }
}
