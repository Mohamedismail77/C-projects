using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ProgrammingAssignment3
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        const int WINDOW_WIDTH = 800;
        const int WINDOW_HEIGHT = 600;

        Random rand = new Random();
        Vector2 centerLocation = new Vector2(
            WINDOW_WIDTH / 2, WINDOW_HEIGHT / 2);

        // STUDENTS: declare variables for 3 rock sprites
        Texture2D sprite1;
        Texture2D sprite2;
        Texture2D sprite3;
        // STUDENTS: declare variables for 3 rocks
        Rock Rock1;
        Rock Rock2;
        Rock Rock3;
        // delay support
        const int TOTAL_DELAY_MILLISECONDS = 1000;
        int elapsedDelayMilliseconds = 0;

        // random velocity support
        const int BASE_SPEED = 5;
        Vector2 upLeft = new Vector2(-BASE_SPEED, -BASE_SPEED);
        Vector2 upRight = new Vector2(BASE_SPEED, -BASE_SPEED);
        Vector2 downRight = new Vector2(BASE_SPEED, BASE_SPEED);
        Vector2 downLeft = new Vector2(-BASE_SPEED, BASE_SPEED);

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // change resolution
            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // STUDENTS: Load content for 3 sprites
            sprite1 = Content.Load<Texture2D>("greenrock");
            sprite2 = Content.Load<Texture2D>("magentarock");
            sprite3 = Content.Load<Texture2D>("whiterock");

            // STUDENTS: Create a new random rock by calling the GetRandomRock method
            Rock1 = GetRandomRock();
            Rock2 = GetRandomRock();
            Rock3 = GetRandomRock();

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // STUDENTS: update rocks
            Rock1.Update(gameTime);
            Rock2.Update(gameTime);
            Rock3.Update(gameTime);

            // update timer
            elapsedDelayMilliseconds += gameTime.ElapsedGameTime.Milliseconds;
            if (elapsedDelayMilliseconds >= TOTAL_DELAY_MILLISECONDS)
            {
                // STUDENTS: timer expired, so spawn new rock if fewer than 3 rocks in window
                if(Rock1 == null)
                {
                    Rock1 = GetRandomRock();
                }
                if(Rock2 == null)
                {
                    Rock2 = GetRandomRock();
                }
                if(Rock3 == null)
                {
                    Rock3 = GetRandomRock();
                }
                // restart timer
                elapsedDelayMilliseconds = 0;
            }

            // STUDENTS: Check each rock to see if it's outside the window. If so
            // spawn a new random rock for it by calling the GetRandomRock method
            // Caution: Only check the property if the variable isn't null
            if(Rock1.OutsideWindow)
            {
                Rock1 = GetRandomRock();
            }
            if(Rock2.OutsideWindow)
            {
                Rock2 = GetRandomRock();
            }
            if(Rock3.OutsideWindow)
            {
                Rock3 = GetRandomRock();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // STUDENTS: draw rocks
            spriteBatch.Begin();
            Rock1.Draw(spriteBatch);
            Rock2.Draw(spriteBatch);
            Rock3.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Gets a rock with a random sprite and velocity
        /// </summary>
        /// <returns>the rock</returns>
        private Rock GetRandomRock()
        {
            // STUDENTS: Uncomment and complete the code below to randomly pick a rock sprite by calling the GetRandomSprite method
            Texture2D sprite = GetRandomSprite();

            // STUDENTS: Uncomment and complete the code below to randomly pick a velocity by calling the GetRandomVelocity method
            Vector2 velocity = GetRandomVelocity() ;

            // STUDENTS: After completing the two lines of code above, delete the following two lines of code
            // They're only included so the code I provided to you compiles
    
            // return a new rock, centered in the window, with the random sprite and velocity
            return new Rock(sprite, centerLocation, velocity, WINDOW_WIDTH, WINDOW_HEIGHT);
        }

        /// <summary>
        /// Gets a random sprite
        /// </summary>
        /// <returns>the sprite</returns>
        private Texture2D GetRandomSprite()
        {
            // STUDENTS: Uncommment and modify the code below as appropriate to return 
            // a random sprite
            int spriteNumber = rand.Next(0,3);
            if (spriteNumber == 0)
            {
                return sprite1;
            }
            else if (spriteNumber == 1)
            {
                return sprite2;
            }
            else
            {
                return sprite3;
            }

            // STUDENTS: After completing the code above, delete the following line of code
            // It's only included so the code I provided to you compiles
            
        }

        /// <summary>
        /// Gets a random velocity
        /// </summary>
        /// <returns>the velocity</returns>
        private Vector2 GetRandomVelocity()
        {
            // STUDENTS: Uncommment and modify the code below as appropriate to return 
            // a random velocity
            int velocitynumber = rand.Next(0,4);
            if (velocitynumber == 0)
            {
                return upLeft;
            }
            else if (velocitynumber == 1)
            {
                return upRight;
            }
            else if (velocitynumber == 2)
            {
                return downRight;
            }
            else
            {
                return downLeft;
            }

            // STUDENTS: After completing the code above, delete the following line of code
            // It's only included so the code I provided to you compiles
            
        }
    }
}
