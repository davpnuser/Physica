
// BaseCursor.cs

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Physica.Classes.Types.UI
{
    public class BaseCursor : BaseUI
    {
        public Texture2D Texture { get; set; }
        public float Scale { get; set; } = 0.1f;
        public float LayerDepth { get; set; } = 0f;
        protected override void OnDraw(SpriteBatch batch)
        {
            batch.Draw(
                Texture,
                Position,
                null,
                Color.White,
                Rotation,
                OriginPoint,
                Scale,
                SpriteEffects.None,
                LayerDepth
            );
        }
    }
}
