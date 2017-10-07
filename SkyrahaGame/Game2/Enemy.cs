﻿using System;
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
        public Enemy(Skyraha game, Vector2 Position, int speed, int Life = 100) : base(game, "Enemy", Position, Life)
        {
            this.speed = speed;

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


            ((Skyraha)this.Game).spriteBatch.Draw(Texture, new Rectangle((int)this.Position.X, (int)this.Position.Y, Texture.Width, Texture.Height), (Color.White));



            base.Draw(gameTime);
        }



        /// <summary>
        /// Enemy Updater
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {

            this.Position.Y = this.Position.Y + speed;

            





        }
    }
}