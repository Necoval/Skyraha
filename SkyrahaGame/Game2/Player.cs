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
        

        /// <summary>
        /// Player Constructor
        /// </summary>
        /// <param name="game"></param>
        /// <param name="Position">Starting Position</param>
        /// <param name="Life">Starting Lifes</param>
        public Player(Skyraha game, Vector2 Position, int Life = 100) : base(game, "Player", Position, Life)
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
                X += D;

            KeyboardState Up = Keyboard.GetState();
            if (Up.IsKeyDown(Keys.W))
                Y -= D;

            KeyboardState Left = Keyboard.GetState();
            if (Left.IsKeyDown(Keys.A))
                X -= D;

            KeyboardState Down = Keyboard.GetState();
            if (Down.IsKeyDown(Keys.S))
                Y += D;

            


        }

    }
}
