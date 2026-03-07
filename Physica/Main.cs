
// Main.cs

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Physica.Classes.Pipelines;
using Physica.Classes.Types.TwoD;
using Physica.Classes.Types.UI;
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

        private BaseCursor _cursor;

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
            _renderer = new(_device, _batch);
            SetupCursor();
            SetupPipelines();
        }

        protected override void Update(GameTime gameTime)
        {
            var mouse = Mouse.GetState();
            var mouseVector = mouse.Position.ToVector2();
            _cursor.Position = mouseVector;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(ClearColor);
            _renderer.Render();
            base.Draw(gameTime);
        }

        private void SetupCursor()
        {
            _cursor = new();
            _cursor.Texture = Content.Load<Texture2D>("Assets/Pictures/Input/Cursor");
            RendererUI.Add(_cursor);
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
