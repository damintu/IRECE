using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRECE.Message;

namespace IRECEServer.Model
{
    class Channel
    {
        public string Name { get; set; }
        public List<Client> Clients { get; set; }

        public void Send(Message m)
        {
            Console.WriteLine(m.ToString());
        }

    }
}
