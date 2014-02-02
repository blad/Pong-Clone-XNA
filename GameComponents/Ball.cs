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
        int[] velocity;
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
            velocity = new int[2]{3,3};
        }


        public override void Update(GameTime gameTime)
        {
            
            // Check for Collisions with the Paddles
            if ((YPos >= Player.YPos && YPos <= Player.YPos + Player.Height) &&  (XPos + Radius >= Player.XPos))
                velocity[0] *= -1;

            if ((YPos >= Computer.YPos && YPos <= Computer.YPos + Computer.Height) && (XPos - Radius <= Computer.XPos + Computer.Width))
                velocity[0] *= -1;

            // Check for Collisions with the Walls
            if (YPos - Radius < 0 || YPos + Radius > Game.Window.ClientBounds.Height)
                velocity[1] *= -1;

            // Reset if they touch the side walls.
            if (XPos < 0 || XPos + Radius > Game.Window.ClientBounds.Width)
            {
                XPos = Game.Window.ClientBounds.Width / 2 - Radius;
                YPos = Game.Window.ClientBounds.Height / 2 - Radius;
            }
            
            XPos += (int)velocity[0];
            YPos += (int)velocity[1];

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
