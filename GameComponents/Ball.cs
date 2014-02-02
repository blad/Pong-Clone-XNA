using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1.GameComponents
{
    class Ball : Circle
    {
        Vector2 velocity;
        public PlayerPaddle Player { get; set; }
        public Paddle Computer { get; set; }
        

        public Ball(Game game, int radius, PlayerPaddle player, Paddle computer) : base(game)
        {
            Radius = radius;
            XPos = Game.Window.ClientBounds.Width / 2 - radius; 
            YPos = Game.Window.ClientBounds.Height / 2 - radius;
            
            // Set the players for collision Checking.
            Player = player;
            Computer = computer;
            
            Initialize();
        }

        public override void Initialize()
        {
            base.Initialize();
            velocity = new Vector2(6, 6);
        }


        public override void Update(GameTime gameTime)
        {
            
            // Check for Collisions with the Paddles

            // Collision with Left Paddle
            if ((YPos >= Player.YPos && YPos <= Player.YPos + Player.Height) && (XPos + Radius >= Player.XPos))
            {
                XPos = Player.XPos - Radius;
                velocity.X *= -1.1F;
                velocity.Y += (((YPos + Radius) - (Player.YPos + (Player.Height / 2))) / (Player.Height / 2)) * 2;
            }

            if ((YPos >= Computer.YPos && YPos <= Computer.YPos + Computer.Height) && (XPos - Radius <= Computer.XPos + Computer.Width))
            {
                XPos = Computer.XPos + Computer.Width + Radius;
                velocity.X *= -1.1F;
                velocity.Y += (((YPos + Radius) - (Computer.YPos + (Computer.Height / 2))) / (Computer.Height / 2))*2;
            }

            // Check for Collisions with the Walls
            if (YPos - Radius < 0 || YPos + Radius > Game.Window.ClientBounds.Height)
                velocity.Y *= -1F;

            // Reset if they touch the side walls.
            if (XPos < 0 || XPos + Radius > Game.Window.ClientBounds.Width)
            {
                if (XPos < 0)
                    Player.Score++;
                else
                    Computer.Score++;

                XPos = Game.Window.ClientBounds.Width / 2 - Radius;
                YPos = Game.Window.ClientBounds.Height / 2 - Radius;
                velocity.X = 3;
                velocity.Y = 0;
            }

            XPos += velocity.X;
            YPos += velocity.Y;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
