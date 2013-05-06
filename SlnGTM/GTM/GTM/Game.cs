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

using BXEL.Graphics;

using GTMEngine.Model;
using GTMEngine.Model.Characters;
using GTMEngine.Controller.GameFlow;

using GTMEngine.UI;


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
        TurnController turnController;
        FlowController flowController;
        HUD hud;

        #endregion

        #region Properties

        public Team RedTeam { get; private set; }
        public Team BlueTeam { get; private set; }

        #endregion

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);

            graphics.PreferredBackBufferHeight = 620;

            Content.RootDirectory = "Content";
            map = new Map();
            hud = new HUD();
        }

        #region Methods

        #region Flow Methods

        
        protected override void Initialize()
        {
            base.Initialize();

            this.IsMouseVisible = true;

            turnController = new TurnController(map, hud, RedTeam, BlueTeam);
            flowController = new FlowController();

            map.Initialize(RedTeam, BlueTeam, turnController);
            TextController.Initialize(Content);

            if (turnController.CurrentTurn != null) hud.ChangeHUDDisplay(turnController.CurrentTurn.CurrentHero.MyHUDDisplay);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            EntityLoader.Initialize(this.Content, map);
            Hero.LoadContent(this.Content);
            HUD.Initialize(this.Content, map);

            //brings up the Hero Selection Screen
            HeroSelectionScreen hss = new HeroSelectionScreen();
            hss.LoadHeroNames(this.Content);
            hss.ShowDialog();

            RedTeam = hss.RedTeam;
            BlueTeam = hss.BlueTeam;

            hss.Dispose();

            if (RedTeam.GetHeroes().Count < 3 || BlueTeam.GetHeroes().Count < 3) this.Exit();

            map.LoadContent(this.Content);
            hud.LoadContent(this.Content);
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

            //This block will get complicated soon enough
            map.Update(gameTime);
            hud.Update(gameTime);
            TextController.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            map.Draw(spriteBatch, gameTime);
            hud.Draw(spriteBatch);
            TextController.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }


        #endregion

        #endregion
    }
}
