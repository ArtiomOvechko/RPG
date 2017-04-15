namespace ArtiomOvechko.RPG.Common.Helpers
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

        //public Point GetCanvasOffset(Point originPositon)
        //{
        //    int x = (int)(System.Windows.SystemParameters.PrimaryScreenWidth/2) - originPositon.X;
        //    int y = (int)(System.Windows.SystemParameters.PrimaryScreenHeight/2) - originPositon.Y;
        //    return new Point(x, y);
        //}
    }
}
