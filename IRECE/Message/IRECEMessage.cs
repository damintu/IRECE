using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace IRECE.Message
{
    [DataContract]
    public class IRECEMessage
    {
        // needs to be sent to connect.
        public const string CONNECT = "CONNECT";

        // needs to be set as type to send a message in a channel
        public const string MESSAGE = "MESSAGE";

        // needs to be sent to disconnect.
        public const string DISCONNECT = "DISCONNECTED";

        // needs to be send to avoid being timed out
        public const string KEEP_ALIVE_QUESTION = "ping";

        // needs to be received from the server to know that we are still alive ♫
        public const string KEEP_ALIVE_RESPONSE = "pong";

        [DataMember]
        public string Command { get; set; }
        [DataMember]
        public string Channel { get; set; }
        [DataMember]
        public string Text { get; set; }

        public override string ToString()
        {
            string str;
            using (MemoryStream s = new MemoryStream())
            using (StreamReader sr = new StreamReader(s))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(IRECEMessage));
                serializer.WriteObject(s, this);
                s.Position = 0;
                str = sr.ReadToEnd();
            }
            return str;
        }

        public static IRECEMessage Deserialize(string json)
        {
            IRECEMessage m;
            using (MemoryStream s = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json)))
            using (StreamReader sr = new StreamReader(s))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(IRECEMessage));
                s.Position = 0;
                m = (IRECEMessage)serializer.ReadObject(s);
            }
            return m;
        }
    }
}
