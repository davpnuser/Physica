
// BaseRectangle.cs

using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Physica.Classes.Types.UI
{
    public class BaseRectangle : BaseUI
    {
        // Variables
        private readonly GraphicsDevice _device;
        private Texture2D _texture;
        private Vector2 _cacheSize;
        public Color Color { get; set; } = Color.Black;
        public Vector2 Size { get; set; } = Vector2.Zero;
        public float Scale { get; set; } = 1f;
        public float LayerDepth { get; set; } = 0f;

        // Constructor
        public BaseRectangle(GraphicsDevice device)
            => _device = device;


        // Methods
        protected override void OnDraw(SpriteBatch batch)
        {
            if (!Visibility)
                return;

            if (_texture == null || _cacheSize != Size)
            {
                _texture?.Dispose();
                _texture = new Texture2D(_device, (int)Size.X, (int)Size.Y);
                Color[] data = new Color[(int)Size.X * (int)Size.Y];
                Array.Fill(data, Color.White);
                _texture.SetData(data);
                _cacheSize = Size;
            }

            batch.Draw(
                _texture,
                Position,
                null,
                Color,
                Rotation,
                OriginPoint,
                Scale,
                SpriteEffects.None,
                LayerDepth
            );
        }
    }
}
