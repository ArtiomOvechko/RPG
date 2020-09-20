using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Desktop.Core.Stats;

namespace ArtiomOvechko.RPG.Desktop.Core.Helpers
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
            int x = screenWidth / 2 - originPositon.X;
            int y = screenHeight / 2 - originPositon.Y;
            return new Point(x, y);
        }

        public Point ConvertActorPosition(IActor actor)
        {
            return new Point(actor.Position.X + actor.Stats.Size / 2, actor.Position.Y + actor.Stats.Size / 2);
        }
    }
}
