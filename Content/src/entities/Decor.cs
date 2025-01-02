using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenGarden.Content.src.helpers;

namespace ZenGarden.Content.src.entities
{
    internal class Decor
    {
        private Vector2 pos;
        private Vector2 org;
        Texture2D img;
        string type;
        public Decor(int x, int y, string filePath, string type)
        {

            pos = new Vector2(x, y);
            img = Game1.Instance.graphicsHandler.generateTexture(filePath);
            org = new Vector2(img.Width / 2, img.Height / 2);
            this.type = type;
        }
        private void moveKoi(Sandbox s)
        {
            if(s.gh.getGrainType(this.pos) == "water")
                this.pos.X ++;
        }

        internal void Update(Sandbox s)
        {
            if(type == "koi")
            {
                moveKoi(s);
            }
        }

        internal void Draw()
        {
            Game1.Instance.spriteBatch.Draw(img, pos, null, Color.White, 0f, org, 1f, SpriteEffects.None, 0f);
        }
    }
}
