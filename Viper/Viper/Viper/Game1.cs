using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Viper
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static GraphicsDevice Device;

        private Pudge pudge;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Device = GraphicsDevice;
            Configure();
            
            Camera.Initialize();
            Map.Initialize(Content.Load<Texture2D>("heightmap"), Content.Load<Texture2D>("grass_texture238"));
            pudge = new Pudge(new Vector3(50, 0, 50), Content.Load<Model>("tuskarrmale"));

            Input.Initialize(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            spriteBatch = new SpriteBatch(GraphicsDevice);

            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            Input.Update(Mouse.GetState(), Keyboard.GetState());
            Camera.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Map.Draw();
            pudge.Draw();

            base.Draw(gameTime);
        }

        private void Configure()
        {
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();
        }
    }
}
