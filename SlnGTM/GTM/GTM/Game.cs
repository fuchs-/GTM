using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using GTM.Model;
using GTM.Model.Characters;
using GTM.Model.GameFlow;

namespace GTM
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {

        #region Attributes

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Map map;
        FlowController flowController;

        #endregion

        #region Properties

        public Team RedTeam { get; private set; }
        public Team BlueTeam { get; private set; }

        #endregion

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            /*
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
             */

            Content.RootDirectory = "Content";
            map = new Map();
        }

        #region Methods

        #region Flow Methods

        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            this.IsMouseVisible = true;

            map.Initialize(RedTeam, BlueTeam);
            flowController = new FlowController(RedTeam, BlueTeam);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            HeroLoader.Initialize(this.Content);

            //brings up the Hero Selection Screen
            HeroSelectionScreen hss = new HeroSelectionScreen();
            hss.ShowDialog();

            RedTeam = hss.RedTeam;
            BlueTeam = hss.BlueTeam;

            hss.Dispose();

            if (RedTeam.GetHeroes().Count < 3 || BlueTeam.GetHeroes().Count < 3) this.Exit();

            map.LoadContent(this.Content);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            map.Draw(spriteBatch, gameTime);

            spriteBatch.End();

            base.Draw(gameTime);
        }


        #endregion

        #endregion
    }
}
