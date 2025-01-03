using Microsoft.Xna.Framework;
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
        internal DecorHandler decorations;

        internal int grainSize;
        private int width;
        private int height;


        public drawState ds;

        private SandboxKeyMap skm;

        public override string name => "Sandbox";

        public Sandbox(int size)
        {
            grainSize = size;
            ds = new drawState("pixel", 1, new Color(255,230,0));
            skm = new SandboxKeyMap();
            decorations = new DecorHandler();
            gh = new GrainHandler(grainSize);
        }

        internal override void Update()
        {
            
            skm.Update(this);
            foreach (Decor decor in decorations.getDecors()) {
                decor.Update(this);
            }
        }

        internal override void Draw()
        {
            for(int i = 0; i < gh.getGrains().Count; i++) 
            {
                for(int j = 0; j < gh.getGrains()[i].Count; j++) 
                {
                    gh.getGrains()[i][j].Draw();
                }
            }
            foreach(Decor decor in decorations.getDecors())
            {
                decor.Draw();
            }

        }
    }
}
