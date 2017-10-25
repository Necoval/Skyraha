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
    /// <summary>
    /// Player Ship
    /// </summary>
    class Player : Ship
    {

        static public int Death = 0; 

        
        public Texture2D Hearts1;
        public Texture2D Hearts2;
        public Texture2D Hearts3;
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


            if (Life <= 0)
            {
                Death = 1;
            }



        }



        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            ((Skyraha)this.Game).spriteBatch = new SpriteBatch(GraphicsDevice);


            //Load Images






            Hearts1 = ((Skyraha)this.Game).Content.Load<Texture2D>("Herz");
            Hearts2 = ((Skyraha)this.Game).Content.Load<Texture2D>("Herz");
            Hearts3 = ((Skyraha)this.Game).Content.Load<Texture2D>("Herz");


        }



        public override void Draw(GameTime gameTime)
        {

            #region Hearts

            //last heart dissapears when players life is 0
            if (Life >= 0.5f)
            {
                ((Skyraha)this.Game).spriteBatch.Draw(Hearts1, new Rectangle(50, 20, 50, 50), (Color.White));
            }


            // second heart dissaperas when players life is smaler 1
            if (Life >= 1f)
            {
                ((Skyraha)this.Game).spriteBatch.Draw(Hearts2, new Rectangle(100, 20, 50, 50), (Color.White));
            }

            // first heart dissapears if players life is smaller 1.5f

            if (Life == 1.5f)
            {
                ((Skyraha)this.Game).spriteBatch.Draw(Hearts3, new Rectangle(150, 20, 50, 50), (Color.White));
            }

            #endregion


            //Draw the player
            ((Skyraha)this.Game).spriteBatch.Draw(
             Texture,
             new Rectangle(
             (int)Position.X,
             (int)Position.Y,
             Texture.Width,
             Texture.Height),
             (Color.White));


            
                
            
            
        }


        
    }
}
