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

        private List<Sand> grains = new List<Sand>();

        public Sandbox(int x, int y, int size)
        {
            for(int i = 0; i < x * size; i += size)
            {
                for(int j = 0; j < y * size; j += size) 
                { 
                
                    grains.Add(new Sand(i,j, size));
                
                }
            }
        }

        internal override void Update()
        {
            foreach (Sand gra in grains) {
                gra.Update();
            }
        }

        internal override void Draw()
        {
            foreach (Sand gra in grains) {
                gra.Draw();
            }
        }
    }
}
