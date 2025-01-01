using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ZenGarden.Content.src.entities;
using ZenGarden.Content.src.helpers;
using ZenGarden.Content.src.structures;
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
        internal KeyHandler kh;


        //graphics
        internal GraphicsHandler graphicsHandler;
        internal GraphicsDeviceManager _graphics;
        internal SpriteBatch spriteBatch;
        Texture2D mouseTexture;

        //objects
        internal UDHandler uds;
        private Sand s;


        public Game1()
        {
            _instance = this;
            graphicsHandler = new GraphicsHandler(this);
            graphicsHandler.init();
            IsMouseVisible = true;
            uds = new UDHandler();
            kh = new KeyHandler();

        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Mouse
            mouseTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            mouseTexture.SetData(new[] { Color.White });

            //s = new Sand(100,100,50);
            //uds.addUD(s);
            int w = GraphicsDevice.Viewport.Width;
            int h = GraphicsDevice.Viewport.Height;

            int sandSize = 100;

            uds.addUD(new Sandbox(w/sandSize + sandSize,h/sandSize + sandSize,sandSize));

        }

        protected override void Update(GameTime gameTime)
        {
            CurrentGameTime = gameTime;
            mouseState = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState state = Keyboard.GetState();

            uds.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //inital stuff
            var keyboardState = Keyboard.GetState();
            GraphicsDevice.Clear(Color.CornflowerBlue);

            uds.Draw();

            spriteBatch.Begin();
            spriteBatch.Draw(mouseTexture, new Rectangle(mouseState.X, mouseState.Y, 5,5), Color.Gray);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
