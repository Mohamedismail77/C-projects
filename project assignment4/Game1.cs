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

namespace ProgrammingAssignment4
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
        Vector2 location;
        Vector2 pickup_location;
        // teddy support
        Texture2D teddySprite;
        Teddy teddy;

        // pickup support
        Texture2D pickupSprite;
        List<Pickup> pickups = new List<Pickup>();
        Vector2 target;
        

        // click processing
        bool rightClickStarted = false;
        bool rightButtonReleased = true;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // STUDENTS: set resolution and make mouse visible
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            IsMouseVisible = true;

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

            // STUDENTS: load teddy and pickup sprites
            teddySprite = Content.Load<Texture2D>("teddybear");
            pickupSprite = Content.Load<Texture2D>("pickup");

            // STUDENTS: create teddy object centered in window
            location.X = WINDOW_WIDTH/2;
            location.Y = WINDOW_HEIGHT/2;
            teddy = new Teddy(teddySprite,location);
            

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

            // STUDENTS: get current mouse state and update teddy
            MouseState mouse = Mouse.GetState();
            pickup_location.X = mouse.X;
            pickup_location.Y = mouse.Y;
            // check for right click started
            if (mouse.RightButton == ButtonState.Pressed &&
                rightButtonReleased)
            {
                rightClickStarted = true;
                rightButtonReleased = false;
            }
            else if (mouse.RightButton == ButtonState.Released)
            {
                rightButtonReleased = true;

                // if right click finished, add new pickup to list
                if (rightClickStarted)
                {
                    rightClickStarted = false;

                    // STUDENTS: add a new pickup to the end of the list of pickups
                    pickups.Add(new Pickup(pickupSprite,pickup_location));
                    target.X = pickups[0].CollisionRectangle.X;
                    target.Y = pickups[0].CollisionRectangle.Y;
                    
                    // STUDENTS: if this is the first pickup in the list, set teddy target
                    

                }
            }

            // STUDENTS: Delete the line saying if (true) and uncomment the three
            // lines below that AFTER you've created a teddy object in the
            // LoadContent method
            // check for collision between collecting teddy and targeted pickup
            teddy.SetTarget(target);
            teddy.Update(gameTime, mouse);
            if (teddy.Collecting &&
                 pickups.Count > 0 &&
                 teddy.CollisionRectangle.Intersects(pickups[0].CollisionRectangle))
            {
                // STUDENTS: remove targeted pickup from list (it's always at location 0)
                pickups.Remove(pickups[0]);

                // STUDENTS: if there's another pickup to collect, set teddy target
                // If not, stop the teddy from collecting
                if(pickups.Count != 0)
                {
                    target.X = pickups[0].CollisionRectangle.X;
                    target.Y = pickups[0].CollisionRectangle.Y;
                    teddy.SetTarget(target);
                    teddy.Update(gameTime, mouse);
                }
                else
                {
                    teddy.Collecting = false;
                }

            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // draw game objects
            spriteBatch.Begin();

            // STUDENTS: Uncomment the following line AFTER you create
            teddy.Draw(spriteBatch);
            foreach (Pickup pickup in pickups)
            {
                pickup.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}