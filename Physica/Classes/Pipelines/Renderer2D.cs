
// Renderer2D.cs

using System.Collections.Generic;

using Microsoft.Xna.Framework.Graphics;

using Physica.Interfaces;

namespace Physica.Classes.Pipelines
{
    public class Renderer2D : IPipeline
    {
        // Variables
        private static readonly List<IRenderable2D> _removequeue = [];
        public string Name { get; set; }
        private readonly static List<IRenderable2D> _renderables = [];


        // Methods
        public static void Add(IRenderable2D renderable)
            => _renderables.Add(renderable);

        public static void Remove(IRenderable2D renderable)
            => _removequeue.Add(renderable);

        public void Draw(SpriteBatch batch)
        {
            if (_removequeue.ToArray().Length > 0)
            {
                foreach (IRenderable2D renderable in _removequeue)
                    _renderables.Remove(renderable);
                _removequeue.Clear();
            }

            foreach (var renderable in _renderables)
                batch.Draw(
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
        }
    }
}