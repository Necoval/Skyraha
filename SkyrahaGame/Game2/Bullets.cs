using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    class Bullets : DrawableGameComponent
    {

        #region Variables
        public int Damage = 20;
        public int speed { get; set; }
        private Texture2D Texture;
        public int X = 0;
        public int Y = 0;
        

        #endregion

        /// <summary>
        /// Bullet
        /// </summary>
        /// <param name="game"></param>
        /// <param name="position">spawn position</param>
        /// <param name="speed">bullet speed</param>
        /// <param name="Damage">damage of the bullet</param>
        public Bullets(Skyraha game, Vector2 position, int speed, int Damage) : base(game)

        {
            game.Components.Add(this);

            this.speed = speed;

            this.Texture = game.Content.Load<Texture2D>("Schuss");


            X = (int)position.X - Texture.Width / 2;
            Y = (int)position.Y - Texture.Height / 2;



        }

        #region Draw Methode
        /// <summary>
        /// Draw
        /// </summary>
        /// <param name="gameTime"></param>
        
        
        public override void Draw(GameTime gameTime)
        {
            

            ((Skyraha)this.Game).spriteBatch.Draw(this.Texture, new Rectangle(X, Y, Texture.Width, Texture.Height), (Color.White));



            base.Draw(gameTime);
        }
        #endregion
                                

        #region Update Method
        /// <summary>
        /// Draw
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            Y = Y - speed;
            

            



            base.Update(gameTime);
        }

        #endregion






    }
}
