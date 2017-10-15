using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;


namespace Game2 
{
    /// <summary>
    /// Player Ship
    /// </summary>
    class Player : Ship
    {
        



        private KeyboardState statenew;

        /// <summary>
        /// Player Constructor
        /// </summary>
        /// <param name="game"></param>
        /// <param name="Position">Starting Position</param>
        /// <param name="Life">Starting Lifes</param>
        public Player(Skyraha game, Vector2 Position, float Life = 1.5f) : base(game, "Player", Position, Life)
        {

        }


        /// <summary>
        /// Update Player Controls
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            KeyboardState Right = Keyboard.GetState();
            if (Right.IsKeyDown(Keys.D))
                this.Position.X += this.Speed;

            KeyboardState Up = Keyboard.GetState();
            if (Up.IsKeyDown(Keys.W))
                this.Position.Y -= this.Speed;

            KeyboardState Left = Keyboard.GetState();
            if (Left.IsKeyDown(Keys.A))
                this.Position.X -= this.Speed;

            KeyboardState Down = Keyboard.GetState();
            if (Down.IsKeyDown(Keys.S))
                this.Position.Y += this.Speed;


            #region Shoot 

            KeyboardState stateold = Keyboard.GetState();

            if (Life > 0)
            {
                if (stateold.IsKeyUp(Keys.Space) && (statenew.IsKeyDown(Keys.Space)))
                {
                    new Bullets((Skyraha)Game, new Vector2(Position.X + Texture.Width / 2, Position.Y + Texture.Height / 2), 2, 0.5f, this);
                }
            }
            statenew = stateold;
            #endregion


            // Make Player invisible if Life reach zero and darken the Background after death

            if (Life <= 0)
            {
                Visible = false;
            }
            else
            {
                Visible = true;
            }



            //Game Over

            
            if (Life < 0 )
            {
                
            }


            
               
        }
        

    }
}
