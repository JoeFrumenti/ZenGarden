using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ZenGarden.Content.src.core;
using ZenGarden.Content.src.entities;
using ZenGarden.Content.src.helpers;
using ZenGarden.Content.src.structures;
using ZenGarden.Content.src.ui;
using static System.Net.Mime.MediaTypeNames;

namespace ZenGarden
{
    public class Game1 : Game
    {
        //Singleton
        private static Game1 _instance;

        public static Game1 Instance => _instance;
        public GameTime CurrentGameTime { get; set; }
        public MouseState mouseState { get; set; }
        public MouseState previousMouseState;
        internal KeyboardHandler kh;


        //graphics
        internal GraphicsHandler graphicsHandler;
        internal GraphicsDeviceManager _graphics;
        internal SpriteBatch spriteBatch;

        //objects
        internal UDHandler uds;
        private Grain s;


        public Game1()
        {
            _instance = this;
            graphicsHandler = new GraphicsHandler(this);
            graphicsHandler.init();
            IsMouseVisible = true;
            uds = new UDHandler();
            kh = new KeyboardHandler();

        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            

            //s = new Sand(100,100,50);
            //uds.addUD(s);
            int w = GraphicsDevice.Viewport.Width;
            int h = GraphicsDevice.Viewport.Height;

            int sandSize = 50;

            uds.addUD(new Sandbox(sandSize));
            uds.addUD(new SideBar());
            uds.addUD(new Cursor());

        }

        protected override void Update(GameTime gameTime)
        {
            kh.Update();
            CurrentGameTime = gameTime;
            mouseState = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState state = Keyboard.GetState();

            uds.Update();
            previousMouseState = mouseState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //inital stuff
            var keyboardState = Keyboard.GetState();
            GraphicsDevice.Clear(Color.Yellow);

            uds.Draw();

            

            base.Draw(gameTime);
        }
    }
}
