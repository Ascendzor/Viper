using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Viper
{
    public static class Camera
    {
        public static Vector3 Position;
        public static Matrix View;
        public static Matrix Projection;

        public static void Initialize()
        {
            Position = new Vector3(100, 100, 100);
            View = Matrix.CreateLookAt(Position, new Vector3(0, 0, 0), new Vector3(0, 1, 0));
            Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, 4f / 3f, 1, 500);
        }

        public static void Update()
        {
            View = Matrix.CreateLookAt(Position, new Vector3(0, 0, 0), new Vector3(0, 1, 0));
        }
    }
}
