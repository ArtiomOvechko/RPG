using ArtiomOvechko.RPG.Common.Helpers;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;

namespace ArtiomOvechko.RPG.App.Helpers
{
    public class ScreenCentering
    {
        private static ScreenCentering _instance;
        private static volatile object _lock = new object();


        public static ScreenCentering GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ScreenCentering();
                        }
                    }
                }
                return _instance;
            }
        }

        private ScreenCentering() { }

        public Point GetCanvasOffset(Point originPositon, int screenWidth, int screenHeight)
        {
            int x = (int)(screenWidth / 2) - originPositon.X;
            int y = (int)(screenHeight / 2) - originPositon.Y;
            return new Point(x, y);
        }

        public Point GetCanvasOffset(Point originPositon)
        {
            var bounds = ApplicationView.GetForCurrentView().VisibleBounds;
            var scaleFactor = DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;
            
            int x = (int)(bounds.Width * scaleFactor / 2) - originPositon.X;
            int y = (int)(bounds.Height * scaleFactor / 2) - originPositon.Y;

            return new Point(x, y);
        }
    }
}
