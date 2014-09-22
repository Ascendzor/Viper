
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

        private Model model;

        public Pudge(Vector3 position, Model model)
        {
            this.position = position;
            this.model = model;
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
                    effect.World = Matrix.CreateTranslation(position);

                    mesh.Draw();
                }
            }
        }
    }
}
