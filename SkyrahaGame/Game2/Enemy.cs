using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Skyraha
{

    class Enemy : Ship

    {

        #region Variables

        private int speed;
        private float speedX = 2;
        private int Timer = 0;
        Random shoot = new Random();
        Random velocity = new Random();
        Random spawner = new Random();

        #endregion

        /// <summary>
        /// Enemy Constructor
        /// </summary>
        /// <param name="game"></param>
        /// <param name="Position">Starting Position</param>
        /// <param name="Life">Starting Lifes</param>
        public Enemy(Skyraha game, Vector2 Position, int speed, float Life = 2f) : base(game, "Enemy", Position, Life)
        {
            //assign speed to local speed
            this.speed = speed;

            //assign enemy a texture
            this.Texture = game.Content.Load<Texture2D>("Feind");


        }

        /// <summary>
        /// Enemy Draw
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {

            //Draw the Enemy Sprite
            ((Skyraha)this.Game).spriteBatch.Draw(Texture, new Rectangle((int)this.Position.X, (int)this.Position.Y, Texture.Width, Texture.Height), (Color.White));



            base.Draw(gameTime);
        }



        /// <summary>
        /// Enemy Updater
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            //Add Speed to the Coordinates of the enemy

            this.Position.Y += ((float)Math.Sin((double)(Position.Y / this.Game.Window.ClientBounds.Height)) * 13f + 1) * 0.3f;

            //enemy Movement

            float Velocity = 2;


            var f = Position.X / this.Game.Window.ClientBounds.Width;

            var k = 0.0f;
            if (f < 0.5f)
                k = (float)Math.Sin((double)f) * 3.0f + 1f;
            else
                k = (float)Math.Sin((double)f * -1 + 1) * 3.0f + 1f;


            Position.X += speedX * k;

            if (Position.X <= -0)
            {

                speedX = Velocity;
            }
            if (Position.X >= this.Game.Window.ClientBounds.Width - this.Texture.Width)
            {
                speedX = -Velocity;
            }




            //enemy shooting interval

            Timer += gameTime.ElapsedGameTime.Milliseconds;




            if (Timer >= 600 && Player.Death == 0)
            {
                if (Life > 0)
                {
                    new Bullets((Skyraha)Game, new Vector2(Position.X + Texture.Width / 2, Position.Y + Texture.Height / 2), -2, 0.5f, this);

                    //int shootspeed = shoot.Next(1000, 2000);
                    Timer = 0;
                    //Timer += shootspeed;
                }
            }





            base.Update(gameTime);

        }

        

       
    }
}