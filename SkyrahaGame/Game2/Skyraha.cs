using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Game2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// 
    
    public class Skyraha : Game 
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        private Texture2D Texture;
        public Texture2D pausescreen;
        SpriteBatch spriteBatch2;    
        Rectangle rectangle1;
        Rectangle rectangle2;
        
        




        public Skyraha()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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




            new Enemy(this, new Vector2(200, -200), 0);
            new Enemy(this, new Vector2(200, 20), 0);

            new Player(this, new Vector2(100,300));

            

            #endregion
            

            rectangle1 = new Rectangle(0,0, 1920, 1080);
            rectangle2 = new Rectangle(0,-1080, 1920, 1080);


            base.Initialize();
        }

        




        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            //Load Images

            spriteBatch2 = new SpriteBatch(GraphicsDevice);
            Texture = this.Content.Load<Texture2D>("Hintergrund");
            pausescreen = this.Content.Load<Texture2D>("Pause");






        }

       
        protected override void UnloadContent()
        {
         

            // TODO: Unload any non ContentManager content here
        }

        





        protected override void Update(GameTime gameTime)
        {
            #region Background
            if (rectangle1.Y  >= 1080)
                rectangle1.Y = rectangle2.Y - Texture.Height;

            if (rectangle2.Y  >= 1080)
                rectangle2.Y = rectangle1.Y - Texture.Height;

            rectangle1.Y += 5;
            rectangle2.Y += 5;
            #endregion

            
                
            

            

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


           




            base.Draw(gameTime);


            spriteBatch.End();
        }
    }
}
