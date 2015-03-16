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
    public class Message
    {
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
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Message));
                serializer.WriteObject(s, this);
                s.Position = 0;
                str = sr.ReadToEnd();
            }
            return str;
        }

        public static Message Deserialize(string json)
        {
            Message m;
            using (MemoryStream s = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json)))
            using (StreamReader sr = new StreamReader(s))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Message));
                s.Position = 0;
                m = (Message)serializer.ReadObject(s);
            }
            return m;
        }
    }
}
