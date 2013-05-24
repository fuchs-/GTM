using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BXEL.Sounds;

using Microsoft.Xna.Framework.Content;

namespace GTMEngine.Model.Sound
{
    public static class SoundController
    {
        #region Properties

        private static SoundManager MainSoundManager { get; set; }

        private static Queue<BXEL.Sounds.Sound> SoundQueue { get; set; }
        private static BXEL.Sounds.Sound CurrentSound { get; set; }

        #endregion

        #region Methods

        #region Flow Methods

        public static void LoadContent()
        {
            MainSoundManager = new SoundManager("GTMSounds", "MainWaveBank", "MainSoundBank", @"Content\Sounds");
            SoundQueue = new Queue<BXEL.Sounds.Sound>();

            foreach (string s in Enum.GetNames(typeof(KillStreaks)))
            {
                MainSoundManager.LoadSound(s);
            }

            foreach (string s in Enum.GetNames(typeof(MultiKills)))
            {
                MainSoundManager.LoadSound(s);
            }
        }

        public static void Update()
        {
            if (SoundQueue.Count > 0)
            {
                if (CurrentSound == null)
                {
                    CurrentSound = SoundQueue.Dequeue();
                    CurrentSound.Play();
                }
                else
                {
                    if (!CurrentSound.IsPlaying)
                    {
                        CurrentSound = SoundQueue.Dequeue();
                        CurrentSound.Play();
                    }
                }
            }
        }

        #endregion

        public static void PlaySound(string name)
        {
            SoundQueue.Enqueue(MainSoundManager.GetSound(name));
        }

        #endregion

    }
}
