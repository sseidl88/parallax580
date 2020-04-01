using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallaxStarter
{
    public class PlayerTrackingScrollController : IScrollController
    {
        Player player;
        public float ScrollRatio = 1.0f;
        public float Offset = 200;

        public Matrix Transform
        {
            get
            {
                float x = ScrollRatio * (Offset - player.Position.X);
                return Matrix.CreateTranslation(x, 0, 0);
            }
        }

        public void Update(GameTime gameTime) { }

        public PlayerTrackingScrollController(Player player, float ratio)
        {
            this.player = player;
            this.ScrollRatio = ratio;
        }



    }
}
