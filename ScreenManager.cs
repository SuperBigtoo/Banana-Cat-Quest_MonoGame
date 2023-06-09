﻿using Banana_Catto_Quest.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Banana_Catto_Quest
{
    internal class ScreenManager
    {
        private Screen currentScreen;
        private static ScreenManager instance;

        public ContentManager Content 
        {
            private set; get;    
        }

        public Camera Camera
        {
            private set; get;
        }

        public enum GameScreen
        {
            SplashScreen,
            PlayScreen
        }

        public ScreenManager() 
        {
            currentScreen = new SplashScreen();
        }

        public void LoadScreen(GameScreen gameScreen) 
        {
            switch (gameScreen)
            {
                case GameScreen.SplashScreen:
                    currentScreen = new SplashScreen();
                    currentScreen.LoadContent();
                    break;

                case GameScreen.PlayScreen:
                    currentScreen = new PlayScreen();
                    currentScreen.LoadContent(Camera);
                    break;
            }
        }

        public void LoadContent(ContentManager content, Camera camera)
        {
            Content = new ContentManager(content.ServiceProvider, "Content");
            Camera = camera;

            currentScreen.LoadContent();
        }

        public void UnloadContent()
        {
            currentScreen.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
        }

        public static ScreenManager Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new ScreenManager();
                }
                return instance;
            }
        }
    }
}
