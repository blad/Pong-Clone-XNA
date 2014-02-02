using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace WindowsGame1.GameComponents
{
    
    class Border : DrawableGameComponent
    {
        SpriteBatch sb;
        Rectangle shape;
        Texture2D texture;
        Color color;


        public Border(Game game, Color color) : base(game)
        {
            base.Initialize();

            sb = new SpriteBatch(GraphicsDevice);
            shape = new Rectangle(Game.Window.ClientBounds.Width/2, 0, 3, Game.Window.ClientBounds.Height);
            texture = new Texture2D(GraphicsDevice, 1, 1);
            texture.SetData(new Color[] { color });
            this.color = color;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            sb.Begin();
            sb.Draw(texture, shape, color);
            sb.End();
        }
    }


}
