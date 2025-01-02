using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ZenGarden.Content.src.entities
{
    internal class Grain
    {
        internal Rectangle pos;
        private Color col;
        Texture2D tex;
        string type;
        public Grain(int x, int y, int size, Color col, string type)
        {
            pos = new Rectangle(x, y, size, size);
            this.col = col;

            tex = new Texture2D(Game1.Instance.spriteBatch.GraphicsDevice, 1, 1);
            tex.SetData(new[] { Color.White });
            this.type = type;
         }

        internal void Reset()
        {
            col = new Color (255,255,0);
        }

       
        internal void Draw()
        {
            Game1.Instance.spriteBatch.Draw(tex, pos, col);
        }

        
    }
}
