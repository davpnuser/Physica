
// RendererUI.cs

using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Physica.Interfaces;

namespace Physica.Classes.Pipelines
{
    public class RendererUI : IPipeline
    {
        // Variables
        public string Name { get; set; }
        private readonly static List<IRenderableUI> _renderables = [];


        // Methods
        public static void Add(IRenderableUI renderable)
        {
            _renderables.Add(renderable);
            Reorder();
        }

        public static void Remove(IRenderableUI renderable)
            => _renderables.Remove(renderable);

        public static void Reorder()
            => _renderables.Sort((a, b) => a.ZIndex.CompareTo(b.ZIndex));

        public void Draw(SpriteBatch batch)
        {
            foreach (var renderable in _renderables)
                renderable.Draw(batch);
        }
    }
}