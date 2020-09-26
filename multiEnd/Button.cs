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
        Rectangle buttonRect;

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
            if (Mouse.GetState().X < buttonX + (buttonTexture.Width / 2) &&
                Mouse.GetState().X > buttonX &&
                Mouse.GetState().Y < buttonY + (buttonTexture.Height / 2) &&
                Mouse.GetState().Y > buttonY)
            {
                Trace.WriteLine("here's a button");
                return true;
            }
            Trace.WriteLine("no buttons");
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
            mNewState = Mouse.GetState(); //for MousePressed()

            if (EnterButton() && MousePressed())
                {
                    switch (name)
                    {
                        case "startButton":
                            Trace.WriteLine(name);
                            Game1.currentButton = 4;
                            break;

                        case "buttonA":
                            Trace.WriteLine(name);
                            Game1.currentButton = 1;
                            break;

                        case "buttonB":
                            Trace.WriteLine(name);
                            Game1.currentButton = 2;
                            break;

                        case "buttonC":
                            Trace.WriteLine(name);
                            Game1.currentButton = 3;
                            break;
                    }
            }
            mOldState = mNewState;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            switch (name)
            {
                case "startButton":
                    buttonRect = new Rectangle(100, 50, 100, 50);
                    break;

                case "buttonA":
                    buttonRect = new Rectangle(0, 0, 100, 50);
                    break;

                case "buttonB":
                    buttonRect = new Rectangle(100, 0, 100, 50);
                    break;

                case "buttonC":
                    buttonRect = new Rectangle(0, 50, 100, 50);
                    break;
            }

            _spriteBatch.Draw(buttonTexture, new Vector2(ButtonX,ButtonY), buttonRect, Color.White);
        }
    }
}
