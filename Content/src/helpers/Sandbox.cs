﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenGarden.Content.src.entities;
using Color = Microsoft.Xna.Framework.Color;

namespace ZenGarden.Content.src.helpers
{
    internal class Sandbox : UD
    {
        internal GrainHandler gh;
        internal List<Decor> decorations;

        internal int grainSize;
        private int width;
        private int height;

        public drawState ds;

        private SandboxKeyMap skm;


        public Sandbox(int size)
        {
            grainSize = size;
            ds = new drawState("pixel", 1, new Color(255,230,0));
            skm = new SandboxKeyMap();
            decorations = new List<Decor>();
            gh = new GrainHandler();
        }

        internal override void Update()
        {
            
            skm.Update(this);
        }

        internal override void Draw()
        {
            foreach (Grain g in gh.getGrains())
            {
                g.Draw();
            }
            foreach(Decor decor in decorations)
            {
                decor.Draw();
            }
        }
    }
}
