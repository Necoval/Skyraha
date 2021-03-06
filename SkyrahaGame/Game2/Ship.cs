﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Skyraha
{
    /// <summary>
    /// Ship Class Definition for constructing, drawing and updating the Ships
    /// </summary>
    class Ship : DrawableGameComponent
    {
        #region Public Variables
        /// <summary>
        /// The ships name
        /// </summary>
        public string Name { get; protected set; }


        /// <summary>
        /// Points of this ship
        /// </summary>
        public int Points { get; protected set; }


        /// <summary>
        /// Healthpoints of the ship
        /// </summary>
        public float Life { get;  set; }


        /// <summary>
        /// Position of the ship
        /// </summary>
        public Vector2 Position;


        /// <summary>
        /// Create Hitbox rectangle
        /// </summary>
        public Rectangle Hitbox = new Rectangle();        
        #endregion

        #region Private Variables
        /// <summary>
        /// Maximum speed of the ship
        /// </summary>
        protected float Speed = 4;

        /// <summary>
        /// Texture of this ship
        /// </summary>
        protected Texture2D Texture;
        #endregion
        
        /// <summary>
        /// Ship Constructor, for creating Ships and setting the parameters.
        /// </summary>
        /// <param name="Name">Name of the new</param>
        /// <param name="Position">Start Position</param>
        /// <param name="Life">Ships initial healthpoints</param>
        public Ship(Skyraha Game, string Name, Vector2 Position, float Life = 3f) : base(Game)
        {
            // Announce gameobject to maingame
            Game.Components.Add(this);

            // Set initial values
            this.Name = Name;
            this.Life = Life;

            // Load default ship-texture
            this.Texture = Game.Content.Load<Texture2D>("Jäger");

            // Calculate ship position based on texture size
            this.Position = Position - new Vector2(Texture.Width, Texture.Height) / 2;


        }
        
        /// <summary>
        /// Drawing the ship with the given parameters
        /// </summary>
        /// <param name="gameTime">Current time in the draw-loop</param>
        public override void Draw(GameTime gameTime)
        {
            // Draw this ship
            ((Skyraha)this.Game).spriteBatch.Draw(
                Texture,
                new Rectangle(
                    (int)Position.X,
                    (int)Position.Y,
                    Texture.Width,
                    Texture.Height),
                (Color.White));

            base.Draw(gameTime);
        }
        
        /// <summary>
        /// Updater, keeps the position etc. up to date
        /// </summary>
        /// <param name="gameTime">Current time in the update-loop</param>
        public override void Update(GameTime gameTime)
        {
            /// Update the Hitbox
            this.Hitbox = new Rectangle(
                (int)Position.X + (Texture.Width / 4), // X
                (int)Position.Y + (Texture.Height / 4), // Y
                (int)(Texture.Width)/2, // Width
                (int)(Texture.Height)/2); // Height


            if (Life <= 0 || Position.Y >= this.Game.Window.ClientBounds.Height)
            {
                Dispose();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Adds points to this ship
        /// </summary>
        /// <param name="Amount">Amount of added points</param>
        public void AddPoints(int Amount)
        {
            this.Points += Amount;
        }

        /// <summary>
        /// Death Function, kills the Ship if the life points reach zero
        /// </summary>
        public void Kill()
        {
            this.Life = 0;
        }

        protected override void Dispose(bool disposing)
        {
            if(Game.Components != null)
                Game.Components.Remove(this);

            base.Dispose(disposing);
        }
    }
}