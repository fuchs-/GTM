using System;

namespace GTM
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            HeroSelectionScreen heroSelectionScreen = new HeroSelectionScreen();
            heroSelectionScreen.ShowDialog();

            using (Game game = new Game())
            {
                game.Run();
            }
        }
    }
#endif
}

