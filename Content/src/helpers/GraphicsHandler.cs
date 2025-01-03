
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Numerics;
using System;
using Microsoft.Xna.Framework.Content;
using Vector2 = System.Numerics.Vector2;
using ZenGarden;

namespace ZenGarden.Content.src.structures
{
    internal class GraphicsHandler
    {
        string assetPath = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "Content\\assets");


        Matrix scale = Matrix.CreateScale(1, 1, 1);
        private Game1 game;
        private SpriteBatch spriteBatch;
        private GameTime gameTime;

        internal GraphicsHandler(Game1 game)
        {
            this.game = game;
            spriteBatch = game.spriteBatch;
        }

        internal void setGametime(GameTime gametime)
        {
            gameTime = gametime;
        }
        internal void setScale(float s)
        {
            scale = Matrix.CreateScale(s, s, 1f);
        }
        internal Matrix getScale()
        {
            return scale;
        }

        internal void init()
        {
            game._graphics = new GraphicsDeviceManager(game);
            game.Content.RootDirectory = "Content";
            game.IsMouseVisible = true;

            game._graphics.IsFullScreen = true;

            game._graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            game._graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        }

        internal void draw()
        {


            setScale(2);
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
            spriteBatch.Begin(transformMatrix: getScale());
            spriteBatch.End();
        }

        internal Texture2D generateTexture(Color col)
        {
            Texture2D tex = new Texture2D(Game1.Instance.spriteBatch.GraphicsDevice, 1, 1);
            tex.SetData(new[] { Color.White });
            return tex;
        }
        internal Texture2D generateTexture(string filePath)
        {
            try
            {
                Texture2D tempTex = null;
                SpriteBatch _spriteBatch = new SpriteBatch(game.GraphicsDevice);
                //C:\Users\joefr\Desktop\Gamedev\WhatAmI\Content\assets\textures\env\green16.png
                // TODO: use this.Content to load your game content here
                using var stream = File.OpenRead(Path.Combine(assetPath, filePath));
                {
                    tempTex = Texture2D.FromStream(game.GraphicsDevice, stream);
                }
                return tempTex;

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error: Unable to load texture at 'Textures/{filePath}'. Returning a default texture");
                return generateFallbackTexture();
            }
        }

        private Texture2D generateFallbackTexture()
        {
            Texture2D tempTex = null;
            SpriteBatch _spriteBatch = new SpriteBatch(game.GraphicsDevice);

            // TODO: use this.Content to load your game content here
            using (var stream = File.OpenRead(assetPath + "\\assets\\textures\\general\\fallback.png"))
            {
                tempTex = Texture2D.FromStream(game.GraphicsDevice, stream);
            }
            return tempTex;
        }
    }
}
