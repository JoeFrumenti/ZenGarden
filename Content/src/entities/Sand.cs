using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenGarden.Content.src.entities
{
    internal class Sand : UD
    {
        private Rectangle grain;
        private Color col;
        public Sand(int x, int y, int size) {
            grain = new Rectangle(x,y,size,size);
            col = new Color(255,255,0);
        }

        internal override void Update()
        {
            MouseState ms = Mouse.GetState();
            if(grain.Contains(ms.Position))
                col = new Color(255,200,0);
        }
        internal override void Draw()
        {
            Texture2D tex = new Texture2D(Game1.Instance.spriteBatch.GraphicsDevice, 1, 1);
            tex.SetData(new[] { Color.White });
            Game1.Instance.spriteBatch.Draw(tex, grain, col);
        }

        
    }
}
