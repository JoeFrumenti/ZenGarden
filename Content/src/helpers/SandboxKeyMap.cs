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


            int screenWidth = Game1.Instance.GraphicsDevice.Viewport.Width;
            int screenHeight = Game1.Instance.GraphicsDevice.Viewport.Height;


            MouseState ms = Game1.Instance.mouseState;
            MouseState pms = Game1.Instance.previousMouseState;
            if(ms.LeftButton == ButtonState.Pressed) {
                switch (s.ds.type)
                {
                    
                    case "pFlower":
                        if(pms.LeftButton != ButtonState.Pressed) 
                            s.decorations.Add(new Decor(mouseX, mouseY, "decor\\pFlower.png", "idle"));
                        break;
                    case "koi":
                        if (pms.LeftButton != ButtonState.Pressed)
                            s.decorations.Add(new Decor(mouseX, mouseY, "decor\\fish.png", "koi"));
                        break;

                    default:
                        int xPos = mouseX - mouseX%s.grainSize;
                        int yPos = mouseY - mouseY % s.grainSize;
                        s.gh.addGrain(new Grain(xPos, yPos, s.grainSize, s.ds.col, s.ds.type));
                        break;
                }
            }



            if (Game1.Instance.kh.keyPressed(Keys.L))
            {
                s.ds.type = "lightSand";
                s.ds.col = new Color(255,255,0);

            }
            else if (Game1.Instance.kh.keyPressed(Keys.D))
            {
                s.ds.type = "darkSand";
                s.ds.col = new Color(255,230,0);
            }
            else if (Game1.Instance.kh.keyPressed(Keys.W))
            {
                s.ds.type = "water";
                s.ds.col = new Color(0,0,255);
            }
            else if (Game1.Instance.kh.keyPressed(Keys.F))
            {
                s.ds.type = "pFlower";
            }
            else if (Game1.Instance.kh.keyPressed(Keys.K))
            {
                s.ds.type = "koi";
            }
            else if (Game1.Instance.kh.keyPressed(Keys.R))
            {
                s.gh.Clear();
                s.decorations.Clear();

            }
        }
    }
}
