using System;


namespace ArtiomOvechko.RPG.Common.Helpers
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

        public void Play()
        {
            //Uri uri = new Uri(@"pack://application:,,,/ArtiomOvechko.RPG.Common;component/Resources/Sounds/Actors/Knife/knife.wav");
            //StreamResourceInfo sri = Application.GetResourceStream(uri);
            //SoundPlayer player = new SoundPlayer(sri.Stream);
            //player.Load();
            //player.Play();
        }
    }
}
