using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Launcher
{
    [DataContract]
    public class VersionInfo
    {
        [DataMember]
        public string Version { get; set; }

        [DataMember]
        public bool Required { get; set; }

        [DataMember]
        public string VersionDetails { get; set; }

        [DataMember]
        public long LastUpdated { get; set; }

        [DataMember]
        public Dictionary<string, string> FileChecksums { get; set; } 
    }
}
