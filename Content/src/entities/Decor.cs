using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenGarden.Content.src.entities
{
    internal class Decor
    {
        private Vector2 pos;
        Texture2D img;
        public Decor(int x, int y, string filePath) {
            
            pos = new Vector2(x, y);
            img = Game1.Instance.graphicsHandler.generateTexture(filePath);

        }

        internal void Draw()
        {
            Game1.Instance.spriteBatch.Draw(img, pos, Color.White);
        }
    }
}
