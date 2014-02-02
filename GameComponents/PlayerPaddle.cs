using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace WindowsGame1.GameComponents
{
    class PlayerPaddle : Paddle
    {
        int currentPosition = 0;
        public PlayerPaddle(Game game, Color color)
            : base(game, color)
        {
            shape.X = Game.Window.ClientBounds.Width - shape.Width - 10;
            currentPosition = Mouse.GetState().Y;
        }

        public override void Update(GameTime gameTime)
        {
            int change = 0;
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                change = -2;
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
                change = 2;

            if (shape.Y >= 0 && shape.Y <= (Game.Window.ClientBounds.Height - shape.Height))
                shape.Y += change;
            else if (shape.Y < 0)
                shape.Y = 0;
            else
                shape.Y = (Game.Window.ClientBounds.Height - shape.Height);
        }
    }
}
