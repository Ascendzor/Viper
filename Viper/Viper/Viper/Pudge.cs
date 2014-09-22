
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Viper
{
    public class Pudge
    {
        private Vector3 position;
        private Vector3 goalPosition;
        private float velocity;

        private Model model;

        public Pudge(Vector3 position, Model model)
        {
            this.position = position;
            this.goalPosition = position;
            velocity = 1;

            this.model = model;
        }

        public void Update()
        {
            if ((goalPosition - position).Length() > 1)
            {
                Vector3 direction = goalPosition - position;
                direction.Normalize();

                position += direction * velocity;
            }
        }

        public void Draw()
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.View = Camera.View;
                    effect.Projection = Camera.Projection;
                    effect.World = Matrix.CreateScale(0.25f) * Matrix.CreateTranslation(position);

                    mesh.Draw();
                }
            }
        }

        public void MoveTo(Vector3 goalPosition)
        {
            this.goalPosition = goalPosition;
        }
    }
}
