﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyraha
{
    class Bullets : DrawableGameComponent
    {

        #region Variables
        public float Damage = 0;
        public int speed { get; set; }
        private AdvTexture Texture;
        public Vector2 Position;
        Rectangle Hitbox = new Rectangle();
        Ship Owner;
        

        #endregion

        /// <summary>
        /// Bullet
        /// </summary>
        /// <param name="game"></param>
        /// <param name="position">spawn position</param>
        /// <param name="speed">bullet speed</param>
        /// <param name="Damage">damage of the bullet</param>
        public Bullets(Skyraha bullet, Vector2 position, int speed, float Damage, Ship Owner) : base(bullet)

        {
            bullet.Components.Add(this);

            this.Damage = Damage;
            this.Owner = Owner;
            this.speed = speed;

            this.Texture = new AdvTexture(
                bullet.Content.Load<Texture2D>("Schuss2"),
                new Vector2(64),
                18,
                25);

            this.Texture.AnimationSequences.Add("Charge", new int[7] { 0, 1, 2, 3, 4, 5, 6 });
            this.Texture.AnimationSequences.Add("Pulse", new int[8] { 7, 8, 9, 10, 11, 12, 13, 14 });
            this.Texture.AnimationSequences.Add("Kill", new int[3] { 15, 16, 17 });

            this.Texture.Play(false, "Charge");



            this.Position = position - (new Vector2(Texture.Width, Texture.Height) * Damage) /2 ;


        }

        #region Draw Methode
        /// <summary>
        /// Draw
        /// </summary>
        /// <param name="gameTime"></param>
        
        
        public override void Draw(GameTime gameTime)
        {

            this.Texture.Draw(gameTime,
                ((Skyraha)this.Game).spriteBatch,
                new Rectangle((int)Position.X, (int)Position.Y,
                (int)(Texture.Width * Damage), (int)(Texture.Height * Damage)),
                Color.Red,
                0,
                Vector2.Zero,
                SpriteEffects.None,
                0);

            //((Skyraha)this.Game).spriteBatch.Draw(this.Texture, new Rectangle(X, Y, Texture.Width, Texture.Height), (Color.White));



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

            /// Set Speed of the Bullet
            Position.Y = Position.Y - speed;


            #region Bullet Animation Stages

            if (!this.Texture.AnimationRunning)
                this.Texture.Play(true, "Pulse");


            /*if (Keyboard.GetState().IsKeyDown(Keys.Space))
                this.Texture.Play(false, "Kill");
            */
            #endregion



            /// Update the position of the Hitbox
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y,(int)(Texture.Width * Damage), (int)(Texture.Height * Damage));

            /// CHeck if Hitbox Bullet hits Hittbox Ship

            Ship ShipHit = null;
            foreach(var comp in Game.Components)
            {
                if(comp is Ship)
                {
                    if ((Ship)comp != Owner) 
                    {
                        if (((Ship)comp).Hitbox.Intersects(this.Hitbox) && ((Ship)comp).Life > 0) 
                        {
                            if (this.Visible == true)
                            {
                                ShipHit = (Ship)comp;
                            }
                        }
                    }                   
                }
            }

            if(ShipHit != null)
            {
                ShipHit.Life = ShipHit.Life - Damage;

                this.Texture.Play(false, "Kill");
                Dispose();
            }


            // make invisible if out of the window

            var screensize = this.Game.Window.ClientBounds;
            screensize.X = 0;
            screensize.Y = 0;
            if (!screensize.Intersects(Hitbox))
            {
                Dispose();
            }

            base.Update(gameTime);
        }

        #endregion


        protected override void Dispose(bool disposing)
        {
            if (Game.Components != null)
                Game.Components.Remove(this);

            base.Dispose(disposing);
        }




    }
}
