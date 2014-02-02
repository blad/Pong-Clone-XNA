using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1.GameComponents
{
    class Paddle : DrawableGameComponent
    {
        protected Rectangle shape;
        protected Texture2D texture;
        protected Color color;
        protected SpriteBatch sb;
        
        int direction;
        int rate;

        public int XPos { get { return shape.X; } }
        public int YPos { get { return shape.Y; } }
        public int Width { get { return shape.Width; } }
        public int Height { get { return shape.Height;  } }
        public int Score { get; set; }

        public Ball Ball { get; set; }

        public Paddle(Game game, Color color) : base(game)
        {
            this.color = color;
            base.Initialize();
            sb = new SpriteBatch(GraphicsDevice);

            // Create a Texture
            texture = new Texture2D(GraphicsDevice, 1, 1);
            texture.SetData(new Color[] { Color.White });

            // Create the shape
            shape = new Rectangle(10, 0, 20, 150);
            direction = 1;
            rate = 2;
            Score = 0;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Direction to move is decided upon by the location of the ball, and the center of the paddle.
            if (Ball != null)
                direction = (shape.Y + (shape.Height / 2)) - (Ball.YPos + Ball.Radius) < 0 ? 1 : -1;
            
            // Only move if the paddle will stay within bounds.
            if (shape.Y + shape.Height <= Game.Window.ClientBounds.Height && shape.Y >= 0)
                if ( shape.Y + shape.Height + rate * direction <= Game.Window.ClientBounds.Height && shape.Y + rate * direction >= 0) 
                    shape.Y += rate * direction;
            
        }

        public override void Draw(GameTime gameTime)
        {
            sb.Begin();
            sb.Draw(texture, shape, color);
            sb.End();
        }
    }
}
