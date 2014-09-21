using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Viper
{
    public static class Map
    {
        private static Texture2D heightMap;
        private static Texture2D texture;
        private static VertexPositionNormalTexture[] vertices;
        private static int[] indices;
        private static BasicEffect effect;

        public static void Initialize(Texture2D _heightMap, Texture2D _texture)
        {
            heightMap = _heightMap;
            texture = _texture;
            SetupVertices();
            SetupIndices();
            SetupShittyStupidShit();
        }

        private static void SetupVertices()
        {
            vertices = new VertexPositionNormalTexture[heightMap.Width * heightMap.Height];
            for (int x = 0; x < heightMap.Width; x++)
            {
                for (int y = 0; y < heightMap.Height; y++)
                {
                    vertices[x + y * heightMap.Height].Position = new Vector3(x, 1, y);
                    vertices[x + y * heightMap.Height].TextureCoordinate.X = (float)x / 30.0f;
                    vertices[x + y * heightMap.Height].TextureCoordinate.Y = (float)y / 30.0f;
                    vertices[x + y * heightMap.Height].Normal = new Vector3(0, 1, 0);
                }
            }
        }

        private static void SetupIndices()
        {
            indices = new int[heightMap.Width * heightMap.Height * 6];

            int indicesCount = 0;
            for (int x = 0; x < (heightMap.Width-1); x++)
            {
                for (int y = 0; y < heightMap.Height-1; y++)
                {
                    indices[indicesCount] = x + (y * heightMap.Height); indicesCount++;
                    indices[indicesCount] = (x+1) + (y * heightMap.Height); indicesCount++;
                    indices[indicesCount] = x + ((y+1) * heightMap.Height); indicesCount++;

                    indices[indicesCount] = (x+1) + (y * heightMap.Height); indicesCount++;
                    indices[indicesCount] = (x+1) + ((y+1) * heightMap.Height); indicesCount++;
                    indices[indicesCount] = x + ((y+1) * heightMap.Height); indicesCount++;
                }
            }
        }

        private static void SetupShittyStupidShit()
        {
            effect = new BasicEffect(Game1.Device);
            effect.EnableDefaultLighting();
            effect.View = Camera.View;
            effect.Projection = Camera.Projection;
            effect.TextureEnabled = true;
            
            effect.Texture = texture;
        }

        public static void Draw()
        {
            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                Game1.Device.DrawUserIndexedPrimitives<VertexPositionNormalTexture>(PrimitiveType.TriangleList, vertices, 0, vertices.Length, indices, 0, indices.Length / 3);
            }
        }
    }
}
