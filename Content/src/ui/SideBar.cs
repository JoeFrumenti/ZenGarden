using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ZenGarden.Content.src.entities;

namespace ZenGarden.Content.src.ui
{
    internal class SideBar : UD
    {
        public override string name => "SideBar";
        private int width = 150;
        private int height;
        Vector2 anchor = new Vector2(0,0);

        private bool open = false;

        Texture2D openTex;
        Texture2D closeTex;

        Rectangle closeButton;
        Rectangle openButton;
        Rectangle house;

        public SideBar()
        {
            height = Game1.Instance.GraphicsDevice.Viewport.Height;
            openTex = Game1.Instance.graphicsHandler.generateTexture("ui\\openTab.png");
            closeTex = Game1.Instance.graphicsHandler.generateTexture("ui\\closeTab.png");
             
            closeButton = new Rectangle(width-50,height/2,50,50);
            openButton = new Rectangle(0, height / 2, 50, 50);
            house = new Rectangle((int)anchor.X, (int)anchor.Y, width, height);
        }
        internal override void Update()
        {
            MouseState ms = Game1.Instance.mouseState;
            if(ms.LeftButton == ButtonState.Pressed && Game1.Instance.previousMouseState.LeftButton != ButtonState.Pressed) {
                if(open) {
                    if(closeButton.Contains(ms.Position))
                        open = false;
                }
                else
                {
                    if (openButton.Contains(ms.Position))
                        open = true;
                }
            }
        }


        internal override void Draw()
        {
            if (open)
            {
                Texture2D tex = Game1.Instance.graphicsHandler.generateTexture(new Color(10, 10, 10));
                
                Game1.Instance.spriteBatch.Draw(tex, house, Color.White);
                Game1.Instance.spriteBatch.Draw(closeTex, closeButton, Color.White);

            }
            else 
            { 
                Rectangle openButton = new Rectangle(0,height/2, 50,50);
                Game1.Instance.spriteBatch.Draw(openTex, openButton, Color.White);
            }
        }
       
    }
}
