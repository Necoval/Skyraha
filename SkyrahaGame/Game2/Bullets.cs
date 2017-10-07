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
        private AdvTexture Texture;
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

            this.Texture = new AdvTexture(
                game.Content.Load<Texture2D>("Schuss2"),
                new Vector2(64),
                18,
                25);

            this.Texture.AnimationSequences.Add("Charge", new int[7] { 0, 1, 2, 3, 4, 5, 6 });
            this.Texture.AnimationSequences.Add("Pulse", new int[8] { 7, 8, 9, 10, 11, 12, 13, 14 });
            this.Texture.AnimationSequences.Add("Kill", new int[3] { 15, 16, 17 });

            this.Texture.Play(false, "Charge");



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

            this.Texture.Draw(
                gameTime,
                ((Skyraha)this.Game).spriteBatch,
                 new Rectangle(X, Y, Texture.Width/3, Texture.Height/3),
                 Color.White,
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
            Y = Y - speed;

            if (!this.Texture.AnimationRunning)
                this.Texture.Play(true, "Pulse");


            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                this.Texture.Play(false, "Kill");


            base.Update(gameTime);
        }

        #endregion






    }
}
