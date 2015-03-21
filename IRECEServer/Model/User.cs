using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRECEServer.Model
{
    public class User
    {
        public String Username { get; set; }
        public String Password { get; set; }

        public static List<User> Users { get; set; }

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
    }
}
