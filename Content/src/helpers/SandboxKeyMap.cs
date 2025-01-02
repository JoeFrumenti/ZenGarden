﻿using Microsoft.Xna.Framework;
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
                int xPos = mouseX - mouseX%s.grainSize;
                int yPos = mouseY - mouseY%s.grainSize;
                s.grains.Add(new Grain(xPos,yPos, s.grainSize, s.ds.col));
            }



            if (Game1.Instance.kh.keyPressed(Keys.L))
            {
                s.ds.type = "lightSand";
            }
            else if (Game1.Instance.kh.keyPressed(Keys.D))
            {
                s.ds.type = "darkSand";
            }
            else if (Game1.Instance.kh.keyPressed(Keys.W))
            {
                s.ds.type = "water";
            }
            else if (Game1.Instance.kh.keyPressed(Keys.F))
            {
                s.ds.type = "pFlower";
            }
            else if (Game1.Instance.kh.keyPressed(Keys.R))
            {
                s.grains.Clear();

            }



        }
    }
}