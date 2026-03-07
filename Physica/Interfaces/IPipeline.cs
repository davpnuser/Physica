
// IPipeline.cs

using Microsoft.Xna.Framework.Graphics;

namespace Physica.Interfaces
{
    public interface IPipeline 
    {
        public string Name { get; set; }
        void Draw(SpriteBatch batch);
    }
}
