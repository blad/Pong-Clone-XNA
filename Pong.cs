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
using WindowsGame1.GameComponents;

namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Pong : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteFont _font;
        SpriteBatch _spriteBatch;
        PlayerPaddle _player;
        Paddle _computer;

        public Pong()
        {
            graphics = new GraphicsDeviceManager(this);
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
            
            _player   = new PlayerPaddle(this, Color.White);
            _computer = new Paddle(this, Color.White);
            Ball ball = new Ball(this, 10, _player, _computer);

            _computer.Ball = ball;
            
            base.Initialize();
            this.Components.Add(new Border(this, Color.DarkGray));
            this.Components.Add(_player);
            this.Components.Add(_computer);
            this.Components.Add(ball);
            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Content.Load<SpriteFont>("CourierNewFont");
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
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(0.1f,0.1f,0.1f));
            base.Draw(gameTime);

            _spriteBatch.Begin();
             // Draw Hello World
            string output = _computer.Score +" "+ _player.Score;

            // Find the center of the string
            Vector2 FontOrigin = _font.MeasureString(output) / 2;
            // Draw the string
            _spriteBatch.DrawString(_font, output, 
                new Vector2(Window.ClientBounds.Width/2, 20), 
                Color.White,
                0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);

            _spriteBatch.End();
        }
    }
}
