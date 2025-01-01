using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenGarden.Content.src.entities;

namespace ZenGarden.Content.src.helpers
{
    internal class Sandbox : UD
    {

        private List<List<Sand>> grains = new List<List<Sand>>();
        private int grainSize;

        public Sandbox(int x, int y, int size)
        {
            grainSize = size;





            for(int i = 0; i < x * size; i += size)
            {
                grains.Add(new List<Sand>());
                for(int j = 0; j < y * size; j += size) 
                { 
                    
                    grains[i/size].Add(new Sand(i,j, size));
                
                }
            }
        }

        internal override void Update()
        {
            int mouseX = Game1.Instance.mouseState.Position.X;
            int mouseY = Game1.Instance.mouseState.Position.Y;

            Vector2 hoverOver = new Vector2(mouseX/grainSize,mouseY/grainSize);
            try {
                grains[(int)hoverOver.X][(int)hoverOver.Y].Update();
            }
            catch(System.ArgumentOutOfRangeException)
            {

            }
            finally
            {

            }

            }

        internal override void Draw()
        {
            foreach (List<Sand> gra in grains)
            {
                foreach (Sand gra2 in gra)
                {
                    gra2.Draw();
                }
            }
        }
    }
}
