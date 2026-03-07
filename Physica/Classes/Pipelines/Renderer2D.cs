
// Renderer2D.cs

using System.Collections.Generic;

using Microsoft.Xna.Framework.Graphics;

using Physica.Classes.Core;
using Physica.Interfaces;

namespace Physica.Classes.Pipelines
{
    public class Renderer2D : IPipeline
    {
        // Variables
        public string Name { get; set; }
        private readonly BatchManager _manager = BatchManager.Instance;
        private readonly SpriteBatch _batch;
        private readonly static List<IRenderable2D> _renderables = [];


        // Constructor
        public Renderer2D()
            => _batch = _manager.Batch;


        // Methods
        public static void Add(IRenderable2D renderable)
            => _renderables.Add(renderable);

        public static void Remove(IRenderable2D renderable)
            => _renderables.Remove(renderable);

        public void Draw()
        {
            _manager.Begin();
            foreach (var renderable in _renderables)
                _batch.Draw(
                    renderable.Texture,
                    renderable.Position,
                    null,
                    renderable.TintColor,
                    renderable.Rotation,
                    renderable.OriginPoint,
                    renderable.Scale,
                    SpriteEffects.None,
                    renderable.LayerDepth
                );
            _manager.End();
        }
    }
}