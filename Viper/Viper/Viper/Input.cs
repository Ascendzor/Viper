using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Viper
{
    public static class Input
    {
        private static int windowWidth;
        private static int windowHeight;

        public static void Initialize(int windowWidth, int windowHeight)
        {
            Input.windowWidth = windowWidth;
            Input.windowHeight = windowHeight;
        }

        public static void Update(MouseState mouse, KeyboardState keyboard)
        {
            if (mouse.X < (windowWidth * 0.1))
            {
                Camera.Position.X += 1f;
            }
            else if (mouse.X > (windowWidth * 0.9))
            {
                Camera.Position.X -= 1f;
            }

            if (mouse.Y < (windowHeight * 0.1))
            {
                Camera.Position.Z += 1f;
            }
            else if (mouse.Y > (windowHeight * 0.9))
            {
                Camera.Position.Z -= 1f;
            }

            DevInput(mouse, keyboard);
        }

        private static void DevInput(MouseState mouse, KeyboardState keyboard)
        {
            if (keyboard.GetPressedKeys().Contains(Keys.Space))
            {
                Camera.Position.X = 0;
                Camera.Position.Z = 0;
            }
        }
    }
}
