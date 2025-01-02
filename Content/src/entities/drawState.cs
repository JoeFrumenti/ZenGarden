using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenGarden.Content.src.entities
{
    internal struct drawState
    {
        public string type;
        public int size;
        public int layer = 0;
        public Color col;

        public drawState(string t, int s, Color c)
        {
            type = t;
            size = s;
            col = c;
        }
    }

    internal struct dec
    {
        public string type;
        public int size;
        public int layer = 0;

        public dec(string t, int s)
        {
            type = t;
            size = s;
        }
    }
}
