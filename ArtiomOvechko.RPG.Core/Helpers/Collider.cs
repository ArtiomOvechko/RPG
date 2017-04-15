using ArtiomOvechko.RPG.Common.Settings;
using ArtiomOvechko.RPG.Core.Interfaces.Instance;

using System;


namespace ArtiomOvechko.RPG.Core.Helpers
{
    public static class Collider
    {
        public static bool Colliding(ISpec otherInstanceSpecs, ISpec expectedSpecs)
        {
            if (Intersect(otherInstanceSpecs, expectedSpecs) || Intersect(expectedSpecs, otherInstanceSpecs))
            {
                return true;
            }
            return false;
        }

        public static bool InRangeOfInteraction(ISpec otherInstanceSpecs, ISpec currentSpecs)
        {
            if (getDistance(otherInstanceSpecs, currentSpecs) < ActorSettings.InteractionDistance)
            {
                return true;
            }
            return false;
        }

        private static bool Intersect(ISpec from, ISpec to)
        {
            Point leftUp = new Point(from.XPos - from.Size / 2, from.YPos - from.Size / 2);
            Point rightUp = new Point(from.XPos + from.Size / 2, from.YPos - from.Size / 2);
            Point rightDown = new Point(from.XPos + from.Size / 2, from.YPos + from.Size / 2);
            Point leftDown = new Point(from.XPos - from.Size / 2, from.YPos + from.Size / 2);

            if (PointWithin(to, leftUp) || PointWithin(to, rightUp) || PointWithin(to, rightDown) || PointWithin(to, leftDown))
            {
                return true;
            }
            return false;
        }

        private static bool PointWithin(ISpec area, Point point)
        {
            if (point.X <= area.XPos + area.Size/2 && point.X >= area.XPos - area.Size / 2
                && point.Y <= area.YPos + area.Size / 2 && point.Y >= area.YPos - area.Size / 2)
            {
                return true;
            }
            return false;
        }

        private static int getDistance(ISpec from, ISpec to)
        {
            double xDiff = from.XPos - to.XPos;
            double yDiff = from.YPos - to.YPos;
            double stage = 2;
            double mainCalculation = Math.Pow(xDiff, stage) + Math.Pow(yDiff, stage);
            double result = Math.Sqrt(mainCalculation);
            return (int)result;
        }
    }
}
