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

            if (gameTime.ElapsedGameTime.Milliseconds >= 1000)
            {
                this.speed = 2;
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


            base.Update(gameTime);

        }
    }
}