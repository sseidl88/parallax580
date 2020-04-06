using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;


namespace ParallaxStarter
{
    public class Player : ISprite
    {
        int boost = 0;
        Texture2D spritesheet;
        KeyboardState oldKeyboard;
        public bool won = false;
        public bool playing = true;
        Random random;

        Rectangle sourceRect = new Rectangle
        {
            X = 0,
            Y = 0,
            Width = 512,
            Height = 512
        };

        /// <summary>
        /// The origin of the helicopter sprite
        /// </summary>
        Vector2 origin = new Vector2(0, 0);

        /// <summary>
        /// The angle the helicopter should tilt
        /// </summary>
        float angle = 0;

        /// <summary>
        /// The player's position in the world
        /// </summary>
        public Vector2 Position;

        /// <summary>
        /// How fast the player moves
        /// </summary>
        public float Speed { get; set; } = 100;

        Game1 game;
        /// <summary>
        /// Constructs a player
        /// </summary>
        /// <param name="spritesheet">The player's spritesheet</param>
        public Player(Texture2D spritesheet)
        {
            this.spritesheet = spritesheet;
            this.Position = new Vector2(250, 340);
        }

        /// <summary>
        /// Updates the player position based on Keyboard Input
        /// </summary>
        /// <param name="gameTime">The GameTime object</param>
        public void Update(GameTime gameTime)
        {
            Vector2 direction = Vector2.Zero;
            float hippoWidth = (0.2f * sourceRect.Width);
            float hippoHeight = (0.2f * sourceRect.Height);
            random = new Random();

            // Override with keyboard input
            var keyboard = Keyboard.GetState();
            
            if(keyboard.IsKeyDown(Keys.Left) && playing || keyboard.IsKeyDown(Keys.A) && playing)
            {
                direction.X -= 1;
                angle = 0;
            }
            if (keyboard.IsKeyDown(Keys.Right) && playing  || keyboard.IsKeyDown(Keys.D) && playing) 
            {
                direction.X += 1;
                angle = 0;
            }
            if(keyboard.IsKeyDown(Keys.Up) && playing || keyboard.IsKeyDown(Keys.W) && playing)
            {
                direction.Y -= 1;
                angle = 0.5f * direction.Y;
            }
            if(keyboard.IsKeyDown(Keys.Down) && playing || keyboard.IsKeyDown(Keys.S) && playing)
            {
                direction.Y += 1;
                angle = 0.5f * direction.Y;
            }
            //add boost
            if (keyboard.IsKeyDown(Keys.Space) && !oldKeyboard.IsKeyDown(Keys.Space) && playing && boost < random.Next(13,14))
            {
               // if(boost <= 5)
                direction.X += 100;

                angle = 0;
                boost++;
            }

            oldKeyboard = keyboard;

            if (Position.Y <= 300)
            {
                angle = 0;
                Position.Y = 300;
            }
            if (Position.Y + hippoHeight >= 480)
            {
                angle = 0;
                Position.Y = 480 - hippoHeight;
            }
            if(Position.X < 200)
            {
                Position.X = 200;
                angle = 0;
            }
            //win game by getting to movie theater
            if(Position.X > 13217)
            {
                Position.X = 13217;
                angle = 0;
                won = true;
            }
         
            // Move the player if the game hasn't been won yet
           Position += (float)gameTime.ElapsedGameTime.TotalSeconds * Speed * direction;
        }

        /// <summary>
        /// Draws the player sprite
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            // Render the helicopter, rotating about the rotors
            spriteBatch.Draw(spritesheet, Position, sourceRect, Color.White, angle, origin, 0.2f, SpriteEffects.None, 0.7f);
          //  spriteBatch.DrawString(font, "X: " + Position.X, new Vector2(pPosition.X, 350), Color.White);
        }

    }
}
