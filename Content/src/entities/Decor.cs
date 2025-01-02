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
        Random random;

        Thread thread;

        //koi
        float swimTimer = 0;
        Vector2 swimDir = new Vector2(0,0);
        float koiSpeed = 100;
        float swimWaitTimer = 0;

        public Decor(int x, int y, string filePath, string type)
        {

            pos = new Vector2(x, y);
            img = Game1.Instance.graphicsHandler.generateTexture(filePath);
            org = new Vector2(img.Width / 2, img.Height / 2);
            this.type = type;
            random = new Random();
        }

        private bool checkWater(Vector2 dir,Sandbox s)
        {

            int currentX = (int)this.pos.X / s.grainSize;
            int currentY = (int)this.pos.Y / s.grainSize;

            return (s.gh.getGrainType(currentX + (int)dir.X, currentY + (int)dir.Y) == "water" &&
                    s.gh.getGrainType(currentX + (int)dir.X * 2, currentY + (int)dir.Y * 2) == "water");
                
        }


        private void swim(Vector2 dir)
        {   
            float deltaTime = (float)Game1.Instance.CurrentGameTime.ElapsedGameTime.TotalSeconds;
            if(swimWaitTimer > 0)
            {
                swimWaitTimer -= deltaTime;
                if(swimWaitTimer <= 0)
                    swimTimer = 1;
            }
            if(swimTimer > 0) { 
                pos += dir * deltaTime * koiSpeed;
                swimTimer -= deltaTime;
            }
            
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


                
                if(swimWaitTimer <=0 && swimTimer <=0 && possibleDirections.Count > 0)
                {
                    swimWaitTimer = 1 + (float)(random.NextDouble() * 2);
                    swimDir = possibleDirections[random.Next(0,possibleDirections.Count)];
                }

                if(swimWaitTimer > 0 || swimTimer >0)
                { 
                    swim(swimDir);
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
