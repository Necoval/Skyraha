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
    /// Ship Class Definition
    /// </summary>
    class Ship : DrawableGameComponent
    {
        #region Variables
        public string Name {get; private set;}
        public int Punkte {get; private set;}
        public int Life {get; private set;}
        public int X = 0;
        public int Y = 0;
        public int D = 4;
        
        

        private Texture2D Texture;

        #endregion

        #region Constructors
        /// <summary>
        /// Ship erstellen
        /// </summary>
        /// <param name="Name">Name des Schiffs</param>
        /// <param name="Position">Start Position</param>
        /// <param name="Leben">Anzahl an Leben</param>
        public Ship(Skyraha game, string Name, Vector2 Position, int Life = 100) : base(game)
        {
            game.Components.Add(this);

            this.Name = Name;
            this.Life = Life;


            this.Texture = game.Content.Load<Texture2D>("Jäger");

            X = (int)Position.X - Texture.Width / 2;
            Y = (int)Position.Y - Texture.Height / 2;




        }
        #endregion


        #region Draw Methode
        /// <summary>
        /// Draw
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
        /// Draw
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            
            base.Update(gameTime);
        }

        #endregion


        /// <summary>
        /// Point Summary
        /// </summary>
        /// <param name="totalPoints">All Points of the Player</param>
        public void AddPoints(int totalPoints)    
        {
            Punkte += totalPoints;
        }

        /// <summary>
        /// Death
        /// </summary>
        public void Kill()                
        {
            if (Life >0)
            {
                Life = 0;
            }
        }

        
    }
}
    
