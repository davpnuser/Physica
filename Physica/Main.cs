
// Main.cs

using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Physica.Classes.Core;
using Physica.Classes.Pipelines;
using Physica.Classes.Types.UI;
using Physica.Engine;

namespace Physica
{
    public class Main : Game
    {
        // Variables
        private readonly Color ClearColor = Color.CornflowerBlue;
        public readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _batch;
        private GraphicsDevice _device;
        private Renderer _renderer;

        private BaseCursor _cursor;

        // Debug
        public FrameCounter _counter;
        private BaseText _counterText;
        public int PeakFPS { get; private set; } = 0;

        // Constructor
        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            _device = _graphics.GraphicsDevice;
            Content.RootDirectory = "Content";
        }


        // Methods
        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _batch = new SpriteBatch(GraphicsDevice);
            _device = GraphicsDevice;
            _renderer = new(_device, _batch);
#if DEBUG
            Console.WriteLine("Setting up the debug suite...");
            SetupDebug();
#endif
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

            #if DEBUG
            // Update FPS counter
            _counter.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            if (_counter.CurrentFramesPerSecond >= PeakFPS)
                PeakFPS = (int)_counter.CurrentFramesPerSecond;
            _counterText.Text = $" Cur. FPS: {(int)_counter.CurrentFramesPerSecond}\n Avg. FPS: {(int)_counter.AverageFramesPerSecond}\n Peak FPS: {PeakFPS} ";
            #endif
            _renderer.Render();
            base.Draw(gameTime);
        }

        private void SetupDebug()
        {
            Console.WriteLine("Dynamically loading the calibri font file...");
            Fonts.RegisterFont("Calibri.ttf");
            _counter = new();
            _counterText = new()
            {
                BackgroundEnabled = true,
                BackgroundColor = Color.Black,
                Position = new Vector2(25, 25),
                Font = Fonts.GetFont("Calibri.ttf"),
                TextColor = Color.White,
                TextSize = 18,
                ZIndex = 2,
            };
            RendererUI.Add(_counterText);
            Console.WriteLine("Created and added fps counter to the ui renderer tracklist!");
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
