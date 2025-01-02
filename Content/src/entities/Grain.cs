using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ZenGarden.Content.src.entities
{
    internal class Grain
    {
        private Rectangle bottomPix;
        private Color col;
        Texture2D tex;
        public Grain(int x, int y, int size, Color col) {
            bottomPix = new Rectangle(x,y,size,size);
            this.col = col;

            tex = new Texture2D(Game1.Instance.spriteBatch.GraphicsDevice, 1, 1);
            tex.SetData(new[] { Color.White});
        }

        internal void Reset()
        {
            col = new Color (255,255,0);
        }

        internal void Update(drawState ds)
        {
            switch (ds.type)
            {
                case "darkSand":
                    {
                        if (bottomPix.Contains(Game1.Instance.mouseState.Position))
                            col = new Color(255, 200, 0);
                        break;
                    }
                case "lightSand":
                    {
                        if (bottomPix.Contains(Game1.Instance.mouseState.Position))
                            col = new Color(255, 255, 0);
                        break;
                    }
                case "water":
                    {
                        if (bottomPix.Contains(Game1.Instance.mouseState.Position))
                            col = new Color(0, 0, 255);
                        break;
                    }
            }
            
        }
        internal void Draw()
        {
            Game1.Instance.spriteBatch.Draw(tex, bottomPix, col);
        }

        
    }
}
