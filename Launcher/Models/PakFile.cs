using System;
using System.Runtime.Serialization;

namespace Launcher.Models
{
    [Serializable]
    [DataContract]
    public class PakFile
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Content { get; set; }
    }
}
