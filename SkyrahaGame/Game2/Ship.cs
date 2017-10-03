using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2
{
    /// <summary>
    /// Ship Class Definition for constructing, drawing and updating the Ships
    /// </summary>
    class Ship : DrawableGameComponent
    {
        #region Variables

        public string name {get; private set;} // The ships Name
        public int points {get; private set;}  // For keeping tracks of the points
        public int life {get; private set;}    // For setting the life of the ship
        public int X = 0;
        public int Y = 0;
        public int D = 4;
        
        

        private Texture2D Texture;

        #endregion

        #region Constructors
        /// <summary>
        /// Ship Constructor, for creating Ships and setting the parameters.
        /// </summary>
        /// <param name="Name">Name des Schiffs</param>
        /// <param name="Position">Start Position</param>
        /// <param name="Leben">Anzahl an Leben</param>
        public Ship(Skyraha game, string name, Vector2 Position, int life = 100) : base(game)
        {
            game.Components.Add(this);

            this.name = name;
            this.life = life;

            
            this.Texture = game.Content.Load<Texture2D>("Jäger");      

            X = (int)Position.X - Texture.Width / 2;
            Y = (int)Position.Y - Texture.Height / 2;


        }
        #endregion


        #region Draw Methode
        /// <summary>
        /// Drawing the ship with the given parameters
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            ((Skyraha)this.Game).spriteBatch.Draw(Texture, new Rectangle(X, Y, Texture.Width, Texture.Height), (Color.White));
            


            base.Draw(gameTime);
        }
        #endregion


        #region Update Method
        /// <summary>
        /// Updater, keeps the position etc. up to date
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            
            base.Update(gameTime);
        }

        #endregion


        /// <summary>
        /// Point Summary , keeps track of the gained Points
        /// </summary>
        /// <param name="totalPoints">All Points of the Player</param>
        public void AddPoints(int totalPoints)    
        {
            points += totalPoints;
        }

        /// <summary>
        /// Death Function, kills the Ship if his life points reach zero
        /// </summary>
        public void Kill()                
        {
            if (life >0)
            {
                life = 0;
            }
        }

        
    }
}
    
