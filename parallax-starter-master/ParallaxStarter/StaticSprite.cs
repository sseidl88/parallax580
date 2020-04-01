﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallaxStarter
{
    public class StaticSprite : ISprite
    {
        // TODO: Implement class
        public Vector2 position = Vector2.Zero;
        Texture2D texture;

        public StaticSprite(Texture2D texture)
        {
            this.texture = texture;
        }

        public StaticSprite(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

    }
}
