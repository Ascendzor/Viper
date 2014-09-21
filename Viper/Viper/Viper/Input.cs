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
            Console.WriteLine(mouse.X + " " + windowWidth);
            Console.WriteLine("input updating");
            if (mouse.X < (windowWidth * 0.1))
            {
                Console.WriteLine("tried to move camera");
                Camera.Position.X -= 1f;
            }
            else if (mouse.X > (windowWidth * 0.9))
            {
                Console.WriteLine("tried to move camera");
                Camera.Position.X += 1f;
            }
        }
    }
}
