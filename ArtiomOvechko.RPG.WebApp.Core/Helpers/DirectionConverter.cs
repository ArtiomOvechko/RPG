using Chevo.RPG.WebApp.Core.Enum;

using System;


namespace Chevo.RPG.WebApp.Core.Helpers
{
    public static class DirectionConverter
    {
        public static Direction Convert(object o)
        {
            if (o is Direction)
            {
                var x = (Direction)o;

                return x;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
