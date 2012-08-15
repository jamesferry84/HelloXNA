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


namespace HelloXNA
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class SpriteComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        public SpriteComponent(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        private Texture2D texture;
        private Vector2 position;
        private Vector2 velocity;
        private float scale;
        private float rotation;

        public Vector2 Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public Vector2 Velocity
        {
            get { return this.velocity; }
            set { this.velocity = value; }
        }


        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            
            position = new Vector2(10,10);
            velocity = new Vector2(80, 80);
            scale = 1f;
            rotation = 0f;
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            texture = Game.Content.Load<Texture2D>(@"Textures\XNA64x64");
            base.LoadContent();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            position += (velocity * (float)gameTime.ElapsedGameTime.TotalSeconds);

            
                if ((position.X + texture.Width) > GraphicsDevice.Viewport.Width || position.X < 0)
                {
                    velocity.X *= -1;
                }

                if ((position.Y + texture.Height) > GraphicsDevice.Viewport.Height || position.Y < 0)
                {
                    velocity.Y *= -1;
                }

            
            

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = Game.Services.GetService(typeof(SpriteBatch)) as SpriteBatch;
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, null, Color.White,rotation,new Vector2(0,0),scale, SpriteEffects.None, 1f);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
