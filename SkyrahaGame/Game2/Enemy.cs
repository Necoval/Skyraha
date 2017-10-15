using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2
{

    class Enemy : Ship

    {
        #region Variables
        private int speed;
        private float speedX = 3f;
        private int Timer = 0;
        private int TimerSpawn;
        Random shoot = new Random();
        private int Timer2 = 0;
        private int shootspeed = 0;

        #endregion

        /// <summary>
        /// Enemy Constructor
        /// </summary>
        /// <param name="game"></param>
        /// <param name="Position">Starting Position</param>
        /// <param name="Life">Starting Lifes</param>
        public Enemy(Skyraha game, Vector2 Position, int speed, float Life = 1.5f) : base(game, "Enemy", Position, Life)
        {
            //assign speed to local speed
            this.speed = speed;

            //assign enemy a texture
            this.Texture = game.Content.Load<Texture2D>("Feind");

            // Calculate ship position based on texture size
            this.Position = Position - new Vector2(Texture.Width, Texture.Height) / 2;

            





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
            this.Position.Y = this.Position.Y + speed;

            //enemy Movement

            Position.X += speedX;

            if (Position.X <= 50)
            {
                speedX = 3f;
            }
            if (Position.X >= 600)
            {
                speedX = -3f;
            }

            //enemy shooting interval

            Timer += 10;

            if (Timer2 == 2000)
            {
                int shootspeed = shoot.Next(1000, 2000);
            }

            if (Timer == 0)
            {
                
                if (Timer == shootspeed)
                {
                    if (Life > 0)
                    {
                        new Bullets((Skyraha)Game, new Vector2(Position.X + Texture.Width / 2, Position.Y + Texture.Height / 2), -1, 0.5f, this);
                        Timer = 0;
                        Timer2 = 0;
                    }
                }
            }
            
            
            
            


            // Make enemy invisible if Life  reach zero

            if (Life <= 0)
            {
                Visible = false;
            }
            else
            {
                Visible = true;
            }
            //enemy spawning interval

            TimerSpawn += 10;

            if (TimerSpawn == 4000)
            {
                new Enemy((Skyraha)Game, new Vector2(200, -200), 1);

            }

            base.Update(gameTime);

        }
    }
}