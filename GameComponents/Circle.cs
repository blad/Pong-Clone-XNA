using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WindowsGame1.GameComponents
{
    class Circle : DrawableGameComponent
    {
        float radius;
        BasicEffect basicEffect;
        VertexPositionColor[] vertices;

        public Circle(Game game) : base(game)
        {
            XPos = 0;
            YPos = 0;
        }

        public override void Initialize()
        {
            base.Initialize();

            basicEffect = new BasicEffect(GraphicsDevice);
            basicEffect.VertexColorEnabled = true;
            basicEffect.Projection = Matrix.CreateOrthographicOffCenter(0, GraphicsDevice.Viewport.Width,     // left, right
                                                                        GraphicsDevice.Viewport.Height, 0,    // bottom, top
                                                                        0, 1);                                // near, far plane
            vertices = new VertexPositionColor[100];
            UpdatePoints();
        }
        
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            UpdatePoints();
        }


        private void UpdatePoints()
        {
            for (int i = 0; i < 99; i++)
            {
                float angle = (float)(i / 100.0 * Math.PI * 2);
                vertices[i].Position = new Vector3(XPos + (float)Math.Cos(angle) * this.radius, YPos + (float)Math.Sin(angle) * this.radius, 0);
                vertices[i].Color = Color.White;
            }
            vertices[99] = vertices[0];
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            basicEffect.CurrentTechnique.Passes[0].Apply();
            GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineStrip, vertices, 0, 98);
        }


        public float XPos { get; set; }

        public float YPos { get; set; }

        public float Radius
        {
            set
            {
                if (value > 0)
                {
                    radius = value;
                }
                else
                {
                    radius = 0;
                }
            }

            get { return radius; }
        }

            
    }
}
