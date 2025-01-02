using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using ZenGarden.Content.src.entities;

namespace ZenGarden.Content.src.helpers
{
    internal class SandboxKeyMap
    {
        internal void Update(Sandbox s)
        {
            int mouseX = Game1.Instance.mouseState.Position.X;
            int mouseY = Game1.Instance.mouseState.Position.Y;


            MouseState ms = Game1.Instance.mouseState;
            MouseState pms = Game1.Instance.previousMouseState;
            if(ms.LeftButton == ButtonState.Pressed) {
                switch (s.ds.type)
                {
                    case "pixel":
                        int xPos = mouseX - mouseX % s.grainSize;
                        int yPos = mouseY - mouseY % s.grainSize;
                        s.grains.Add(new Grain(xPos, yPos, s.grainSize, s.ds.col));
                        break;
                    case "pFlower":
                        if(pms.LeftButton != ButtonState.Pressed) 
                            s.decorations.Add(new Decor(mouseX, mouseY, "decor\\pFlower.png"));
                        break;
                }
            }



            if (Game1.Instance.kh.keyPressed(Keys.L))
            {
                s.ds.type = "pixel";
                s.ds.col = new Color(255,255,0);

            }
            else if (Game1.Instance.kh.keyPressed(Keys.D))
            {
                s.ds.type = "pixel";
                s.ds.col = new Color(255,240,0);
            }
            else if (Game1.Instance.kh.keyPressed(Keys.W))
            {
                s.ds.type = "pixel";
                s.ds.col = new Color(0,0,255);
            }
            else if (Game1.Instance.kh.keyPressed(Keys.F))
            {
                s.ds.type = "pFlower";
            }
            else if (Game1.Instance.kh.keyPressed(Keys.R))
            {
                s.grains.Clear();
                s.decorations.Clear();

            }
        }
    }
}
