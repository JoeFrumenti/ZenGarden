using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ZenGarden.Content.src.entities
{
    internal class Sand : UD
    {
        private Rectangle grain;
        private Color col;
        Texture2D tex;
        public Sand(int x, int y, int size) {
            grain = new Rectangle(x,y,size,size);
            col = new Color(255,255,0);

            tex = new Texture2D(Game1.Instance.spriteBatch.GraphicsDevice, 1, 1);
            tex.SetData(new[] { Color.White});
        }

        internal override void Update()
        {
            if(grain.Contains(Game1.Instance.mouseState.Position))
                col = new Color(255,200,0);
        }
        internal override void Draw()
        {
            
            Game1.Instance.spriteBatch.Draw(tex, grain, col);
        }

        
    }
}
