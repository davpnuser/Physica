
// BaseText.cs

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using FontStashSharp;

namespace Physica.Classes.Types.UI
{
    public class BaseText : BaseUI
    {
        // Variables
        private DynamicSpriteFont _font;
        public BaseRectangle Background { get; private set; }
        public FontSystem Font { get; set; }
        public string Text { get; set; } = string.Empty;
        public int TextSize { get; set; } = 12;
        public Color TextColor { get; set; } = Color.White;
        public bool BackgroundEnabled { get; set; } = false;
        public Color BackgroundColor {  get; set; } = Color.Black;
        public float LayerDepth { get; set; } = 0f;
        public float CharacterSpacing { get; set; } = 0f;
        public float LineSpacing { get; set; } = 0f;
        public TextStyle TextStyle { get; set; } = TextStyle.None;


        // Methods
        private void DrawBackground(SpriteBatch batch)
        {
            //TODO: Improve performance and dont make MeasureString() run every frame.
            _font = Font.GetFont(TextSize);
            Background ??= new(batch.GraphicsDevice);
            Background.Name = Name;
            Background.OriginPoint = OriginPoint;
            Background.Position = Position;
            Background.Size = _font.MeasureString(Text);
            Background.LayerDepth = LayerDepth;
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
            _font.DrawText(
                batch,
                Text,
                Position,
                TextColor,
                Rotation,
                OriginPoint,
                null,
                LayerDepth,
                CharacterSpacing,
                LineSpacing,
                TextStyle,
                FontSystemEffect.None,
                0
            );
        }
    }
}
