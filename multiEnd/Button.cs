using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace multiEnd
{
    public class Button
    {
        int buttonX, buttonY; //position on the screen
        string name;
        Texture2D buttonTexture = Game1.buttonTexture;

        MouseState mNewState, mOldState; //for MousePressed()

        public int ButtonX
        {
            get
            {
                return buttonX;
            }
        }

        public int ButtonY
        {
            get
            {
                return buttonY;
            }
        }

        public Button(string name, Texture2D texture, int buttonX, int buttonY)
        {
            this.name = name;
            this.buttonTexture = texture;
            this.buttonX = buttonX;
            this.buttonY = buttonY;
        }

        public bool EnterButton() //checking mouse position vs button position
        {
            if (Mouse.GetState().X < buttonX + buttonTexture.Width &&
                Mouse.GetState().X > buttonX &&
                Mouse.GetState().Y < buttonY + buttonTexture.Height &&
                Mouse.GetState().Y > buttonY)
            {
                return true;
            }
            return false;
        }

        public bool MousePressed()
        {
            if (mNewState.LeftButton == ButtonState.Released && mOldState.LeftButton == ButtonState.Pressed)
            {
                mOldState = mNewState;
                return true;
            }
            return false;
        }

        public void Update(GameTime gameTime)
        {
            mNewState = Mouse.GetState(); //for KeyPressed()
            if (EnterButton() && MousePressed())
            {
                switch (name)
                {
                    case "buttonA":
                        Trace.WriteLine(name);
                        break;

                    case "buttonB":
                        Trace.WriteLine(name);
                        break;

                    case "buttonC":
                        Trace.WriteLine(name);
                        break;
                }
            }
            mOldState = mNewState;
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(buttonTexture, new Vector2(ButtonX,ButtonY), new Rectangle(0, 0, buttonTexture.Width, buttonTexture.Height), Color.White);
        }
    }
}
