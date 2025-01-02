using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenGarden.Content.src.entities;

namespace ZenGarden.Content.src.helpers
{
    internal class DecorHandler
    {
        internal List<Decor> decors;
        public DecorHandler() {decors = new(); }

        internal List<Decor> getDecors() { return decors; }

        internal void Add(Decor d ) { decors.Add(d); }

        internal void Clear()  { decors.Clear(); }

    }
}
