using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenGarden.Content.src.entities;

namespace ZenGarden.Content.src.core
{
    internal class Cursor : UD
    {
        MouseState mouseState;
        Texture2D mouseTexture;
        public Cursor()
        {
            mouseTexture = new Texture2D(Game1.Instance.spriteBatch.GraphicsDevice, 1, 1);
            mouseTexture.SetData(new[] { Color.White });
        }
        internal override void Update()
        {
            mouseState = Game1.Instance.mouseState;
        }
        internal override void Draw()
        {
            Game1.Instance.spriteBatch.Draw(mouseTexture, new Rectangle(mouseState.X, mouseState.Y, 5, 5), Color.Gray);
        }

        
    }
}
