
// RendererUI.cs

using System.Collections.Generic;

using Microsoft.Xna.Framework.Graphics;

using Physica.Interfaces;

namespace Physica.Classes.Pipelines
{
    public class RendererUI : IPipeline
    {
        // Variables
        private static bool _reorder = false;
        private static readonly List<IRenderableUI> _removequeue = [];
        public string Name { get; set; }
        private readonly static List<IRenderableUI> _renderables = [];


        // Methods
        public static void Add(IRenderableUI renderable)
        {
            _renderables.Add(renderable);
            _reorder = true;
        }

        public static void Remove(IRenderableUI renderable)
            => _removequeue.Add(renderable);

        public static void Reorder()
            => _reorder = true;

        public void Draw(SpriteBatch batch)
        {
            if (_reorder)
                _renderables.Sort((a, b) => a.ZIndex.CompareTo(b.ZIndex));

            if (_removequeue.ToArray().Length > 0)
            {
                foreach (IRenderableUI renderable in _removequeue)
                    _renderables.Remove(renderable);
                _removequeue.Clear();
            }

            foreach (var renderable in _renderables)
                renderable.Draw(batch);
        }
    }
}