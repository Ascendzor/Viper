using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Viper
{
    public static class Input
    {
        private static int windowWidth;
        private static int windowHeight;

        private static KeyboardState oldKeyboardState;
        private static MouseState oldMouse;

        //delete this shit when networking gets implemented
        public static Pudge pudge;

        public static void Initialize(int windowWidth, int windowHeight)
        {
            Input.windowWidth = windowWidth;
            Input.windowHeight = windowHeight;
        }

        public static void Update(MouseState mouse, KeyboardState keyboard)
        {
            MouseMoving(mouse);
            MouseClicking(mouse);

            DevInput(mouse, keyboard);
        }

        private static void MouseMoving(MouseState mouse)
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
        }

        private static void MouseClicking(MouseState mouse)
        {
            if (oldMouse.RightButton == ButtonState.Pressed)
            {
                if (mouse.RightButton == ButtonState.Released)
                {
                    Matrix world = Matrix.CreateTranslation(0, 0, 0);
                    Vector3 start = Game1.Device.Viewport.Unproject(new Vector3(mouse.X, mouse.Y, 0), Camera.Projection, Camera.View, world);
                    Vector3 end = Game1.Device.Viewport.Unproject(new Vector3(mouse.X, mouse.Y, 1), Camera.Projection, Camera.View, world);

                    Vector3 direction = end - start;
                    direction.Normalize();

                    Ray ray = new Ray(start, direction);

                    Vector3 goalPosition = Map.GetPosition(ray);
                    pudge.MoveTo(goalPosition);
                }
            }

            oldMouse = mouse;
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
