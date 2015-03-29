using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IRECEServer.Model
{
    public class User
    {
        public String Username { get; set; }
        public String Password { get; set; }

        private static List<User> users;
        public static List<User> Users {
            get
            {
                if (users == null)
                {
                    return Load();
                }
                return users;
            }
            set
            {
                users = value;
            }
        }

        public static User GetByUsername(string name)
        {
            foreach (User user in User.Users)
            {
                if (user.Username == name)
                {
                    return user;
                }
            }
            return null;
        }

        public static List<User> Load()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
            string fileName = "./users.xml";
            if (File.Exists(fileName))
            {
                TextReader textReader = new StreamReader(fileName);
                users = (List<User>)serializer.Deserialize(textReader);
                textReader.Close();
            }
            else
            {
                users = new List<User>();
                User.Save();
            }

            return users;
        }

        public static void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<User>));

            string fileName = "./users.xml";
            TextWriter textWriter = new StreamWriter(fileName);
            serializer.Serialize(textWriter, users);
            textWriter.Close();
        }
    }
}
