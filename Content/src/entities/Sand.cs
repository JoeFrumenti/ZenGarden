using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        public Sand(int x, int y, int size) {
            grain = new Rectangle(x,y,size,size);
        }

        internal override void Update()
        {
            
        }
        internal override void Draw()
        {
            Texture2D tex = new Texture2D(Game1.Instance.spriteBatch.GraphicsDevice, 1, 1);
            tex.SetData(new[] { Color.White });
            Game1.Instance.spriteBatch.Draw(tex, grain, Color.White);
        }

        
    }
}
