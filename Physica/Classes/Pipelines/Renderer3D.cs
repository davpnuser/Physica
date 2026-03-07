
// Renderer3D.cs

using System.Collections.Generic;

using Microsoft.Xna.Framework.Graphics;

using Physica.Interfaces;

namespace Physica.Classes.Pipelines
{
    public class Renderer3D : IPipeline
    {
        // Variables
        public string Name { get; set; }
        private readonly GraphicsDevice _graphics;
        private readonly static List<IRenderable3D> _renderables = [];


        // Constructor
        public Renderer3D(GraphicsDevice graphics)
            => _graphics = graphics;


        // Methods
        public static void Add(IRenderable3D renderable)
            => _renderables.Add(renderable);

        public static void Remove(IRenderable3D renderable)
            => _renderables.Remove(renderable);

        public void Draw(SpriteBatch batch)
        {
            //TODO: Draw 3d objects here
        }
    }
}