using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Skyraha
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// 

    public class Skyraha : Game
    {
        GraphicsDeviceManager graphics;


        #region Textures
        public SpriteBatch spriteBatch;
        private Texture2D Texture;
        private Texture2D Ende;
        public Texture2D pausescreen;
        SpriteBatch spriteBatch2;
        Rectangle rectangle1;
        Rectangle rectangle2;
        #endregion


        private SpriteFont Font;
        private int score = 0;



        public Skyraha()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.Window.AllowUserResizing = true;

            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 1200;
            graphics.ApplyChanges();

            this.Window.ClientSizeChanged += Window_ClientSizeChanged;

            this.Window.Title = "Skyraha";
        }

        private void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            graphics.PreferredBackBufferHeight = this.Window.ClientBounds.Height;
            graphics.PreferredBackBufferWidth = this.Window.ClientBounds.Width;
            graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            /*
              #region Window Settings

              graphics.IsFullScreen = true;
              this.Window.IsBorderless = false;
              graphics.ApplyChanges();

              #endregion
              */
            #region Units
            

            //Create Player

            new Player(this, new Vector2(100, 300));




            #endregion


            rectangle1 = new Rectangle(0, 0, 1920, 1080);
            rectangle2 = new Rectangle(0, -1080, 1920, 1080);


            base.Initialize();
        }






        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            //Load Images

            spriteBatch2 = new SpriteBatch(GraphicsDevice);
            Texture = Content.Load<Texture2D>("Hintergrund");

            Font = Content.Load<SpriteFont>("Score");

            Ende = Content.Load<Texture2D>("Relia");


        }


        protected override void UnloadContent()
        {


            // TODO: Unload any non ContentManager content here
        }






        float TimerSpawn = 2000;
        float TimerSpawn2 = 2000;
        Random random = new Random();
        protected override void Update(GameTime gameTime)
        {
            #region Background
            if (rectangle1.Y >= 1080)
                rectangle1.Y = rectangle2.Y - Texture.Height;

            if (rectangle2.Y >= 1080)
                rectangle2.Y = rectangle1.Y - Texture.Height;

            rectangle1.Y += 5;
            rectangle2.Y += 5;
            #endregion


            //enemy spawning interval and spawn position

            TimerSpawn += gameTime.ElapsedGameTime.Milliseconds;
            TimerSpawn2 += gameTime.ElapsedGameTime.Milliseconds;

            if (TimerSpawn >= 2000 && Player.Death == 0)
            {
                int Spawner = random.Next(0, this.Window.ClientBounds.Width);
                new Enemy(this, new Vector2(Spawner, 50), 1,2);
                TimerSpawn = 0;
            }
            


            //add score for surviving



            if (Player.Death != 1)
            {
                score += 1;
            }
            
            




            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);








            base.Update(gameTime);
        }












        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin();


            spriteBatch.Draw(Texture, rectangle1, Color.White);
            spriteBatch.Draw(Texture, rectangle2, Color.White);


            spriteBatch.DrawString(Font, "Score" + score, new Vector2(75, 70), Color.Black);
            
            spriteBatch.DrawString(Font, this.Components.Count().ToString(), new Vector2(75, 90), Color.Black);

            if (Player.Death == 1)
            {
                
                spriteBatch.DrawString(Font, "Score" + score, new Vector2(340, 270), Color.Black);
            }


            base.Draw(gameTime);


            spriteBatch.End();
        }
    }
}