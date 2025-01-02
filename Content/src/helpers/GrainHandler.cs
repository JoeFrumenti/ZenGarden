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
        public GrainHandler() { 
            grains = new List<Grain>();
        }

        private List<Grain> grains;

        internal List<Grain> getGrains()
        {
            return grains;
        }

        internal void addGrain(Grain grain)
        {
            grains.Add(grain);
        }
        internal void Clear()
        {
            grains.Clear();
        }

    }
}
