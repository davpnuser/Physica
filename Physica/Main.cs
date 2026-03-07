
// Main.cs

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Physica.Classes.Core;
using Physica.Classes.Pipelines;
using Physica.Engine;

namespace Physica
{
    public class Main : Game
    {
        //Variables
        private readonly Color ClearColor = Color.CornflowerBlue;
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _batch;
        private GraphicsDevice _device;
        private Renderer _renderer;


        //Constructor
        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            _device = _graphics.GraphicsDevice;
            Content.RootDirectory = "Content";
        }


        //Methods
        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _batch = new SpriteBatch(GraphicsDevice);
            _device = GraphicsDevice;
            _renderer = new(_device,_batch);
            BatchManager.Initialize(_batch);
            SetupPipelines();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(ClearColor);
            _renderer.Render();
            base.Draw(gameTime);
        }
        private void SetupPipelines()
        {
            Renderer3D renderer3D = new(_device);
            renderer3D.Name = "3D";
            _renderer.Add(renderer3D);
            Renderer2D renderer2D = new();
            renderer2D.Name = "2D";
            _renderer.Add(renderer2D);
            RendererUI rendererUI = new();
            rendererUI.Name = "UI";
            _renderer.Add(rendererUI);
        }
    }
}
