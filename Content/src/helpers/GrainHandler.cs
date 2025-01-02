using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenGarden.Content.src.entities;

namespace ZenGarden.Content.src.helpers
{
    internal class GrainHandler
    {
        private int grainSize;
        private List<List<Grain>> grains;
        public GrainHandler(int g) { 
            grains = new List<List<Grain>>();
            grainSize = g;

            int screenWidth = Game1.Instance.GraphicsDevice.Viewport.Width;
            int screenHeight = Game1.Instance.GraphicsDevice.Viewport.Height;

            for(int i = 0; i < screenWidth;  i+=grainSize) {
                grains.Add(new List<Grain>());
                for(int j = 0; j < screenHeight; j+=grainSize) {
                    grains[i/grainSize].Add(new Grain(i,j,grainSize,new Color(255,255,0), "lightSand"));
                }
            }
        }


        internal List<List<Grain>> getGrains()
        {
            return grains;
        }

        internal string getGrainType(Vector2 pos)
        {
            int i = (int)pos.X/grainSize;
            int j = (int)pos.Y/grainSize;
            return grains[i][j].getType();
        }

        private int getGrainByPos(Vector2 pos)
        {
            return 0;
        }
        internal void addGrain(Grain grain)
        {
            int i = (int)grain.pos.X / grainSize;
            int j = (int)grain.pos.Y / grainSize;
            grains[i][j] = grain;
        }
            
        internal void Clear()
        {
            grains.Clear();
        }

    }
}
