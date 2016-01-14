using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using Launcher.Models;

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

        public static void DownloadFileAsyncSync(this WebClient client, Uri uri, string location)
        {
            client.DownloadFileAsync(uri, location);
            while (client.IsBusy) { System.Windows.Forms.Application.DoEvents(); }
        }

        public static T JsonDeserialize<T>(this string json)
        {
            var obj = Activator.CreateInstance<T>();
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(obj.GetType(), new List<Type> { typeof(PakFile) });
                obj = (T)serializer.ReadObject(ms);
            }

            return obj;
        }
    }
}
