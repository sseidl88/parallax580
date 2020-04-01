using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallaxStarter
{
    public class ParallaxLayer : DrawableGameComponent
    {
        public List<ISprite> Sprites = new List<ISprite>();
        SpriteBatch spriteBatch;

        public IScrollController ScrollController { get; set; } = new AutoScrollController();

        public ParallaxLayer(Game game) : base(game)
        {
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
        }

        public override void Update(GameTime gameTime)
        {
            ScrollController.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, ScrollController.Transform);
            foreach (var sprite in Sprites)
            {
                sprite.Draw(spriteBatch, gameTime);
            }
            spriteBatch.End();
        }




    }
}
