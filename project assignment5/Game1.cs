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
using TeddyMineExplosion;

namespace ProgrammingAssignment5
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        const int Windows_Width = 600;
        const int Windows_Hieght = 400;
        int elapsedgametime;
        Random spwantime = new Random(); 
        List <Mine>  mine_sprit = new List<Mine>();
        List <TeddyBear> teedy_sprti = new List<TeddyBear>();
        Texture2D explosion;
        List <Explosion> explosionanimation = new List<Explosion>();
        Texture2D teddy;
        Texture2D mine;
        Random baseX = new Random();
        Random baseY = new Random();
        Vector2 Velocity = new Vector2();
        MouseState mouse;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = Windows_Hieght;
            graphics.PreferredBackBufferWidth = Windows_Width;
            IsMouseVisible = true;
            Content.RootDirectory = "Content";
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
            teddy = Content.Load<Texture2D>("teddybear");
            mine = Content.Load<Texture2D>("mine");
            explosion = Content.Load<Texture2D>("explosion");
            Velocity = new Vector2((float)(baseX.Next(0, 1)+.15), (float)(baseY.Next(0, 1)+.15));
            teedy_sprti.Add(new TeddyBear(teddy, Velocity, Windows_Width, Windows_Hieght));
            
            
            // TODO: use this.Content to load your game content here
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
            elapsedgametime += gameTime.ElapsedGameTime.Milliseconds;
            mouse = Mouse.GetState();
            if (mouse.LeftButton == ButtonState.Pressed)
            {
                mine_sprit.Add(new Mine(mine, mouse.X, mouse.Y));
            }

            foreach (TeddyBear bear in teedy_sprti)
            {
                bear.Update(gameTime);
                foreach(Mine minee in mine_sprit)
                {
                    if(bear.CollisionRectangle.Intersects(minee.CollisionRectangle))
                    {
                        bear.Active = false;
                        minee.Active = false;
                        explosionanimation.Add(new Explosion(explosion, bear.CollisionRectangle.Center.X,bear.CollisionRectangle.Center.Y));
                        foreach (Explosion exp in explosionanimation)
                        {
                            exp.Update(gameTime);
                            
                        }
                    }
                }
            }
            if (elapsedgametime > spwantime.Next(1000, 3000))
            {
                Velocity = new Vector2((float)(baseX.Next(0, 1) + .15), (float)(baseY.Next(0, 1) + .15));
                teedy_sprti.Add(new TeddyBear(teddy, Velocity, Windows_Width, Windows_Hieght)); 
                elapsedgametime = 0;
            }
 
            // TODO: Add your update logic here
            for (int i = 0; i < teedy_sprti.Count; i++)
            {
                if(teedy_sprti[i].Active == false)
                {
                    teedy_sprti.Remove(teedy_sprti[i]);
                }
            }
            for (int i = 0; i < mine_sprit.Count; i++)
            {
                if (mine_sprit[i].Active == false)
                {
                    mine_sprit.Remove(mine_sprit[i]);
                }
            }
            for (int i = 0; i < explosionanimation.Count; i++ )
            {
                if(explosionanimation[i].Playing == true)
                {
                    explosionanimation.Remove(explosionanimation[i]);
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

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            foreach(Explosion exp in explosionanimation)
            {
 
                    exp.Draw(spriteBatch);
                
            }
            foreach(Mine minee in mine_sprit)
            {
                    minee.Draw(spriteBatch);
                
            }
            foreach(TeddyBear bear in teedy_sprti)
            {
                    bear.Draw(spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}