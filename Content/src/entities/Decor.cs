using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Threading;
using ZenGarden.Content.src.helpers;

namespace ZenGarden.Content.src.entities
{
    internal class Decor
    {
        private Vector2 pos;
        private Vector2 org;
        Texture2D img;
        string type;

        Thread thread;

        //koi
        float swimTimer = 0;
        Vector2 swimDir = new Vector2(0,0);
        float koiSpeed = 100;

        public Decor(int x, int y, string filePath, string type)
        {

            pos = new Vector2(x, y);
            img = Game1.Instance.graphicsHandler.generateTexture(filePath);
            org = new Vector2(img.Width / 2, img.Height / 2);
            this.type = type;
        }

        private bool checkWater(Vector2 dir,Sandbox s)
        {

            int currentX = (int)this.pos.X / s.grainSize;
            int currentY = (int)this.pos.Y / s.grainSize;

            return (s.gh.getGrainType(currentX + (int)dir.X * 2, currentY + (int)dir.Y * 2) == "water");
                
        }

        private void swim(Vector2 dir)
        {
            float deltaTime = (float)Game1.Instance.CurrentGameTime.ElapsedGameTime.TotalSeconds;
            pos += dir * deltaTime * koiSpeed;
            swimTimer -= deltaTime;
            
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
                if (checkWater(new Vector2(-1,0),s))
                    possibleDirections.Add(new Vector2(-1,0));

                //right
                if (checkWater(new Vector2(1, 0), s))
                    possibleDirections.Add(new Vector2(1, 0));

                //up
                if (checkWater(new Vector2(0, 1), s))
                    possibleDirections.Add(new Vector2(0, 1));

                //down
                if (checkWater(new Vector2(0, -1), s))
                    possibleDirections.Add(new Vector2(0, -1));


                    //Console.WriteLine(possibleDirections[0]);
                
                if(swimTimer <=0 && possibleDirections.Count > 0)
                {
                    swimTimer = 1;
                    swimDir = possibleDirections[0];
                }

                if(swimTimer > 0)
                { 
                    swim(swimDir);
                    Console.WriteLine(swimTimer);
                }
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
