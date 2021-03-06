﻿using ArtiomOvechko.RPG.Desktop.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Desktop.Core.Stats;

using System;


namespace ArtiomOvechko.RPG.Desktop.Core.Helpers
{
    public static class Collider
    {
        public static bool Colliding(CollisionModel other, CollisionModel current)
        {
            if (Intersect(other, current) || Intersect(current, other))
            {
                return true;
            }
            return false;
        }

        public static bool InRangeOfInteraction(CollisionModel otherInstanceSpecs, CollisionModel currentSpecs)
        {
            if (getDistance(otherInstanceSpecs, currentSpecs) < Common.Settings.ActorSettings.InteractionDistance)
            {
                return true;
            }
            return false;
        }

        private static bool Intersect(CollisionModel from, CollisionModel to)
        {
            Point leftUp = new Point(from.X - from.Size / 2, from.Y - from.Size / 2);
            Point rightUp = new Point(from.X + from.Size / 2, from.Y - from.Size / 2);
            Point rightDown = new Point(from.X + from.Size / 2, from.Y + from.Size / 2);
            Point leftDown = new Point(from.X - from.Size / 2, from.Y + from.Size / 2);

            if (PointWithin(to, leftUp) || PointWithin(to, rightUp) || PointWithin(to, rightDown) || PointWithin(to, leftDown))
            {
                return true;
            }
            return false;
        }

        private static bool PointWithin(CollisionModel area, Point point)
        {
            if (point.X <= area.X + area.Size/2 && point.X >= area.X - area.Size / 2
                && point.Y <= area.Y + area.Size / 2 && point.Y >= area.Y - area.Size / 2)
            {
                return true;
            }
            return false;
        }

        private static int getDistance(CollisionModel from, CollisionModel to)
        {
            double xDiff = from.X - to.X;
            double yDiff = from.Y - to.Y;
            double stage = 2;
            double mainCalculation = Math.Pow(xDiff, stage) + Math.Pow(yDiff, stage);
            double result = Math.Sqrt(mainCalculation);
            return (int)result;
        }
    }

    public class CollisionModel
    {
        public int Size { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public CollisionModel(int size, int x, int y)
        {
            Size = size;
            X = x;
            Y = y;
        }

        public CollisionModel(IActor actor)
        {
            Size = actor.Stats.Size;
            X = actor.Position.X;
            Y = actor.Position.Y;
        }
    }
}
