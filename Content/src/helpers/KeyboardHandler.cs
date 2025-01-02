using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenGarden.Content.src.structures
{
    using Microsoft.Xna.Framework.Input;

    public class KeyboardHandler
    {
        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;

        public void Update()
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
        }

        public bool keyPressed(Keys key)
        {
            return currentKeyboardState.IsKeyDown(key) && !previousKeyboardState.IsKeyDown(key);
        }
    }

}
