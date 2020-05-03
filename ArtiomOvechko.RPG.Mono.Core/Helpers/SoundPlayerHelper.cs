using System;
//using System.Media;
//using System.Windows.Resources;

namespace ArtiomOvechko.RPG.Mono.Core.Helpers
{
    public class SoundPlayerHelper
    {
        private static SoundPlayerHelper _instance;
        private static volatile object _lock = new object();

        public static SoundPlayerHelper GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new SoundPlayerHelper();
                        }
                    }
                }
                return _instance;
            }
        }

        private SoundPlayerHelper() { }

        public void Play(string uriString)
        {
            //Uri uri = new Uri(uriString);
            //StreamResourceInfo sri = System.Windows.Application.GetResourceStream(uri);
            // SoundPlayer player = new SoundPlayer(sri.Stream);
            // player.Load();
            // player.Play();
        }
    }
}
