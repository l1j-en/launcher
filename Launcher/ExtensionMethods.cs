using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Launcher
{
    public static class ExtensionMethods
    {
        public static string JsonSerialize<T>(T obj)
        {
            string retVal = null;
            var serializer = new DataContractJsonSerializer(obj.GetType());
            using (var ms = new MemoryStream())
            {
                serializer.WriteObject(ms, obj);
                retVal = Encoding.Default.GetString(ms.ToArray());
            }

            return retVal;
        }

        public static T JsonDeserialize<T>(this string json)
        {
            var obj = Activator.CreateInstance<T>();
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(obj.GetType());
                obj = (T)serializer.ReadObject(ms);
            }

            return obj;
        }
    }
}
