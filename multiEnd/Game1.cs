using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace multiEnd
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        int gameWidth; //easier variables
        int gameHeight;

        SpriteFont garamond;

        KeyboardState newState, oldState; // for KeyPressed()
        Keys newKey; //for AddScore()

        public static int currentButton; //1 = A, 2 = B, 3 = C, 4 = start for ButtonPressed()

        public enum GameStatus { START, QUESTION, END };
        public static GameStatus gameStatus;
        int A, B, C;

        string instructionText;

        int next; //advance to next question
        int numQuestions; //max questions, initialized to length of Text.questionArray

        public static Texture2D buttonTexture;
        Button startButton, buttonA, buttonB, buttonC;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            gameWidth = 800;
            gameHeight = 600;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = gameWidth;
            _graphics.PreferredBackBufferHeight = gameHeight;
            _graphics.ApplyChanges();

            gameStatus = GameStatus.START;

            ResetStuff();

            numQuestions = Text.questionArray.Length;


            base.Initialize();
        }

        public void ResetStuff() //sets defaults
        {
            Text.currentQuestion = 0;

            A = 0;
            B = 0;
            C = 0;

            next = 0;
            instructionText = "";

            currentButton = 0;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            garamond = Content.Load<SpriteFont>("garamond");
            buttonTexture = Content.Load<Texture2D>("button");

            startButton = new Button("startButton", buttonTexture, 500, 500);
            buttonA = new Button("buttonA", buttonTexture, 100, 100);
            buttonB = new Button("buttonB", buttonTexture, 100, 200);
            buttonC = new Button("buttonC", buttonTexture, 100, 300);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            newState = Keyboard.GetState(); //for KeyPressed()

            switch (gameStatus)
            {
                case GameStatus.START:
                    instructionText = "Press Enter to Start.";
                    if (KeyPressed(Keys.Enter) || ButtonPressed(4))
                    {
                        gameStatus = GameStatus.QUESTION;
                    }
                    break;

                case GameStatus.QUESTION:
                    instructionText = "Answer each question with honesty.\r\nType your answer: A, B, or C.";
                    if (KeyPressed(Keys.A) || KeyPressed(Keys.B) || KeyPressed(Keys.C)) //keys
                    {
                        next++;
                        AddScore(newKey); //relies on KeyPressed()
                        Text.NextQuestion();
                        if (next >= numQuestions)
                        {
                            gameStatus = GameStatus.END;
                        }
                    }
                    if (ButtonPressed(1) || ButtonPressed(2) || ButtonPressed(3)) //buttons
                    {
                        next++;
                        AddScoreButton(currentButton); //current button is changed in the Button class
                        Text.NextQuestion();
                        if (next >= numQuestions)
                        {
                            gameStatus = GameStatus.END;
                        }
                    }
                    break;

                case GameStatus.END:                    
                    instructionText = "THE END. Press Enter to Restart.";
                    Text.Results(A, B, C);
                    if (KeyPressed(Keys.Enter))
                    {
                        gameStatus = GameStatus.START;
                        ResetStuff();
                    }                        
                    break;
            }

            buttonA.Update(gameTime);
            buttonB.Update(gameTime);
            buttonC.Update(gameTime);


            oldState = newState; //for KeyPressed()
            base.Update(gameTime);
        }

        public bool KeyPressed(Keys key) //logs only one press of a key at a time
        {
            if (newState.IsKeyUp(key) && oldState.IsKeyDown(key))
            {
                oldState = newState;
                newKey = key; //for addScore()
                return true;
            }
            return false;
        }

        public void AddScore(Keys key) //increment score totals
        {
            if (key == Keys.A)
                A++;
            if (key == Keys.B)
                B++;
            if (key == Keys.C)
                C++;
        }

        public bool ButtonPressed(int button) //getter for which button has been pressed
        {
            if (button == currentButton)
                return true;
            else return false;
        }

        public void AddScoreButton(int button) //increment score totals... with buttons
        {
            if (button == 1)
            {
                A++;
                currentButton = 0;
            }
            if (button == 2)
            {
                B++;
                currentButton = 0;
            }
            if (button == 3)
            {
                C++;
                currentButton = 0;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkSlateGray);

            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null);
            
            //instructions
            _spriteBatch.DrawString( 
                garamond,
                instructionText,
                new Vector2(gameWidth / 5, 10),
                Color.Pink, 0f,
                Vector2.Zero,
                1f,
                SpriteEffects.None,
                0f);

            //questions
            if (gameStatus == GameStatus.QUESTION)
                _spriteBatch.DrawString(
                    garamond,
                    Text.questionArray[Text.currentQuestion],
                    new Vector2(gameWidth / 5, gameHeight / 5),
                    Color.Pink,
                    0f,
                    Vector2.Zero,
                    1f,
                    SpriteEffects.None,
                    0f);

            //results
            if (gameStatus == GameStatus.END)
                _spriteBatch.DrawString(
                    garamond,
                    Text.resultsArray[Text.finalResults],
                    new Vector2(gameWidth / 7, gameHeight / 5),
                    Color.Pink,
                    0f,
                    Vector2.Zero,
                    1f,
                    SpriteEffects.None,
                    0f);

            //temp results/totals to be removed after testing
            _spriteBatch.DrawString(
                garamond,
                "A" + A.ToString() + "\r\nB" + B.ToString() + "\r\nC" + C.ToString(),
                new Vector2(gameWidth - 60, 20),
                Color.Pink,
                0f,
                Vector2.Zero,
                1f,
                SpriteEffects.None,
                0f);

            //buttons!!!
            if (gameStatus == GameStatus.START)
            {
                startButton.Draw(_spriteBatch);
            }

            if (gameStatus == GameStatus.QUESTION)
            {
                buttonA.Draw(_spriteBatch);
                buttonB.Draw(_spriteBatch);
                buttonC.Draw(_spriteBatch);
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
