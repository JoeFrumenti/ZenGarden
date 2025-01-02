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
        public GrainHandler(int g) { 
            grains = new List<Grain>();
            grainSize = g;
        }

        private List<Grain> grains;

        internal List<Grain> getGrains()
        {
            return grains;
        }

        internal string getGrainType(Vector2 pos)
        {
            foreach(var grain in grains) {
                Rectangle check = new Rectangle((int)grain.pos.X,(int)grain.pos.Y,grainSize,grainSize);
                if(check.Contains(pos)) 
                    return grain.getType();
                
            }

            return "lightSand";
        }

        private int getGrainByPos(int x, int y)
        {
            for(int i = 0; i < grains.Count; i++)
            {
                Vector2 pos = new Vector2(grains[i].pos.X, grains[i].pos.Y);
                if(pos.X == x && pos.Y == y)
                    return i;
            }
            return -1;
        }
        internal void addGrain(Grain grain)
        {
            int index = getGrainByPos(grain.pos.X, grain.pos.Y);
            if(index < 0)
                grains.Add(grain);
            else
                grains[index] = grain;
        }
            
        internal void Clear()
        {
            grains.Clear();
        }

    }
}
