using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Threading;
using ZenGarden.Content.src.helpers;

namespace ZenGarden.Content.src.entities
{
    public class Decor
    {
        internal Vector2 pos;
        private Vector2 org;
        Texture2D img;
        string type;
        internal Random random;

        Thread thread;


        public Decor(int x, int y, string filePath, string type)
        {

            pos = new Vector2(x, y);
            img = Game1.Instance.graphicsHandler.generateTexture(filePath);
            org = new Vector2(img.Width / 2, img.Height / 2);
            this.type = type;
            random = new Random();
        }




        internal virtual void Update(Sandbox s)
        {
            
        }

        internal virtual void Draw()
        {
            Game1.Instance.spriteBatch.Draw(img, pos, null, Color.White, 0f, org, 1f, SpriteEffects.None, 0f);
        }
    }
}
