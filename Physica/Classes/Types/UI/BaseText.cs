
// BaseText.cs

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Physica.Classes.Types.UI
{
    public class BaseText : BaseUI
    {
        // Variables
        public BaseRectangle Background { get; private set; }
        public SpriteFont Font { get; set; }
        public string Text { get; set; } = string.Empty;
        public Color TextColor { get; set; } = Color.White;
        public float Scale { get; set; } = 1f;
        public bool BackgroundEnabled { get; set; } = false;
        public Color BackgroundColor {  get; set; } = Color.Black;
        public float LayerDepth { get; set; } = 0f;


        // Methods
        private void DrawBackground(SpriteBatch batch)
        {
            //TODO: Improve performance and dont make MeasureString() run every frame.
            Background ??= new(batch.GraphicsDevice);
            Background.Name = Name;
            Background.OriginPoint = OriginPoint;
            Background.Position = Position;
            Background.Size = Font.MeasureString(Text);
            Background.LayerDepth = LayerDepth;
            Background.Scale = Scale;
            Background.Rotation = Rotation;
            Background.Color = BackgroundColor;
            Background.ZIndex = ZIndex;
            Background.Visibility = Visibility;
            Background.Draw(batch);
        }

        protected override void OnDraw(SpriteBatch batch)
        {
            if (!Visibility)
                return;
            if (BackgroundEnabled)
                DrawBackground(batch);
            batch.DrawString(
                Font,
                Text,
                Position,
                TextColor,
                Rotation,
                OriginPoint,
                Scale,
                SpriteEffects.None,
                LayerDepth
            );
        }
    }
}
