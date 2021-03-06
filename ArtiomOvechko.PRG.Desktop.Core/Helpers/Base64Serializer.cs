﻿using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ArtiomOvechko.RPG.Desktop.Core.Helpers
{
    public static class Base64Serializer
    {
        public static string SerializeObject(object o)
        {
            //if (!o.GetType().IsSerializable)
            //{
            //    return null;
            //}

            using (MemoryStream stream = new MemoryStream())
            {
                new BinaryFormatter().Serialize(stream, o);
                return Convert.ToBase64String(stream.ToArray());
            }
        }

        public static object DeserializeObject(string str)
        {
            byte[] bytes = Convert.FromBase64String(str);

            using (MemoryStream stream = new MemoryStream(bytes))
            {
                return new BinaryFormatter().Deserialize(stream);
            }
        }
    }
}
