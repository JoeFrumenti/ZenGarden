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
            {
                //get water in adjacent directions
                int currentX = (int)this.pos.X / s.grainSize;
                int currentY = (int)this.pos.Y / s.grainSize;

                List<Vector2> possibleDirections = new List<Vector2>();
                
                //left
                bool open = true;
                for (int i = 0; i < 3; i ++)
                {
                    if(s.gh.getGrainType(currentX - 1, currentY + i - 1) != "water")
                        open = false;
                }
                if(open)
                    possibleDirections.Add(new Vector2(-1, 0));

                //up
                open = true;
                for (int i = 0; i < 3; i++)
                {
                    if (s.gh.getGrainType(currentX + i - 1, currentY - 1) != "water")
                        open = false;
                }
                if (open)
                    possibleDirections.Add(new Vector2(0, -1));

                //right
                open = true;
                for (int i = 0; i < 3; i++)
                {
                    if (s.gh.getGrainType(currentX + 1, currentY + i - 1) != "water")
                        open = false;
                }
                if (open)
                    possibleDirections.Add(new Vector2(1, 0));

                //down
                open = true;
                for (int i = 0; i < 3; i++)
                {
                    if (s.gh.getGrainType(currentX + i - 1, currentY + 1) != "water")
                        open = false;
                }
                if (open)
                    possibleDirections.Add(new Vector2(0, 1));




                foreach(Vector2 direction in possibleDirections)
                    pos += direction;
            }
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
