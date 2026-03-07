
// BaseUI.cs

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Physica.Classes.Pipelines;
using Physica.Interfaces;

namespace Physica.Classes.Types.UI
{
    public abstract class BaseUI : IRenderableUI
    {
        // Variables
        public string Name { get; set; }
        private int _zindex = 0;
        public int ZIndex
        {
            get => _zindex;
            set
            {
                if (_zindex == value)
                    return;

                _zindex = value;
                RendererUI.Reorder();
            }
        }
        public Vector2 Position { get; set; } = Vector2.Zero;
        public Vector2 OriginPoint { get; set; } = Vector2.Zero;
        public float Rotation { get; set; } = 0;
        public bool Visibility { get; set; } = true;


        // Methods
        public void Draw(SpriteBatch batch)
        {
            if (!Visibility)
                return;
            OnDraw(batch);
        }

        protected abstract void OnDraw(SpriteBatch batch);
    }
}
